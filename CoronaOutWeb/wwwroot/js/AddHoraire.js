$("#addHoraire").on('click', function () {
    $.ajax({
        async: true,
        data: $("#form").serialize(),
        type: "POST",
        url: "/AdministrationEtablissement/AddHoraire",
        success: function (partialView) {

            console.log("charge");
            $("#horaire-container").html(partialView);

        }
    });
});





$("#deleteHoraire-0").on('click', function () {

    if ($("tr").length > 1) {

        var idHoraire = $(this).attr('id').split("-")[1];

        vmForm = $("#form").serialize();
        vmForm += '&id=' + idHoraire;

        $.ajax({
            async: true,
            data: vmForm,
            type: "DELETE",
            url: "/AdministrationEtablissement/DeleteHoraire",
            success: function (partialViewDelete) {
                console.log("delete");
                console.log(partialViewDelete);
                $("#horaire-container").html(partialViewDelete);


            }
        })
    }
    

})

/*
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

$(document).ready(function () {
    addButtonDelete()
});*/






