function fun1(event) {

    if (event.target.value.length != 0 || event.target.value.length != 10) {
        document.querySelector("#error").src = "https://login.kfc.co.in/auth/resources/1vkce/login/kfcIndiaLoginUIDev_2021_10_27_16_49/images/Error.svg"
        document.querySelector(".errorText").innerText = "Please enter a valid 10-digit  mobile number";
    }
    if (event.target.value.length == 10) {
        document.querySelector("#error").src = ""
        document.querySelector(".errorText").innerText = "";


    }


}

document.querySelector("form").addEventListener("submit", myFun);
var mob = []

function goBack() {
    window.location.href = ""

}
function myFun() {
    event.preventDefault();
    var phone = document.querySelector("#phNum").value;
    console.log(phone)
    if (phone.length == 10) {
        mob.push(phone);
        localStorage.setItem("mobData", JSON.stringify(mob))
        window.location.href = "otp.html"
    }
}