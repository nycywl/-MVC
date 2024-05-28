document.addEventListener('DOMContentLoaded', function () {
    document.querySelectorAll('.show-more').forEach(function (button) {
        button.addEventListener('click', function () {
            var productDetails = this.closest('.product-details');
            productDetails.classList.toggle('expanded');
            this.textContent = productDetails.classList.contains('expanded') ? '顯示更少' : '顯示更多';
        });
    });
});
