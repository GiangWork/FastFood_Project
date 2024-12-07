using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_QLCuaHangThucAnNhanh.Models
{
    public class AssociationRule
    {
        public List<string> Antecedent { get; set; }
        public List<string> Consequent { get; set; }

        public AssociationRule(List<string> antecedent, List<string> consequent)
        {
            Antecedent = antecedent;
            Consequent = consequent;
        }
    }
}