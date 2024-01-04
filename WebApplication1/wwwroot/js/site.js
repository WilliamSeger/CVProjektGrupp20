document.querySelectorAll('#showContentButton').forEach(function (button) {
    button.addEventListener('click', function () {
        var contentId = this.getAttribute('data-content-id');
        var contentRow = document.getElementById('contentRow_' + contentId);

        if (contentRow.style.display === 'none') {
            contentRow.style.display = 'table-row';
        } else {
            contentRow.style.display = 'none';
        }
    });
});

const button = document.getElementById("addQual");
button.addEventListener('click' function () {

})