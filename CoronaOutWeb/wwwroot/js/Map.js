
$(document).ready(function () {

    var greenIcon = L.icon({
        iconUrl: 'img/markers/markerVert.png',

        iconSize: [25, 35], // size of the icon
        iconAnchor: [12, 35], // point of the icon which will correspond to marker's location
        popupAnchor: [-3, -40] // point from which the popup should open relative to the iconAnchor
    });

    var orangeIcon = L.icon({
        iconUrl: 'img/markers/markerOrange.png',

        iconSize: [25, 35], // size of the icon
        iconAnchor: [12, 35], // point of the icon which will correspond to marker's location
        popupAnchor: [-3, -40] // point from which the popup should open relative to the iconAnchor
    });



    var userAuthorized = $("#isLogged").val();

    var mapbox = $("#MapBox").val();

    var mymap = L.map('mapid').setView([50.8456, 4.3524], 13);

    L.tileLayer('https://api.mapbox.com/styles/v1/{id}/tiles/{z}/{x}/{y}?access_token={accessToken}', {
        attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors, <a href="https://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
        maxZoom: 18,
        id: 'mapbox/streets-v11',
        tileSize: 512,
        zoomOffset: -1,
        accessToken: mapbox
    }).addTo(mymap);

    $.get("/Home/GetCoordinates", function (result) {
        $.each(result, function (i, loc) {
            var obj = JSON.parse(loc);
            var lat = obj.Latitude;
            var long = obj.Longitude;
            var nom = obj.Nom;
            var nomUrl = obj.NomUrl;
            var nbMinAvantFermeture = obj.nbMinAvantFermeture;

            var checkOuverture = "";
            var marker;

            if (userAuthorized == "True") {
                if (nbMinAvantFermeture !== 0) {
                    checkOuverture = "L'établissement ferme dans " + nbMinAvantFermeture + " minutes";
                    if (nbMinAvantFermeture <= 15) {
                        marker = L.marker([lat, long], { icon: orangeIcon }).addTo(mymap);
                    }
                    else if (nbMinAvantFermeture > 120) {
                        checkOuverture = "L'établissement est ouvert";
                        marker = L.marker([lat, long], { icon: greenIcon }).addTo(mymap);
                    }
                    else {
                        marker = L.marker([lat, long], { icon: greenIcon }).addTo(mymap);
                    }
                    marker.bindPopup("<b>" + nom + "</b><br> <a href=Etablissements\\Fiche\\" + nomUrl + ">Détails</a><br>" + checkOuverture);
                }
            }
            else {
                marker = L.marker([lat, long]).addTo(mymap);
                marker.bindPopup("<b>" + nom + "</b><br> <a href=Etablissements\\Fiche\\" + nomUrl + ">Détails</a>");    
            }
                   
        })
    })

    load();

})

function load() {
    setTimeout("window.open(self.location, '_self');", 900000);
}



