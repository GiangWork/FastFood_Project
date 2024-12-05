var cartDta = JSON.parse(localStorage.getItem("storedata"))
// console.log(cartDta)
var total = cartDta.reduce(function (sum, ele, i, arr) {
    return sum + ele.price
}, 0);
//console.log(total)

var div3 = document.createElement("div")
div3.innerText = "₹" + " " + total
var btn3 = document.createElement("button")
btn3.innerText = "Pay"
btn3.setAttribute("class", "btn2")
btn3.style.marginLeft = "20px"

div3.append(btn3)

document.querySelector(".totalcart").append(div3)
cartDta.map(function (ele, index) {

    var div1 = document.createElement("div")
    div1.setAttribute("class", "div1")

    var img1 = document.createElement("img")
    img1.src = ele.image_url
    img1.style.width = "100%";
    img1.style.borderTopRightRadius = "10px"
    img1.style.borderTopLeftRadius = "10px"

    var p1 = document.createElement("p")
    p1.innerText = ele.item
    p1.style.color = "red"
    p1.style.fontSize = "20px"
    p1.style.textAlign = "center"

    var p2 = document.createElement("p")
    p2.innerText = "₹" + ele.price
    p1.style.fontSize = "16px"
    p2.style.textAlign = "center"

    var div2 = document.createElement("div")
    div2.style.display = "flex"
    div2.style.justifyContent = "space-around"

    var btn1 = document.createElement("button")
    btn1.innerText = "Remove"
    btn1.setAttribute("class", "btn1")
    btn1.addEventListener("click", function () {
        removeitem(ele, index)
    });

    var btn2 = document.createElement("button")
    btn2.innerText = "Pay"
    btn2.setAttribute("class", "btn2")
    div2.append(btn2, btn1)

    div1.append(img1, p1, p2, div2)

    document.querySelector(".middlesec").append(div1)

});

function removeitem(ele, index) {
    cartDta.splice(index, 1)
    localStorage.setItem("storedata", JSON.stringify(cartDta))
    window.location.reload();
}