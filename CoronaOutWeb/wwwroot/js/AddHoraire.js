$("#addHoraire").on('click', function () {
    $.ajax({
        async: true,
        data: $("#form").serialize(),
        type: "POST",
        url: "/AdministrationEtablissement/AddHoraire",
        success: function (partialView) {

            $("#horaire-container").html(partialView);

        }
    });
    infoHoraire();
});


function infoHoraire() {

    Command: toastr["info"]("Une journée termine à 23h59", "Horaires")

    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }}





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








