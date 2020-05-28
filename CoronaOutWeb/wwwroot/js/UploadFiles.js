var logoSelect = document.getElementById("logo-label"),
    logoPreview = document.getElementById("logoPreview");

var photoPreview = document.getElementById("PhotosPreview");

const nombreMaxPhoto = $("#nbPhotos").val();

const tailleMaxImage = $("#tailleMaxImage").val();


$(document).ready(function ()
{
    $("#logo-input").on("change", function ()
    {
        if (fileName !== null) {
            var fileName = $(this).val().split("\\").pop();
            $(this).next("#logo-label").html(fileName);
        }
        else {
            $(this).next("#logo-label").innerHTML = "Sélectionner l'image";
        }
    })

    $("[id*='photo-input-']").on("change", function () {
        if (fileName !== null)
        {
            //vérifie la taille du fichier
            if (checkSize(this)) {
                var num = $(this).attr('id').split("-")[2];
                var labelTextBox = "#photo-label-" + num;

                //affiche le nom du fichier dans la textbox
                var fileName = $(this).val().split("\\").pop();
                $(this).next(labelTextBox).html(fileName);

                //affiche le premier bouton caché
                var nextButton = $("div[style*='display: none;']").filter("[id^='photo-']").first();
                if (nextButton !== null) {
                    nextButton.show();
                }
            }
            else {
                toastRMaxSize();
            }
        }

    })   
});

window.onload = function ()
{
    //affiche uniquement le premier bouton upload pour les photos
    console.log($(this));
    for (var i = 1; i < nombreMaxPhoto; i++) {
        var logoId = "#photo-" + i;
        $(logoId).hide();
    }
}

window.URL = window.URL || window.webkitURL;

function checkSize(element) {
    if (element.files[0].size > tailleMaxImage) {

        //supprime le fichier
        element.value = "";

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

    if (!files.length)
    {
        logoPreview.innerHTML = "<p>Aucun fichier sélectionné !</p>";
    }
    else
    {
        if (files[0].size <= tailleMaxImage) {
            logoPreview.innerHTML = "";
            var list = document.createElement("ul");
            list.id = "ulReviewLogo";
            logoPreview.appendChild(list);

            var li = document.createElement("li");
            li.id = "";
            list.appendChild(li);

            var img = document.createElement("img");
            img.src = window.URL.createObjectURL(files[0]);
            img.height = 60;
            img.onload = function () {
                window.URL.revokeObjectURL(this.src);
            }
            li.appendChild(img);

            var buttonDelete = document.createElement("div");
            buttonDelete.className = "btn btn-danger";
            buttonDelete.innerHTML = "Supprimer";
            buttonDelete.onclick = supprimerLogo;
            buttonDelete.id = "deleteLogo";
            li.appendChild(buttonDelete);

        }
    }
}

function handlePhotos(files, nummer) {

    if (files[0].size <= tailleMaxImage) {

        if (photoPreview.children[0].tagName == "P") {
            photoPreview.innerHTML = "";
        }
        var list = document.createElement("ul");
        list.id = "ulReviewPhoto-" + nummer;
        photoPreview.appendChild(list);

        var li = document.createElement("li");
        li.id = "";
        list.appendChild(li);

        var img = document.createElement("img");
        img.src = window.URL.createObjectURL(files[0]);
        img.height = 60;
        img.onload = function () {
            window.URL.revokeObjectURL(this.src);
        }
        li.appendChild(img);

        var buttonDelete = document.createElement("div");
        buttonDelete.className = "btn btn-danger";
        buttonDelete.innerHTML = "Supprimer";
        buttonDelete.onclick = supprimerPhoto;
        buttonDelete.id = "deletePhoto-" + nummer;
        li.appendChild(buttonDelete);
    }   
}



function supprimerLogo() {

    //supprime le File
    var controle = $("#logo-input");
    controle.replaceWith(controle.val('').clone(true));

    logoPreview.innerHTML = "<p>Aucun fichier sélectionné !</p>";
    logoSelect.innerHTML = "Sélectionner l'image";
}

function supprimerPhoto() {
    
    var num = $(this).attr('id').split("-")[1];
    var idName = "#photo-input-" + num;

    //supprime le File
    var controle = $(idName);
    controle.replaceWith(controle.val('').clone(true));

    //supprime la preview
    var previewName = "ulReviewPhoto-" + num;

    //supprime la preview
    const element = document.getElementById(previewName);
    element.parentNode.removeChild(element);

    reinitializebutton(num);

    checkEmptyPreview();
}

function checkEmptyPreview() {

    if (!photoPreview.children.length) {
        photoPreview.innerHTML = "<p>Aucune image sélectionnée !</p>";
    }
}

function reinitializebutton(num) {

    //reinitialise le texte dans le champ
    var selectorName = "photo-label-" + num;
    var labelTextBox = document.getElementById(selectorName);
    labelTextBox.innerHTML = "Sélectionner l'image"; 

    //cache le button si il en reste plus d'un
    var lBoutonDesactives = $("div[style*='display: none;']").filter("[id^='photo-']");

    if (lBoutonDesactives.length !== (nombreMaxPhoto-1)) {
        var bouton = "#photo-" + num;
        $(bouton).hide();
    }
}

