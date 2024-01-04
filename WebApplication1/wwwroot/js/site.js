//Visar/döljer css som gör att meddelandeinnehåll kan visas utan att laddas in en extra gång 
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

//Tar bort success-messages efter några sekunder per automatik
window.setTimeout(function () {
    $(".alert").fadeTo(500, 0).slideUp(500, function () {
        $(this).remove();
    });
}, 3000);

/*const button = document.getElementById("addQual");
button.addEventListener('click' function () {

})*/