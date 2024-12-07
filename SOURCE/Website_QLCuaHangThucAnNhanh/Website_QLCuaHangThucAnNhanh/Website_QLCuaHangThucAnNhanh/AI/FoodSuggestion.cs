using DAL;
using System.Collections.Generic;
using System;
using System.Linq;
using Website_QLCuaHangThucAnNhanh.Models;

namespace Website_QLCuaHangThucAnNhanh.AI
{
    public class FoodSuggestion
    {
        ChiTietHoaDonDAL chiTietHoaDonBLL = new ChiTietHoaDonDAL();

        public List<List<string>> GetTransactions()
        {
            // Lấy danh sách các giao dịch từ dữ liệu chi tiết hóa đơn
            var transactions = chiTietHoaDonBLL.GetAllChiTietHoaDon()
                .GroupBy(x => x.MaHoaDon)
                .Select(g => g.Select(x => x.MaMonAn).ToList())
                .ToList();

            return transactions;
        }

        public List<List<string>> GetFrequentItemsets(List<List<string>> transactions, int minSupport)
        {
            var frequentItemsets = new List<List<string>>();

            // Lưu trữ các giao dịch chứa từng item
            var itemTransactionMap = new Dictionary<string, HashSet<int>>();

            for (int i = 0; i < transactions.Count; i++)
            {
                foreach (var item in transactions[i])
                {
                    if (!itemTransactionMap.ContainsKey(item))
                    {
                        itemTransactionMap[item] = new HashSet<int>();
                    }
                    itemTransactionMap[item].Add(i); // Lưu chỉ số giao dịch chứa item
                }
            }

            // Tạo các itemset 1-item (từng món ăn đơn lẻ)
            var oneItemSets = itemTransactionMap
                                .Where(item => item.Value.Count >= minSupport)
                                .Select(item => new List<string> { item.Key })
                                .ToList();

            frequentItemsets.AddRange(oneItemSets);

            // Tạo itemset 2-item, 3-item, ... cho đến khi không có itemset nào thỏa mãn
            var currentItemsets = oneItemSets;
            int k = 2;
            while (currentItemsets.Any())
            {
                var nextItemsets = GetCandidateItemsets(currentItemsets, k);

                // Lọc itemsets hợp lệ dựa trên số lần xuất hiện trong các giao dịch
                currentItemsets = nextItemsets
                    .Where(itemset =>
                        itemset.All(item => itemTransactionMap.ContainsKey(item)) && // Kiểm tra itemset có trong các giao dịch
                        itemset.Select(item => itemTransactionMap[item]).Aggregate((set1, set2) => new HashSet<int>(set1.Intersect(set2))).Count >= minSupport) // Kiểm tra sự xuất hiện chung
                    .ToList();

                frequentItemsets.AddRange(currentItemsets);
                k++;
            }

            return frequentItemsets;
        }

        public List<List<string>> GetCandidateItemsets(List<List<string>> currentItemsets, int k)
        {
            var candidateItemsets = new List<List<string>>();

            for (int i = 0; i < currentItemsets.Count; i++)
            {
                for (int j = i + 1; j < currentItemsets.Count; j++)
                {
                    var set1 = currentItemsets[i];
                    var set2 = currentItemsets[j];

                    // Tạo candidate itemset chỉ khi hai itemset có k-1 phần tử giống nhau
                    var unionSet = set1.Union(set2).ToList();
                    if (unionSet.Count == k && !candidateItemsets.Contains(unionSet))
                    {
                        candidateItemsets.Add(unionSet);
                    }
                }
            }

            return candidateItemsets;
        }


        public List<AssociationRule> GetAssociationRules(List<List<string>> frequentItemsets, List<List<string>> transactions, double minConfidence)
        {
            var associationRules = new List<AssociationRule>();

            foreach (var itemset in frequentItemsets.Where(itemset => itemset.Count > 1))
            {
                // Tạo các phân tách itemset thành antecedent và consequent
                var subsets = GetSubsets(itemset);
                foreach (var subset in subsets)
                {
                    var antecedent = subset;
                    var consequent = itemset.Except(antecedent).ToList();

                    double supportCount = transactions.Count(t => t.Intersect(itemset).Count() == itemset.Count);
                    double antecedentSupportCount = transactions.Count(t => t.Intersect(antecedent).Count() == antecedent.Count);

                    double confidence = supportCount / antecedentSupportCount;

                    // Kiểm tra nếu confidence >= minConfidence
                    if (confidence >= minConfidence)
                    {
                        // Tạo đối tượng AssociationRule và thêm vào danh sách
                        associationRules.Add(new AssociationRule(antecedent, consequent));
                    }
                }
            }

            return associationRules;
        }

        public List<List<string>> GetSubsets(List<string> itemset)
        {
            var subsets = new List<List<string>>();
            int subsetCount = (int)Math.Pow(2, itemset.Count);

            for (int i = 1; i < subsetCount; i++)
            {
                var subset = new List<string>();
                for (int j = 0; j < itemset.Count; j++)
                {
                    if ((i & (1 << j)) != 0)
                    {
                        subset.Add(itemset[j]);
                    }
                }
                subsets.Add(subset);
            }

            return subsets;
        }

        public List<string> GetSuggestedItemsForCart(List<CartItem> cartItems, int minSupport, double minConfidence)
        {
            // Lấy tất cả các giao dịch từ cơ sở dữ liệu
            var transactions = GetTransactions();

            // Tìm itemsets thường xuyên từ các giao dịch trong cơ sở dữ liệu
            var frequentItemsets = GetFrequentItemsets(transactions, minSupport);

            // Tạo các quy tắc kết hợp từ các itemsets thường xuyên
            var associationRules = GetAssociationRules(frequentItemsets, transactions, minConfidence);

            // Lọc các quy tắc kết hợp dựa trên các món ăn hiện tại trong giỏ hàng (cartItems)
            var suggestedItems = new List<string>();
            foreach (var rule in associationRules)
            {
                // Nếu tất cả món ăn trong antecedent của quy tắc đều có mặt trong giỏ hàng, thì gợi ý món ăn trong consequent
                if (rule.Antecedent.All(item => cartItems.Select(ci => ci.MaMonAn).Contains(item)))
                {
                    suggestedItems.AddRange(rule.Consequent);
                }
            }

            // Lọc ra các món ăn duy nhất (loại bỏ trùng) và không có trong giỏ hàng
            var uniqueSuggestedItems = suggestedItems.Distinct()
                                                     .Where(item => !cartItems.Select(ci => ci.MaMonAn).Contains(item))
                                                     .Take(8)  // Giới hạn số lượng gợi ý tối đa là 8
                                                     .ToList();

            return uniqueSuggestedItems;
        }

    }
}
