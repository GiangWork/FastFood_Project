﻿document.querySelector("#chickenbuckets").addEventListener("click", myfun)
function myfun() {
    event.preventDefault();
    var elmntToView = document.getElementById("para2");
    elmntToView.scrollIntoView();
}
document.querySelector("#biryanibuckets").addEventListener("click", myfun1)
function myfun1() {
    event.preventDefault();
    var elmntToView1 = document.getElementById("para3");
    elmntToView1.scrollIntoView();
}

document.querySelector("#boxmeals").addEventListener("click", myfun3)
function myfun3() {
    event.preventDefault();
    var elmntToView3 = document.getElementById("para4");
    elmntToView3.scrollIntoView();
}

document.querySelector("#burgers").addEventListener("click", myfun5)
function myfun5() {
    event.preventDefault();
    var elmntToView5 = document.getElementById("para5");
    elmntToView5.scrollIntoView();
}

document.querySelector("#stayhomespecial").addEventListener("click", myfun6)
function myfun6() {
    event.preventDefault();
    var elmntToView6 = document.getElementById("para6");
    elmntToView6.scrollIntoView();
}

document.querySelector("#snacks").addEventListener("click", myfun7)
function myfun7() {
    event.preventDefault();
    var elmntToView7 = document.getElementById("para7");
    elmntToView7.scrollIntoView();
}

document.querySelector("#beverages").addEventListener("click", myfun8)
function myfun8() {
    event.preventDefault();
    var elmntToView8 = document.getElementById("para8");
    elmntToView8.scrollIntoView();
}

var cartdata = JSON.parse(localStorage.getItem("storedata")) || [];

var MatchDaySpecials = [
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-33781-0.jpg?ver=13.9",
        item: " Howzzat Biryani Combo",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 3",
        price: 899.00,
        description: "Large portions of our Hyderabadi Biryani rice,2 Spicy Gravies,4pc Wings & a Pepsi PET [serves 2-3]",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-33783-0.jpg?ver=13.9",
        item: "Super 6s Bucket Meal",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 2-3",
        price: 649.00,
        description: "Save 23% on this combo of 6 Hot & Crispy Chicken, 6 Strips, Medium Fries & Pepsi PET [serves 3]",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/md/A-33784-0.jpg?ver=13.9",
        item: "Super $s Bucket Meal",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 2-3",
        price: 799.00,
        description: "Enjoy 4 Hot & Crispy Chicken, 4 Strips, Medium Popcorn & Pepsi PET - save Rs. 94 [serves 2-3]",

    },
    {
        image_url: "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-33785-0.jpg?ver=13.9",
        item: "Super 6s Bucket",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 3",
        price: 799.00,
        description: "Match day set with 6 Hot & Crispy Chicken & 6 Strips at 21% off [serves 3]",

    },
    {
        image_url: "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-33786-0.jpg?ver=13.9",
        item: "Super 4s Bucket",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 2",
        price: 559.00,
        description: "Cheer on with 4 Hot & Crispy Chicken & 4 Strips - save Rs. 116 [serves 2]",

    },
    {
        image_url: "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-33787-0.jpg?ver=13.9",
        item: "Dream Team Bucket",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 3-4",
        price: 819.00,
        description: "Leg before any wicket! Save 32% on 10 Leg Pieces & 4 Dips [serves 3-4]",

    }
];


MatchDaySpecials.map(function (ele, i, arr) {

    var div1 = document.createElement("div");
    div1.style.padding = "10px"
    div1.style.height = "500px"
    div1.style.boxShadow = "rgba(0, 0, 0, 0.15) 1.95px 1.95px 2.6px;"



    var image = document.createElement("img")
    image.src = ele.image_url
    image.style.width = "100%";
    image.setAttribute("class", "kfcimage")

    var item = document.createElement("p")
    item.textContent = ele.item
    item.style.fontFamily = "National 2 Regular"
    item.style.fontSize = "16px"
    item.style.lineHeight = "24px";
    item.style.fontWeight = "600"

    // var redimg = document.createElement("img")
    // image.src = ele.red_img

    var nonveg = document.createElement("p")
    nonveg.textContent = ele.nonveg + " " + ele.Serves
    nonveg.style.fontSize = "12px"
    nonveg.style.lineHeight = "22px";
    nonveg.style.fontWeight = "400"


    var price = document.createElement("p")
    price.textContent = "₹" + ele.price
    price.style.fontSize = "16px"
    price.style.lineHeight = "24px";
    price.style.fontWeight = "600"
    var Description = document.createElement("p")
    Description.textContent = ele.description
    Description.style.fontStyle = "normal"
    Description.style.fontSize = "14px"
    Description.style.lineHeight = "24px";
    Description.style.fontWeight = "400"

    var btn1 = document.createElement("button")
    btn1.innerHTML = "Add to cart "
    btn1.setAttribute("id", "btn1");
    btn1.style.color = "white"
    btn1.style.fontSize = "14px"
    btn1.style.padding = "15px 60px"
    btn1.style.backgroundColor = "#E71A41"
    btn1.style.borderRadius = "25px"
    btn1.style.border = "0px"
    btn1.style.marginLeft = "20px"
    btn1.addEventListener("click", function () {
        addtocart(ele)
    });

    div1.append(image, item, nonveg, price, Description, btn1)
    document.querySelector("#alignhere").append(div1)
});




// object 2
biryanibuckets = [
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-33661-0.jpg?ver=13.9",
        item: "Classic Biryani Combo",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 3",
        price: 699.00,
        description: "Large portions of our new Hyderabadi style Biryani rice, served with 2 pc Hot & Crispy Chicken, 2 Spicy Gravies, 4pc Chicken",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-33518-0.jpg?ver=13.9",
        item: "Smoky Grilled Biryani Combo",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 2-3",
        price: 699.00,
        description: "Large portions of our new Hyderabadi style Biryani rice,Medium Popcorn & a Pepsi PET [serves 2-3]",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-33845-0.jpg?ver=13.9",
        item: "Howzzat Biryani Combo",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 2-3",
        price: 649.00,
        description: "Large portions of our new Hyderabadi style Biryani rice, served with double portions of Chicken Popcorn, 2 Spicy Gravies, 4pc",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-33449-42353.jpg?ver=13.9",
        item: "Classic Chicken Biryani Bucket (Large)",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 2",
        price: 449.00,
        description: "Large portions of our new Hyderabadi style Biryani rice served with 2 pc Hot & Crispy Chicken & 2 Spicy Gravies [serves 2]",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-33449-42353.jpg?ver=13.9",
        item: "Popcorn Chicken Biryani Bucket (Large)",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 2",
        price: 449.00,
        description: "Large portions of our new Hyderabadi style Biryani rice served with double portions of Popcorn & 2 Spicy Gravies [serves 2]",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-33451-42355.jpg?ver=13.9",
        item: "Smoky Grilled Biryani Bucket (Large)",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 2",
        price: 449.00,
        description: "Large portions of our new Hyderabadi style Biryani rice with 2 pc Smoky Red & 2 Spicy Gravies a delicious to eat [serves 2]",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-33445-42349.jpg?ver=13.9",
        item: "Classic Chicken Biryani Bucket",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 1",
        price: 219.00,
        description: "New Hyderabadi style Biryani rice served with 1 pc Hot & Crispy Chicken & a Spicy Gravy [serves 1]",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-33446-42350.jpg?ver=13.9",
        item: "Popcorn Chicken Biryani Bucket",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 1",
        price: 219.00,
        description: "New Hyderabadi style Biryani rice served with signature Popcorn & a Spicy Gravy [serves 1]",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-33447-42351.jpg?ver=13.9",
        item: "Smoky Grilled Biryani Bucket",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 1",
        price: 219.00,
        description: "New Hyderabadi style Biryani rice served with 1 pc Smoky Red Chicken & a Spicy Gravy [serves 1]",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-33448-42352.jpg?ver=13.9",
        item: "Veg Biryani Bucket",
        red_img: "https://online.kfc.co.in/static/media/Veg_dot_Icon.2636651d.svg",
        nonveg: "veg",
        Serves: "Serves 1",
        price: 169.00,
        description: "New Hyderabadi style Biryani rice served with a crispy Veg Patty & a Spicy Gravy [serves 1]",

    },
];

biryanibuckets.map(function (ele, i, arr) {

    var div2 = document.createElement("div");
    div2.style.padding = "10px"
    div2.style.boxShadow = "rgba(0, 0, 0, 0.35) 0px 5px 15px"
    div2.style.borderRadius = "5px"



    var image = document.createElement("img")
    image.src = ele.image_url
    image.style.width = "100%";
    image.setAttribute("class", "kfcimage")


    var item2 = document.createElement("p")
    item2.textContent = ele.item
    item2.style.fontFamily = "National 2 Regular"
    item2.style.fontSize = "16px"
    item2.style.lineHeight = "24px";
    item2.style.fontWeight = "600"

    // var redimg = document.createElement("img")
    // image.src = ele.red_img

    var nonveg2 = document.createElement("p")
    nonveg2.textContent = ele.nonveg + " " + ele.Serves
    nonveg2.style.fontSize = "12px"
    nonveg2.style.lineHeight = "22px";
    nonveg2.style.fontWeight = "400"


    var price2 = document.createElement("p")
    price2.textContent = "₹" + ele.price
    price2.style.fontSize = "16px"
    price2.style.lineHeight = "24px";
    price2.style.fontWeight = "600"
    var Description2 = document.createElement("p")
    Description2.textContent = ele.description
    Description2.style.fontStyle = "normal"
    Description2.style.fontSize = "14px"
    Description2.style.lineHeight = "24px";
    Description2.style.fontWeight = "400"

    var btn2 = document.createElement("button")
    btn2.innerHTML = "Add to cart "
    btn2.style.color = "white"
    btn2.style.fontSize = "14px"
    btn2.style.padding = "15px 60px"
    btn2.style.backgroundColor = "#E71A41"
    btn2.style.borderRadius = "25px"
    btn2.style.border = "0px"
    btn2.style.textAlign = "center"
    btn2.style.marginLeft = "20px"
    btn2.addEventListener("click", function () {
        addtocart(ele)
    });

    div2.append(image, item2, nonveg2, price2, Description2, btn2)
    document.querySelector("#alignhere3").append(div2)
});

//div 3
chicken_buckets = [
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-33653-0.jpg?ver=13.9",
        item: " Peri Peri 10 Strips & 2 Dips",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 2-3",
        price: 449.00,
        description: "Flat Rs. 101 off on this dipping combo of 10 pc spicy Peri Peri chicken strips & 2 delicious dips [serves 2-3]",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-33654-0.jpg?ver=13.9",
        item: " Peri Peri 5 Leg Pc & 2 Dips",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 2",
        price: 449.00,
        description: "Save 25% on this combo of 5 spicy Peri Peri Leg Pieces & 2 Dips [serves 2]",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-33656-0.jpg?ver=13.9",
        item: " Peri Peri 5 Leg Pc Meal",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 2",
        price: 599.00,
        description: "Stay home & chill with spicy Peri Peri Leg Piece! Save Rs. 160 on 5 chicken Leg Pieces, 2 dips, 1 Medium Fries & a chilled Pepsi PET!",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-33657-0.jpg?ver=13.9",
        item: "Friendship Bucket",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 3",
        price: 699.00,
        description: "Save 23% on this combo of 3pc Hot & Crispy chicken, 3 Hot Wings, 3 Chicken Strips & a Large Popcorn [serves 3]",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-30908-0.jpg?ver=13.9",
        item: "Bucket for Two",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 2",
        price: 599.00,
        description: "Flat Rs. 70 off on 2pc Hot & Crispy Chicken, 2 pc Smoky Red Chicken & Large Popcor [Serves 2]",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-33658-0.jpg?ver=13.9",
        item: "Ultimate Savings Bucket",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 2-3",
        price: 699.00,
        description: "Save 30% with our best-seller bucket of 4pc Hot & crispy chicken, 6 Hot Wings, 4 chicken strips , 3 Dips & a chilled Pepsi PET",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-32293-0.jpg?ver=13.9",
        item: "Big 12",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 2-3",
        price: 729.00,
        description: "Save 22% on this combo of 6pc Hot & Crispy Chicken, 6 Hot Wings & 2 creamy dips [Serves 2-3]",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-33659-0.jpg?ver=13.9",
        item: "Mingles Bucket Meal",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 2",
        price: 459.00,
        description: "Save Rs. 55 on this crowd favorite combo of 4 Hot Wings, 2 Chicken Strips, a Reg Popcorn, medium fries & a chilled Pepsi PET [serves 2 ]",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-32197-0.jpg?ver=13.9",
        item: "Big 8",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 2-3",
        price: 619.00,
        description: "Save 30% on this bucket of 4pc Hot & Crispy chicken & 4pc Smoky Red chicken [Serves 2-3]",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-31897-41326.jpg?ver=13.9",
        item: "5pc Smoky Red Chicken",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 2",
        price: 429.00,
        description: "Save Rs. 121 & get 5pc Smoky red grilled chicken [Serves 2]",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-30640-40488.jpg?ver=13.9",
        item: "8 pc Hot & Crispy Chicken",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 3-4",
        price: 699.00,
        description: "Save 26% & get 8pc signature Hot & crispy chicken [Serves 3-4]",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-30640-40488.jpg?ver=13.9",
        item: "6 Pc Hot & Crispy",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 2-3",
        price: 549.00,
        description: "Save Rs. 111 & get 6pc signature Hot & crispy chicken [Serves 2-3]",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-30865-0.jpg?ver=13.9",
        item: "KFC Favorites",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 2",
        price: 399.00,
        description: "Save 27% on this combo Chicken Zinger, Large Popcorn & 4pc Hot Wings [Serves 2]",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-33660-0.jpg?ver=13.9",
        item: "Chick & Share",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 2",
        price: 449.00,
        description: "Save upto Rs. 101 & Pick any combo - 5pc Hot & Crispy Chicken OR 10 chicken strips OR 2 Large Popcorn [serves 2]",

    }
];


chicken_buckets.map(function (ele, i, arr) {

    var div3 = document.createElement("div");
    div3.style.padding = "10px"
    div3.style.boxShadow = "rgba(0, 0, 0, 0.35) 0px 5px 15px"
    div3.style.borderRadius = "5px"



    var image = document.createElement("img")
    image.src = ele.image_url
    image.style.width = "100%";
    image.setAttribute("class", "kfcimage")


    var item3 = document.createElement("p")
    item3.textContent = ele.item
    item3.style.fontFamily = "National 2 Regular"
    item3.style.fontSize = "16px"
    item3.style.lineHeight = "24px";
    item3.style.fontWeight = "600"

    // var redimg = document.createElement("img")
    // image.src = ele.red_img

    var nonveg3 = document.createElement("p")
    nonveg3.textContent = ele.nonveg + " " + ele.Serves
    nonveg3.style.fontSize = "12px"
    nonveg3.style.lineHeight = "22px";
    nonveg3.style.fontWeight = "400"


    var price3 = document.createElement("p")
    price3.textContent = "₹" + ele.price
    price3.style.fontSize = "16px"
    price3.style.lineHeight = "24px";
    price3.style.fontWeight = "600"
    var Description3 = document.createElement("p")
    Description3.textContent = ele.description
    Description3.style.fontStyle = "normal"
    Description3.style.fontSize = "14px"
    Description3.style.lineHeight = "24px";
    Description3.style.fontWeight = "400"

    var btn3 = document.createElement("button")
    btn3.innerHTML = "Add to cart "
    btn3.style.color = "white"
    btn3.style.fontSize = "14px"
    btn3.style.padding = "15px 60px"
    btn3.style.backgroundColor = "#E71A41"
    btn3.style.borderRadius = "25px"
    btn3.style.border = "0px"
    btn3.style.textAlign = "center"
    btn3.style.marginLeft = "20px"

    btn3.addEventListener("click", function () {
        addtocart(ele)
    });

    div3.append(image, item3, nonveg3, price3, Description3, btn3)
    document.querySelector("#alignhere2").append(div3)
});



var BoxMeals = [
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-33668-0.jpg?ver=13.9",
        item: "All Chicken Box",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        price: 179.00,
        description: "A Box with all your KFC favorites - now at a deal price! Enjoy 1 pc Hot & Crispy, 2 Hot Wings & 1 Chicken Strip",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-32053-0.jpg?ver=13.9",
        item: "Classic Zinger Box",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        price: 299.00,
        description: "A classic deal for Zinger lovers : Get 1 Classic Zinger, 2 Hot Wings 2 Hot Wings,1 Veg Patty & Pepsi",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-32383-0.jpg?ver=13.9",
        item: "Zinger Tandoori Box",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        price: 299.00,
        description: "A deal for the Tandoori lovers : Get 1 Tandoori Zinger, 2 Hot Wings, 1 Veg Patty & Pepsi which delicious",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-33527-0.jpg?ver=13.9",
        item: "Popcorn Biryani Box",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        price: 329.00,
        description: "Biryani lovers unite : Get 1 Popcorn Biryani Bucket with gravy, 2 Hot Wings & Pepsi",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-32055-0.jpg?ver=13.9",
        item: "Veg Zinger Box",
        red_img: "https://online.kfc.co.in/static/media/Veg_dot_Icon.2636651d.svg",
        nonveg: "veg",
        price: 299.00,
        description: "A deal for the Veg Zinger lovers : Get 1 Veg Zinger, 2 Veg Patties & a Pepsi",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-33526-0.jpg?ver=13.9",
        item: "Veg Biryani Box",
        red_img: "https://online.kfc.co.in/static/media/Veg_dot_Icon.2636651d.svg",
        nonveg: "veg",
        price: 279.00,
        description: "Biryani lovers unite : Get 1 Veg Biryani Bucket with gravy, 1 Veg Patty & a Pepsi",

    },
];


BoxMeals.map(function (ele, i, arr) {

    var div4 = document.createElement("div");
    div4.style.padding = "10px"
    div4.style.boxShadow = "rgba(0, 0, 0, 0.35) 0px 5px 15px"
    div4.style.borderRadius = "5px"



    var image = document.createElement("img")
    image.src = ele.image_url
    image.style.width = "100%";
    image.setAttribute("class", "kfcimage")


    var item4 = document.createElement("p")
    item4.textContent = ele.item
    item4.style.fontFamily = "National 2 Regular"
    item4.style.fontSize = "16px"
    item4.style.lineHeight = "24px";
    item4.style.fontWeight = "600"

    // var redimg = document.createElement("img")
    // image.src = ele.red_img

    var nonveg4 = document.createElement("p")
    nonveg4.textContent = ele.nonveg + " " + ele.Serves
    nonveg4.style.fontSize = "12px"
    nonveg4.style.lineHeight = "22px";
    nonveg4.style.fontWeight = "400"


    var price4 = document.createElement("p")
    price4.textContent = "₹" + ele.price
    price4.style.fontSize = "16px"
    price4.style.lineHeight = "24px";
    price4.style.fontWeight = "600"

    var Description4 = document.createElement("p")
    Description4.textContent = ele.description
    Description4.style.fontStyle = "normal"
    Description4.style.fontSize = "14px"
    Description4.style.lineHeight = "24px";
    Description4.style.fontWeight = "400"

    var btn4 = document.createElement("button")
    btn4.innerHTML = "Add to cart "
    btn4.style.color = "white"
    btn4.style.fontSize = "14px"
    btn4.style.padding = "15px 60px"
    btn4.style.backgroundColor = "#E71A41"
    btn4.style.borderRadius = "25px"
    btn4.style.border = "0px"
    btn4.style.textAlign = "center"
    btn4.style.marginLeft = "20px"

    btn4.addEventListener("click", function () {
        addtocart(ele)
    });

    div4.append(image, item4, nonveg4, price4, Description4, btn4)
    document.querySelector("#alignhere4").append(div4)
});

////div 5

var Burgers = [
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-33666-42485.jpg?ver=13.9",
        item: "Peri Peri Zinger Burger",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 1",
        price: 180.00,
        description: "Chicken zinger with a delicious spicy Peri Peri sauce [serves 1]",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-32576-0.jpg?ver=13.9",
        item: "2 Chicken Krisper Burgers",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "",
        price: 219.00,
        description: "2 delicious chicken value burgers - at only 109 each!",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-32573-0.jpg?ver=13.9",
        item: "2 Veg Krisper Burgers",
        red_img: "https://online.kfc.co.in/static/media/Veg_dot_Icon.2636651d.svg",
        nonveg: "Non veg",
        Serves: "",
        price: 138.00,
        description: "2 delicious veg value burgers - at only 69 each!",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-32578-0.jpg?ver=13.9",
        item: "Chicken & Krispers Combo",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg", nonveg: "Non veg",
        Serves: "",
        price: 499.00,
        description: "Save Rs. 50 on this combo of 2 chicken value burgers, 2 pc Hot & Crispy, 2 dips & a chilled Pepsi PET!",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-32579-0.jpg?ver=13.9",
        item: "Veg-Non-Veg Krispers Combo",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg", nonveg: "Non veg",
        Serves: "",
        price: 349.00,
        description: "Pack of 4 burgers - 2 veg & 2 chicken value burgers at a deal price !",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-33667-0.jpg?ver=13.9",
        item: "Peri Peri & Classic Zinger Duo",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg", nonveg: "Non veg",
        Serves: "Serves 2",
        price: 309.00,
        description: "Best-seller combo of classic chicken zinger & the new spicy Peri Peri Zinger [serves 2]",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-30663-40505.jpg?ver=13.9",
        item: "Classic Zinger Burger",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg", nonveg: "Non veg",
        Serves: "",
        price: 170.00,
        description: "Signature chicken burger made with a crunchy chicken fillet, veggies & a delicious mayo sauce",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-32172-0.jpg?ver=13.9",
        item: "Buddy Meal",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg", nonveg: "Non veg",
        Serves: "",
        price: 460.00,
        description: "Share 2 Classic Chicken Zingers & a Medium Popcorn in this delightful combo for 2",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-32403-41750.jpg?ver=13.9",
        item: "Veg Zinger Burger",
        red_img: "https://online.kfc.co.in/static/media/Veg_dot_Icon.2636651d.svg",
        Serves: "",
        price: 160.00,
        description: "Signature veg burger with crispy patties, veggies & a tangy sauce",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-32574-0.jpg?ver=13.9",
        item: "2 Veg Krispers Meal",
        red_img: "https://online.kfc.co.in/static/media/Veg_dot_Icon.2636651d.svg",
        Serves: "",
        price: 249.00,
        description: "2 veg value burgers, crispy medium fries & 2 delicious dips at a deal price!",

    }
];
Burgers.map(function (ele, i, arr) {

    var div5 = document.createElement("div");
    div5.style.padding = "10px"
    div5.style.boxShadow = "rgba(0, 0, 0, 0.35) 0px 5px 15px"
    div5.style.borderRadius = "5px"



    var image = document.createElement("img")
    image.src = ele.image_url
    image.style.width = "100%";
    image.setAttribute("class", "kfcimage")


    var item5 = document.createElement("p")
    item5.textContent = ele.item
    item5.style.fontFamily = "National 2 Regular"
    item5.style.fontSize = "16px"
    item5.style.lineHeight = "24px";
    item5.style.fontWeight = "600"

    // var redimg = document.createElement("img")
    // image.src = ele.red_img

    var nonveg5 = document.createElement("p")
    nonveg5.textContent = ele.nonveg + " " + ele.Serves
    nonveg5.style.fontSize = "12px"
    nonveg5.style.lineHeight = "22px";
    nonveg5.style.fontWeight = "400"


    var price5 = document.createElement("p")
    price5.textContent = "₹" + ele.price
    price5.style.fontSize = "16px"
    price5.style.lineHeight = "24px";
    price5.style.fontWeight = "600"

    var Description5 = document.createElement("p")
    Description5.textContent = ele.description
    Description5.style.fontStyle = "normal"
    Description5.style.fontSize = "14px"
    Description5.style.lineHeight = "24px";
    Description5.style.fontWeight = "400"

    var btn5 = document.createElement("button")
    btn5.innerHTML = "Add to cart "
    btn5.style.color = "white"
    btn5.style.fontSize = "14px"
    btn5.style.padding = "15px 60px"
    btn5.style.backgroundColor = "#E71A41"
    btn5.style.borderRadius = "25px"
    btn5.style.border = "0px"
    btn5.style.textAlign = "center"
    btn5.style.marginLeft = "20px"

    btn5.addEventListener("click", function () {
        addtocart(ele)
    });

    div5.append(image, item5, nonveg5, price5, Description5, btn5)
    document.querySelector("#alignhere5").append(div5)
});


var stayhomespecials = [
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-33523-0.jpg?ver=13.9",
        item: "Popcorn Biryani Combo",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 2-3",
        price: 649.00,
        description: "Large portions of our new Hyderabadi style Biryani rice, served with double portions of Chicken Popcorn, 2 Spicy Gravies, 4pc",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-33662-0.jpg?ver=13.9",
        item: "Classic Biryani Combo",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 2-3",
        price: 699.00,
        description: "Large portions of our new Hyderabadi style Biryani rice, served with 2 pc Hot & Crispy Chicken, 2 Spicy Gravies, 4pc Chicken Strips & a Pepsi PET [serves 2-3]",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-33525-0.jpg?ver=13.9",
        item: "Smoky Grilled Biryani Combo",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 2-3",
        price: 699.00,
        description: "Large portions of our new Hyderabadi style Biryani rice, served with 2 pc Smoky Red Chicken, 2 Spicy Gravies, Medium Popcorn & a Pepsi PET [serves 2-3]",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-33663-0.jpg?ver=13.9",
        item: "Super Snacker Combo",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 1-2",
        price: 429.00,
        description: "Best of snacks with a Medium Popcorn, 4 strips, 1 dip & a chilled Pepsi Black [serves 1-2]",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-33065-0.jpg?ver=13.9",
        item: "Chick’n Wings Combo",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 1-2",
        price: 429.00,
        description: "Enjoy 2pc Hot & Crispy Chicken, 4 wings , 2 dips & a chilled Pepsi Black [serves 1-2]",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-33664-0.jpg?ver=13.9",
        item: "Stay Home Bucket",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 3",
        price: 749.00,
        description: "Save 21% & enjoy 4pc Hot & Crispy Chicken, 4 Hot Wings, 6 chicken strips & 2 delicious dips [serves 3]",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-33520-0.jpg?ver=13.9",
        item: "Family Feast",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 3",
        price: 789.00,
        description: "Family Deal of 3 chicken zingers, a medium popcorn, medium fries & a chilled Pepsi PET [serves 3]",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-33066-0.jpg?ver=13.9",
        item: "Classic Zinger Meal",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 1",
        price: 319.00,
        description: "Favorite combo of Classic Zinger Burger, Medium Fries & a chilled Pepsi Black [serves 1]",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-33067-0.jpg?ver=13.9",
        item: "Chick'n Strips Solo Combo",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 1",
        price: 399.00,
        description: "Go solo with 1 pc Hot & Crispy, 3 strips, Medium Fries & a chilled Pepsi Black [serves 1]",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-33068-0.jpg?ver=13.9",
        item: "Chick'n Fries Solo Combo",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg",
        nonveg: "Non veg",
        Serves: "Serves 1",
        price: 399.00,
        description: "Try this classic pairing of 2pc Hot & Crispy, Medium Fries, 2 Dips & a chilled Pepsi Black [serves 1]",

    },
];

stayhomespecials.map(function (ele, i, arr) {

    var div6 = document.createElement("div");
    div6.style.padding = "10px"
    div6.style.boxShadow = "rgba(0, 0, 0, 0.35) 0px 5px 15px"
    div6.style.borderRadius = "5px"



    var image = document.createElement("img")
    image.src = ele.image_url
    image.style.width = "100%";
    image.setAttribute("class", "kfcimage")


    var item6 = document.createElement("p")
    item6.textContent = ele.item
    item6.style.fontFamily = "National 2 Regular"
    item6.style.fontSize = "16px"
    item6.style.lineHeight = "24px";
    item6.style.fontWeight = "600"

    // var redimg = document.createElement("img")
    // image.src = ele.red_img

    var nonveg6 = document.createElement("p")
    nonveg6.textContent = ele.nonveg + " " + ele.Serves
    nonveg6.style.fontSize = "12px"
    nonveg6.style.lineHeight = "22px";
    nonveg6.style.fontWeight = "400"


    var price6 = document.createElement("p")
    price6.textContent = "₹" + ele.price
    price6.style.fontSize = "16px"
    price6.style.lineHeight = "24px";
    price6.style.fontWeight = "600"

    var Description6 = document.createElement("p")
    Description6.textContent = ele.description
    Description6.style.fontStyle = "normal"
    Description6.style.fontSize = "14px"
    Description6.style.lineHeight = "24px";
    Description6.style.fontWeight = "400"

    var btn6 = document.createElement("button")
    btn6.innerHTML = "Add to cart "
    btn6.style.color = "white"
    btn6.style.fontSize = "14px"
    btn6.style.padding = "15px 60px"
    btn6.style.backgroundColor = "#E71A41"
    btn6.style.borderRadius = "25px"
    btn6.style.border = "0px"
    btn6.style.textAlign = "center"
    btn6.style.marginLeft = "20px"

    btn6.addEventListener("click", function () {
        addtocart(ele)
    });

    div6.append(image, item6, nonveg6, price6, Description6, btn6)
    document.querySelector("#alignhere6").append(div6)
});


var snacks = [
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-32841-42014.jpg?ver=13.9",
        item: "Choco Mud Pie",
        red_img: "https://online.kfc.co.in/static/media/Veg_dot_Icon.2636651d.svg",
        nonveg: "veg",
        Serves: "",
        price: 119.00,
        description: "Chocolate lovers unite! Say hello to our delicous, new, creamy chocolate & cake dessert- a must try!",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-32842-42015.jpg?ver=13.9",
        item: "Coffee Mousse Cake",
        red_img: "https://online.kfc.co.in/static/media/Veg_dot_Icon.2636651d.svg",
        nonveg: "veg",
        Serves: "",
        price: 119.00,
        description: "Coffee, chocolate, cake…what's not to love? Enjoy our delicious, new dessert for those coffee-licious temptations!",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-31984-0.jpg?ver=13.9",
        item: "Chicken & Fries Bucket",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg", nonveg: " Non veg",
        nonveg: "Non veg",
        Serves: "",
        price: 119.00,
        description: "Save 37% on this favorite combo of 2pc Hot & Crispy chicken with Medium Fries",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-31964-0.jpg?ver=13.9",
        item: "Mingles Bucket",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg", nonveg: " Non veg",
        nonveg: "Non veg",
        Serves: "Serves 1-2",
        price: 309.00,
        description: "Save Rs. 50 on this ultimate mingle of 4 Hot Wings, 2 chicken strips & a reg Popcorn [serves 1-2]",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-31964-0.jpg?ver=13.9",
        item: "Mingles Bucket",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg", nonveg: " Non veg",
        nonveg: "Non veg",
        Serves: "Serves 1-2",
        price: 309.00,
        description: "Save Rs. 50 on this ultimate mingle of 4 Hot Wings, 2 chicken strips & a reg Popcorn [serves 1-2]",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-30678-40515.jpg?ver=13.9",
        item: "4pc Hot & Crispy Chicken",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg", nonveg: " Non veg",
        nonveg: "Non veg",
        Serves: "",
        price: 399.00,
        description: "4 pcs of signature Hot & crispy chicken at a deal price",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-30675-40512.jpg?ver=13.9",
        item: "Large Popcorn",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg", nonveg: " Non veg",
        nonveg: "Non veg",
        Serves: "",
        price: 229.00,
        description: "Signature bite-sized boneless chicken, with special spices",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-31867-41289.jpg?ver=13.9",
        item: "Medium Popcorn",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg", nonveg: " Non veg",
        Serves: "",
        price: 150.00,
        description: "Signature bite-sized boneless chicken, with special spices",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-31866-41288.jpg?ver=13.9",
        item: "Regular Popcorn",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg", nonveg: " Non veg",
        nonveg: "Non veg",
        Serves: "",
        price: 109.00,
        description: "Signature bite-sized boneless chicken, with special spices",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-32287-41499.jpg?ver=13.9",
        item: "Large Fries",
        red_img: "https://online.kfc.co.in/static/media/Veg_dot_Icon.2636651d.svg",
        nonveg: "veg",
        Serves: "",
        price: 115.00,
        description: "Jazz up your meal with crispy large fries!",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-32287-41499.jpg?ver=13.9",
        item: "Medium Fries",
        red_img: "https://online.kfc.co.in/static/media/Veg_dot_Icon.2636651d.svg",
        nonveg: "veg",
        Serves: "",
        price: 95.00,
        description: "Jazz up your meal with crispy fries!",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/no-image.jpg",
        item: "2 pc Hot & Crispy Chicken",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg", nonveg: " Non veg",
        nonveg: "Non veg",
        Serves: "",
        price: 219.00,
        description: "Signature Hot & crispy chicken",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/no-image.jpg",
        item: "2 pc Smoky Red Chicken",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg", nonveg: " Non veg",
        nonveg: "Non veg",
        Serves: "",
        price: 219.00,
        description: "Spicy, red, grilled chicken",
    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/no-image.jpg",
        item: "6pc Peri Peri Chicken strips",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg", nonveg: " Non veg",
        nonveg: "Non veg",
        Serves: "",
        price: 229.00,
        description: "Tender, juicy, signature boneless chicken strips",
    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/no-image.jpg",
        item: "4pc Hot Chicken Wings",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg", nonveg: " Non veg",
        nonveg: "Non veg",
        Serves: "",
        price: 158.00,
        description: "Seasoned, signature KFC chicken wings",
    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/no-image.jpg",
        item: "1 pc Hot & Crispy Chicken",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg", nonveg: " Non veg",
        nonveg: "Non veg",
        Serves: "",
        price: 110.00,
        description: "Signature Hot & crispy chicken",
    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/no-image.jpg",
        item: "1 Pc Smoky Red Chicken",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg", nonveg: " Non veg",
        nonveg: "Non veg",
        Serves: "",
        price: 110.00,
        description: "Spicy, red, grilled chicken",
    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/no-image.jpg",
        item: "3pc Peri Peri Chicken strips",
        red_img: "https://online.kfc.co.in/static/media/Non_veg_dot_Icon.1b0fc8fd.svg", nonveg: " Non veg",
        nonveg: "Non veg",
        Serves: "",
        price: 150.00,
        description: "Tender, juicy, spicy boneless chicken strips",
    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/no-image.jpg",
        item: "2 pc Veg Patty",
        red_img: "https://online.kfc.co.in/static/media/Veg_dot_Icon.2636651d.svg",
        nonveg: "veg",
        Serves: "",
        price: 140.00,
        description: "Delicious, crispy, veg add-on!",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/no-image.jpg",
        item: "Tandoori Masala Dip",
        red_img: "https://online.kfc.co.in/static/media/Veg_dot_Icon.2636651d.svg",
        nonveg: "veg",
        Serves: "",
        price: 30.00,
        description: "Special tandoori flavored dip, to add a twist to your meal!",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/no-image.jpg",
        item: "Pack of 4 Dips",
        red_img: "https://online.kfc.co.in/static/media/Veg_dot_Icon.2636651d.svg",
        nonveg: "veg",
        Serves: "",
        price: 99.00,
        description: "Adding dips is always a good idea!",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/no-image.jpg",
        item: "Pack of 2 Dips",
        red_img: "https://online.kfc.co.in/static/media/Veg_dot_Icon.2636651d.svg",
        nonveg: "veg",
        Serves: "",
        price: 59.00,
        description: "Adding dips is always a good idea!",
    }
];

snacks.map(function (ele, i, arr) {

    var div7 = document.createElement("div");
    div7.style.padding = "10px"
    div7.style.boxShadow = "rgba(0, 0, 0, 0.35) 0px 5px 15px"
    div7.style.borderRadius = "5px"



    var image = document.createElement("img")
    image.src = ele.image_url
    image.style.width = "100%";
    image.setAttribute("class", "kfcimage")


    var item7 = document.createElement("p")
    item7.textContent = ele.item
    item7.style.fontFamily = "National 2 Regular"
    item7.style.fontSize = "16px"
    item7.style.lineHeight = "24px";
    item7.style.fontWeight = "600"

    // var redimg = document.createElement("img")
    // image.src = ele.red_img

    var nonveg7 = document.createElement("p")
    nonveg7.textContent = ele.nonveg + " " + ele.Serves
    nonveg7.style.fontSize = "12px"
    nonveg7.style.lineHeight = "22px";
    nonveg7.style.fontWeight = "400"


    var price7 = document.createElement("p")
    price7.textContent = "₹" + ele.price
    price7.style.fontSize = "16px"
    price7.style.lineHeight = "24px";
    price7.style.fontWeight = "600"

    var Description7 = document.createElement("p")
    Description7.textContent = ele.description
    Description7.style.fontStyle = "normal"
    Description7.style.fontSize = "14px"
    Description7.style.lineHeight = "24px";
    Description7.style.fontWeight = "400"

    var btn7 = document.createElement("button")
    btn7.innerHTML = "Add to cart "
    btn7.style.color = "white"
    btn7.style.fontSize = "14px"
    btn7.style.padding = "15px 60px"
    btn7.style.backgroundColor = "#E71A41"
    btn7.style.borderRadius = "25px"
    btn7.style.border = "0px"
    btn7.style.textAlign = "center"
    btn7.style.marginLeft = "20px"

    btn7.addEventListener("click", function () {
        addtocart(ele)
    });

    div7.append(image, item7, nonveg7, price7, Description7, btn7)
    document.querySelector("#alignhere7").append(div7)
});

var Beverages = [
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-30683-40520.jpg?ver=13.9",
        item: "Pepsi PET",
        red_img: "https://online.kfc.co.in/static/media/Veg_dot_Icon.2636651d.svg",
        nonveg: "veg",
        price: 60.00,
        description: "Pepsi Pet Bottle",

    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-31373-41015.jpg?ver=13.9",
        item: "Pepsi Can 330 ml",
        red_img: "https://online.kfc.co.in/static/media/Veg_dot_Icon.2636651d.svg",
        nonveg: "veg",
        price: 60.00,
        description: "Pepsi Can 330 ml",
    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/xl/A-31374-41016.jpg?ver=13.9",
        item: "7UP Can 330 ml",
        red_img: "https://online.kfc.co.in/static/media/Veg_dot_Icon.2636651d.svg",
        nonveg: "veg",
        price: 60.00,
        description: "7UP Can 330 ml",
    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/no-image.jpg",
        item: "Pepsi Black Can 330 ml",
        red_img: "https://online.kfc.co.in/static/media/Veg_dot_Icon.2636651d.svg",
        nonveg: "veg",
        price: 60.00,
        description: "Pepsi Black Can 330 ml",
    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/no-image.jpg",
        item: "Mirinda Can 330 ml",
        red_img: "https://online.kfc.co.in/static/media/Veg_dot_Icon.2636651d.svg",
        nonveg: "veg",
        price: 60.00,
        description: "Mirinda Can 330 ml",
    },
    {
        image_url:
            "https://orderserv-kfc-assets.yum.com/15895bb59f7b4bb588ee933f8cd5344a/images/items/no-image.jpg",
        item: "Red Bull Energy Drink",
        red_img: "https://online.kfc.co.in/static/media/Veg_dot_Icon.2636651d.svg",
        nonveg: "veg",
        price: 160.00,
        description: "Red Bull Energy Drink",
    },
];

Beverages.map(function (ele, i, arr) {

    var div8 = document.createElement("div");
    div8.style.padding = "10px"
    div8.style.boxShadow = "rgba(0, 0, 0, 0.35) 0px 5px 15px"
    div8.style.borderRadius = "5px"



    var image = document.createElement("img")
    image.src = ele.image_url
    image.style.width = "100%";
    image.setAttribute("class", "kfcimage")


    var item8 = document.createElement("p")
    item8.textContent = ele.item
    item8.style.fontFamily = "National 2 Regular"
    item8.style.fontSize = "16px"
    item8.style.lineHeight = "24px";
    item8.style.fontWeight = "600"

    // var redimg = document.createElement("img")
    // image.src = ele.red_img

    var nonveg8 = document.createElement("p")
    nonveg8.textContent = ele.nonveg + " " + ele.Serves
    nonveg8.style.fontSize = "12px"
    nonveg8.style.lineHeight = "22px";
    nonveg8.style.fontWeight = "400"


    var price8 = document.createElement("p")
    price8.textContent = "₹" + ele.price
    price8.style.fontSize = "16px"
    price8.style.lineHeight = "24px";
    price8.style.fontWeight = "600"

    var Description8 = document.createElement("p")
    Description8.textContent = ele.description
    Description8.style.fontStyle = "normal"
    Description8.style.fontSize = "14px"
    Description8.style.lineHeight = "24px";
    Description8.style.fontWeight = "400"

    var btn8 = document.createElement("button")
    btn8.innerHTML = "Add to cart "
    btn8.setAttribute("id", "btn8")
    btn8.style.color = "white"
    btn8.style.fontSize = "14px"
    btn8.style.padding = "15px 60px"
    btn8.style.backgroundColor = "#E71A41"
    btn8.style.borderRadius = "25px"
    btn8.style.border = "0px"
    btn8.style.textAlign = "center"
    btn8.style.marginLeft = "20px"

    btn8.addEventListener("click", function () {
        addtocart(ele)
    });

    div8.append(image, item8, nonveg8, price8, Description8, btn8)
    document.querySelector("#alignhere8").append(div8)
});



function addtocart(ele) {
    cartdata.push(ele)
    console.log(cartdata)
    localStorage.setItem("storedata", JSON.stringify(cartdata))
    // window.open("cart.html")
}