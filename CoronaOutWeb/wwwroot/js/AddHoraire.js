$("#addHoraire").on('click', function () {
    $.ajax({
        async: true,
        data: $("#form").serialize(),
        type: "POST",
        url: "/AdministrationEtablissement/AddHoraire",
        success: function (partialView) {


            $("#horaire-container").html(partialView);

            addButtonDelete()
        }
    });
});



function supprimerHoraire() {

    var idHoraire = $(this).attr('id').split("-")[1];

    console.log(idHoraire);
    vmForm = $("#form").serialize();
    vmForm += '&id=' + idHoraire;
    console.log(vmForm);

    $.ajax({
        async: true,
        data: vmForm,
        type: "POST",
        url: "/AdministrationEtablissement/DeleteHoraire",
        success: function (partialView) { 
            console.log("yep");
            $("#horaire-container").html(partialView);

            addButtonDelete()
        }
    })

    //$(this).closest("tr").remove();
}

function addButtonDelete() {

    var id = 0;

    $("tr").each(function () {
        if (this.id !== "titre") {
            var cell = document.createElement("td");
            var buttonDeleteHoraire = document.createElement("label");
            buttonDeleteHoraire.className = "btn btn-danger align-text-bottom";
            buttonDeleteHoraire.innerHTML = "Supprimer";
            buttonDeleteHoraire.onclick = supprimerHoraire;
            buttonDeleteHoraire.id = "deleteHoraire-"+id;
            cell.append(buttonDeleteHoraire);
            $(this).append(cell);
            id++;
        }
    })
}





