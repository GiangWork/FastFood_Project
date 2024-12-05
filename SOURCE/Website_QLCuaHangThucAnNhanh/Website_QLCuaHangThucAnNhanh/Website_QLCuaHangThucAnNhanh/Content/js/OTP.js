document.querySelector(".different-number").addEventListener("click", fun2)
function fun2() {
    window.location.href = "OTP.html"
}
var timeleft = 180;
var downloadTimer = setInterval(function () {
    if (timeleft <= 0) {
        document.querySelector("#error").src = "https://login.kfc.co.in/auth/resources/1vkce/login/kfcIndiaLoginUIDev_2021_10_27_16_49/images/Error.svg"
        document.querySelector("#timerId").innerText = "Your code has expired!";
        document.querySelector("#timerId").style.color = "red"
    } else {
        document.querySelector("#timerId").innerText = "Your code will expire in" + " " + timeleft + " " + "secs";

    }
    timeleft -= 1;
}, 1000);

var a = Math.floor(Math.random() * 10000);
if (a < 1000) {
    a = a * 10;
}
alert("Your OTP is" + " " + a)


var mob = JSON.parse(localStorage.getItem("mobData"));
console.log(mob)
document.querySelector("#bb").append(mob)
document.querySelector("form").addEventListener("submit", myfun);
function myfun() {
    event.preventDefault();

    var inp1 = document.querySelector("#codeBox0").value;
    var inp2 = document.querySelector("#codeBox1").value;
    var inp3 = document.querySelector("#codeBox2").value;
    var inp4 = document.querySelector("#codeBox3").value;
    var str = inp1 + inp2 + inp3 + inp4;


    if (str == a) {
        alert("You'Ve SuccessFully Logged-In")
        window.location.href = "home.html"
    }
}