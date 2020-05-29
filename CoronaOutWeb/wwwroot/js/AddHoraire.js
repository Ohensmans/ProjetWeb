$("#addHoraire").on('click', function () {
    $.ajax({
        async: true,
        data: $("#form").serialize(),
        type: "POST",
        url: "/AdministrationEtablissement/AddHoraire",
        success: function (partialView) {
            console.log("partialView: " + partialView);

            var row = document.createElement("tr");
            $('#tab-horaires')[0].appendChild(row);
            $('tr').last().html(partialView);

            var buttonDeleteHoraire = document.createElement("td");
            buttonDeleteHoraire.className = "btn btn-danger align-text-bottom";
            buttonDeleteHoraire.innerHTML = "Supprimer";
            buttonDeleteHoraire.onclick = supprimerLogo;
            buttonDeleteHoraire.id = "deleteHoraire";
            row.appendChild(buttonDeleteHoraire);
        }
    });
});


function supprimerLogo() {

    $(this).parent("tr").remove();  
}





