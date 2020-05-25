$(document).ready(function ()
    {
    $("#logo-input").on("change", function ()
        {
            var fileName = $(this).val().split("\\").pop();
            $(this).next("#logo-label").html(fileName);
        })
});

window.URL = window.URL || window.webkitURL;

var fileSelect = document.getElementById("logo-label"),
    fileElem = document.getElementById("logo-input"),
    fileList = document.getElementById("logoPreview");

fileSelect.addEventListener("click", function (e) {
    if (fileElem) {
        fileElem.click();
    }
    e.preventDefault(); // empêche la navigation vers "#"
}, false);

function handleFiles(files) {
    if (!files.length) {
        fileList.innerHTML = "<p>Aucun fichier sélectionné !</p>";
    } else {
        fileList.innerHTML = "";
        var list = document.createElement("ul");
        fileList.appendChild(list);
        for (var i = 0; i < files.length; i++) {
            var li = document.createElement("li");
            list.appendChild(li);

            var img = document.createElement("img");
            img.src = window.URL.createObjectURL(files[i]);
            img.height = 60;
            img.onload = function () {
                window.URL.revokeObjectURL(this.src);
            }
            li.appendChild(img);
            var info = document.createElement("span");
            info.innerHTML = files[i].name + ": " + files[i].size + " bytes";
            li.appendChild(info);
        }
    }
}