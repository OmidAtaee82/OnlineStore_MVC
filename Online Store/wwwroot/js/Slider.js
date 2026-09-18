const images = [
    "./img/251.png",
    "./img/252.png",
    "./img/253.png",
    "./img/254.png"
];

const caroselImage = document.getElementById("carusel-img");
const nextBtn = document.getElementById("next-btn");
const prevBtn = document.getElementById("prev-btn");

let currentIndex = 0;

function ShowImage(direction) {

    caroselImage.classList.remove(
        "slide-next",
        "slide-prev"
    );

    void caroselImage.offsetWidth;

    caroselImage.src = images[currentIndex];

    if (direction === "next") {
        caroselImage.classList.add("slide-next");
    }

    if (direction === "prev") {
        caroselImage.classList.add("slide-prev");
    }

}

nextBtn.addEventListener("click", function () {

    currentIndex++;

    if (currentIndex >= images.length) {
        currentIndex = 0;
    }

    ShowImage("next");
});

prevBtn.addEventListener("click", function () {

    currentIndex--;

    if (currentIndex < 0) {
        currentIndex = images.length - 1;
    }

    ShowImage("prev");
});


// setInterval(function () {

//     currentIndex++;

//     if (currentIndex >= images.length) {
//         currentIndex = 0;
//     }

//     ShowImage("next");

// }, 5000);