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








