
$('.form-control[data-val-required],.text-box[data-val-required]').on('change', function () {

    var nombresChampRequis = $('.form-control[data-val-required],.text-box[data-val-required]').length;
    console.log(nombresChampRequis);
    var nombreChampRemplis = 0;    
    $('.form-control[data-val-required],.text-box[data-val-required]').each(function () {       
        if ($(this).val() !== "") {
            nombreChampRemplis++;
            console.log(nombreChampRemplis);
        }
    });

    activeToastr(nombreChampRemplis, nombresChampRequis);

});


function activeToastr(nombreChampsRemplis, nombreChampsRequis) {

    const nombrePourcent = (nombreChampsRemplis / nombreChampsRequis) * 100;

    const nombrePourcentarrondi = nombrePourcent.toFixed(2);

    var message = "Vous êtes à " + nombrePourcentarrondi + " % de complétude";

    toastr["info"](message, "Complétude du formulaire")

    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
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
    }
}