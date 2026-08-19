function openDeleteModal(id , name , image) {

    document.getElementById("delete-category").classList.remove("hidden");
    document.getElementById("category_name").innerText = name;
    document.getElementById("category_img").src = image;
    document.getElementById("delete-form").action = `/admin/categories/delete/${id}`;

}

document.getElementById("cancel-delete").addEventListener("click", function () {
    document.getElementById("delete-category").classList.add("hidden");
})