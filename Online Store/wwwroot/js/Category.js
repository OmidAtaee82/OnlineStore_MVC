// filter product
const minRange = document.getElementById("minRange");
const maxRange = document.getElementById("maxRange");

const minPrice = document.getElementById("minPrice");
const maxPrice = document.getElementById("maxPrice");

function updatePrice() {

    let minValue = Number(minRange.value);
    let maxValue = Number(maxRange.value);

    if (minValue > maxValue) {
        minRange.value = maxValue;
        minValue = maxValue;
    }

    minPrice.innerText = minValue + "تومان";
    maxPrice.innerText = maxValue + "تومان";

}

updatePrice();

console.log("omid");

minRange.addEventListener("input", updatePrice);
maxRange.addEventListener("input", updatePrice);