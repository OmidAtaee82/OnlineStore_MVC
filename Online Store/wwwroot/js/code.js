document.querySelectorAll(".persian-number").forEach(element => {
    element.textContent = element.textContent.replace(/\d/g, digit => {
        return "۰۱۲۳۴۵۶۷۸۹"[digit];
    });
});