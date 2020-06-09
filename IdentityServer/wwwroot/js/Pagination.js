
var table = table = document.getElementById("myTable");
var nbRow = table.rows.length;
const nbRowMaxParPage = 10;
var nbPage = Math.trunc((nbRow-1) / nbRowMaxParPage);
if ((nbRow-1) % nbRowMaxParPage > 0) {
    nbPage++;
}


function nbPagination(numPage) {

    $(".pagination").children(".paginationButtonNum").hide();

    var pageActive;

    var numLoop;

    if (numPage <= 1) {
        numLoop = 1;
        pageActive = 1;
    }
    else if (numPage >= nbPage) {
        if (numPage >= 3) {
            pageActive = 3;
            numLoop = numPage - 2;
        }
        else {
            pageActive = numPage;
            numLoop = 1;
        }

    }
    else {
        pageActive = 2;
        numLoop = numPage - 1;
    }


    for (var i = 1; (i < 4 && i <= nbPage); i++) {
        var num = numLoop -1 +i;
        $(".pagination").children()[i].style.display = '';
        $(".pagination").children()[i].innerHTML = num;
        
    }

    
    $(".pagination").children().removeClass("active");
    $(".pagination").children()[pageActive].className = "active"; 
}

function showRows(numPage) {


    var rows = table.rows;

    for (var i = 1; i < nbRow; i++) {
        rows[i].style.display = 'none';
    }

    var firstRow = ((numPage - 1) * nbRowMaxParPage) + 1;
    var lastRow = ((numPage) * nbRowMaxParPage) + 1;

    for (var i = firstRow; i < lastRow && i < nbRow; i++) {
        rows[i].style.display = '';
        console.log[i];
    }

}

$(".paginationButtonNum").click(function () {

    var num = this.innerHTML;

    if (num > 0 && num < 4) {
        nbPagination(num);
        showRows(num);
    }
})

$("#paginationButtonPrevious").click(function () {

    var num = $(".pagination").children(".active")[0].innerHTML;

    if (num <= 1) {
        num = 1;
    }
    else {
        num--;
    }

    nbPagination(num);
    showRows(num);

})

$("#paginationButtonNext").click(function () {

    var num = $(".pagination").children(".active")[0].innerHTML;

    if (num >= nbPage) {
        num = nbPage;
    }
    else {
        num++;
    }

    nbPagination(num);
    showRows(num);

})

$(document).ready(function () {
    //initialise la pagination
    nbPagination(1);
    showRows(1);
});



