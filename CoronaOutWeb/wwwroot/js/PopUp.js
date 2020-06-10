$(document).ready(function () {
    $.get("http://localhost:5000/News/GetPopUp", function (data) {


        var myWindow = window.open("", "News", "width=800,height=500");
        myWindow.document.write(data);
    })

});
