function openModalBrand(id , name , image) {

    document.getElementById("delete-brand").classList.remove("hidden");
    document.getElementById("title-delete").innerText = name;
    document.getElementById("brand_img").src = image;
    document.getElementById("delete-form").action = `/admin/brands/delete/${id}`;
}


document.getElementById("close-modal").addEventListener("click", function () {
    document.getElementById("delete-brand").classList.add("hidden");
})