$(document).ready(function () {
    try {
        // Initialize Select2 on the gender select element
        $('.glass-select').select2();
    } catch (error) {
        // Handle the error gracefully
        console.error('An error occurred while initializing Select2:', error);
        // You can also perform any specific actions or fallbacks here
    }
});
