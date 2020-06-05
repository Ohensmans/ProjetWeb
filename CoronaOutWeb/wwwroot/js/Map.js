$(document).ready(function () {

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
            console.log(obj);
            var lat = obj.Latitude;
            var long = obj.Longitude;
            var nom = obj.Nom;
            var nomUrl = obj.NomUrl;
            var estOuvert = obj.estOuvert;

            var checkOuverture = "L'établissement est fermé";
            if (estOuvert) {
                checkOuverture = "L'établissement est ouvert"
            }

            var marker = L.marker([lat, long]).addTo(mymap);
            marker.bindPopup("<b>"+nom+"</b><br> <a href=Etablissement\\"+nomUrl+">Détails</a>");
            
        })
    })

})



/*var marker = L.marker([50.8456, 4.3524]).addTo(mymap);

marker.bindPopup("<b>Hello world!</b><br>I am a popup.");

var popup = L.popup();

function onMapClick(e) {
    popup
        .setLatLng(e.latlng)
        .setContent("You clicked the map at " + e.latlng.toString())
        .openOn(mymap);
}

mymap.on('click', onMapClick);
*/

