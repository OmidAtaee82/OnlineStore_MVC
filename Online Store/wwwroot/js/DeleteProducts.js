function openModalProduct(id, name, image) {

    document.getElementById("delete-product").classList.remove("hidden");
    document.getElementById("product_name").innerText = name;
    document.getElementById("product_img").src = image;
    document.getElementById("delete-form").action = `/admin/products/delete/${id}`;

}


document.getElementById("cancel-delete").addEventListener("click", function () {
    document.getElementById("delete-product").classList.add("hidden");
})