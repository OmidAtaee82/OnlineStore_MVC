document.querySelectorAll(".persian-number").forEach(element => {
    element.textContent = element.textContent.replace(/\d/g, digit => {
        return "۰۱۲۳۴۵۶۷۸۹"[digit];
    });
});


const accountBtn = document.getElementById("accountBtn");
const accountMenu = document.getElementById("accountMenu");

accountBtn.addEventListener("click", function () {

    accountMenu.classList.toggle("hidden");

});