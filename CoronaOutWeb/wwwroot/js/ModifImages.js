
const nombreMaxPhoto = $("#nbPhotos").val();

const tailleMaxImage = $("#tailleMaxImage").val();

var nombrePreviewImage = $("#PhotosPreview").find("ul").length;

var logoSelect = document.getElementById("logo-label"),
    logoPreview = document.getElementById("logoPreview");

var photoPreview = document.getElementById("PhotosPreview");




$(document).ready(function () {
    $("#logo-input").on("change", function () {
        if (fileName !== null) {
            //vérifie la taille du fichier
            if (checkSize(this)) {
                var fileName = $(this).val().split("\\").pop();
                $(this).next("#logo-label").html(fileName);
            }
            else {
                toastRMaxSize();
            }

        }
        else {
            $(this).next("#logo-label").innerHTML = "Sélectionner l'image";
        }
    })

    $("[id*='photo-input-']").on("change", function () {
        if (fileName !== null) {
            //vérifie la taille du fichier
            if (checkSize(this)) {
                var num = $(this).attr('id').split("-")[2];
                var labelTextBox = "#photo-label-" + num;

                //affiche le nom du fichier dans la textbox
                var fileName = $(this).val().split("\\").pop();
                $(this).next(labelTextBox).html(fileName);


                //affiche le premier bouton caché
                AffichePremierPhotoUpload()
            }
            else {
                toastRMaxSize();
            }
        }
    })

})

function AffichePremierPhotoUpload() {

    //affiche le premier bouton caché
    var nextButton = $("div[style*='display: none;']").filter("[id^='photo-']")
    if (nextButton.length) {
     
        var i = 0;
        var testKeepRunning = true;
        while (i < nextButton.length && testKeepRunning)
        {
            var number = nextButton[i].id.split("-")[1];
            var photoPreviewUl = "#ulPreviewPhoto-" + number;

            if ($(photoPreviewUl).length ==0) {
                var photoShow = "#photo-" + number;
                $(photoShow).show();
                testKeepRunning = false;
            }
            i++;
        }

    }
}


window.onload = function () {
  
    //cache tous les boutons
    for (var i = 0; i < nombreMaxPhoto; i++) {
        var photoId = "#photo-" + (i);
        $(photoId).hide();
        
    }

    var Previewlogo = "#ulPreviewLogo"
    if ($(Previewlogo).length !== 0) {
        var logocontainer = "#logo-container";
        $(logocontainer).hide();
    }

    //affiche le premier bouton caché
    AffichePremierPhotoUpload()


}

function checkSize(element) {
    if (element.files[0].size > tailleMaxImage) {

        var num = element.id.split("-")[2];
        //supprime le fichier
        supprimerPhoto(num)

        return false;
    }
    else
        return true;
}



function toastRMaxSize() {

    var tailleMaxImageLisible = tailleMaxImage / 1000;
    var message = "La taille maximum autorisée pour une image est de " + tailleMaxImageLisible + " Ko";
    toastr["error"](message, "Image trop lourde");

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
    }
}


function handleLogo(files) {

    if (files[0].size <= tailleMaxImage) {
        logoPreview.innerHTML = "";


        var list = document.createElement("ul");
        list.id = "ulPreviewLogo";
        list.className = "list-group";
        logoPreview.appendChild(list);

        var li = document.createElement("li");
        li.id = "";
        li.className = "list-group-item d-flex";
        list.appendChild(li);

        var div = document.createElement("div");
        div.id = "divReviewLogo";
        logoPreview.appendChild(div);

        var img = document.createElement("img");
        img.src = window.URL.createObjectURL(files[0]);
        img.height = 120;
        img.onload = function () {
            window.URL.revokeObjectURL(this.src);
        }
        img.className = " align-self-start p-2";
        li.appendChild(img);

        var buttonDelete = document.createElement("div");
        buttonDelete.className = "btn btn-danger align-self-center ml-auto p2";
        buttonDelete.innerHTML = "Supprimer";
        buttonDelete.onclick = supprimerLogo;
        buttonDelete.id = "deleteLogo";
        li.appendChild(buttonDelete);
    }
}


function handlePhotos(files, nummer) {

    if (files[0].size <= tailleMaxImage) {

        var list = document.createElement("ul");
        list.id = "ulPreviewPhoto-" + nummer;
        list.className = "list-group";
        photoPreview.appendChild(list);

        var li = document.createElement("li");
        li.id = "";
        li.className = "list-group-item d-flex";
        list.appendChild(li);

        var img = document.createElement("img");
        img.src = window.URL.createObjectURL(files[0]);
        img.height = 120;
        img.className = " align-self-start p-2";
        img.onload = function () {
            window.URL.revokeObjectURL(this.src);
        }
        li.appendChild(img);

        var buttonDelete = document.createElement("div");
        buttonDelete.className = "btn btn-danger align-self-center ml-auto p2";
        buttonDelete.innerHTML = "Supprimer";
        buttonDelete.onclick = supprimerPhoto;
        buttonDelete.id = "deletePhoto-" + nummer;
        li.appendChild(buttonDelete);


    }
}

function supprimerLogo() {


    var logocontainer = "#logo-container";
    $(logocontainer).show();


    //supprime le File
    var controle = $("#logo-input");
    controle.replaceWith(controle.val('').clone(true));

    logoSelect.innerHTML = "Sélectionner l'image";
    logoPreview.innerHTML = "";


}

function supprimerPhoto(num) { 


    if (num.target) { 
    var num = $(this).attr('id').split("-")[1];
    }

    var idName = "#photo-input-" + num;

    //supprime le File
    var controle = $(idName);
    if ($(controle)!==null) {
        controle.replaceWith(controle.val('').clone(true));
    }

    //supprime le path si il existe
    var pathImageExistantes = "#IsToBeDeleted" + num;
    console.log($(pathImageExistantes).val());
    if ($(pathImageExistantes).length) {
        $(pathImageExistantes).val(true);
    }


    //supprime la preview
    var previewName = "ulPreviewPhoto-" + num;

    //supprime la preview
    const element = document.getElementById(previewName);

    if (element !==null) {
        element.parentNode.removeChild(element);
    }
    

    reinitializebutton(num);

}


function reinitializebutton(num) {

    //reinitialise le texte dans le champ
    var selectorName = "photo-label-" + num;
    var labelTextBox = document.getElementById(selectorName);
    labelTextBox.innerHTML = "Sélectionner l'image";




}