
$(document).ready(function () {
    document.querySelector('meta[property="og:url"]').setAttribute("content", document.URL);
    document.querySelector('meta[property="og:title"]').setAttribute("content", document.getElementById("Title").value);
    document.querySelector('meta[property="og:description"]').setAttribute("content", document.getElementById("Decription").value);
    document.querySelector('meta[property="og:image"]').setAttribute("content", document.getElementById("Image").value);
    $(".fb-share-button").attr('data-href', document.URL);

    var textTwt = "" + document.getElementById("Title").value;
    var hashTwt = "CoronaOut," + document.getElementById("Decription").value;

    $("#linkedinButton").attr('data-url',document.URL);

    twttr.widgets.createShareButton(document.URL, document.querySelector("[id*='tweet']"),
        {
            text: textTwt,
            hashtags: hashTwt,
            lang: "fr"
        });
});


(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "https://connect.facebook.net/en_US/sdk.js#xfbml=1&version=v3.0";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));

