function openDeleteModal(id, name) {

    document.getElementById("delete-modal").classList.remove("hidden");

    document.getElementById("delete-text").innerText = `آیا از حذف ${name} اطمینان دارید ؟ `;


    document.getElementById("delete-form").action = `/admin/products/delete/${id}`;

}


document.getElementById("cancel-delete").addEventListener("click", function () {
    document.getElementById("delete-modal").classList.add("hidden");
});