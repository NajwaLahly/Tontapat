// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


// Get the modal
/*var modal = document.getElementById("Search-modal");

// Get the button that opens the modal
var btn = document.getElementById("Search-modal-button");

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close-modal")[0];

// When the user clicks on the button, open the modal
btn.onclick = function () {
    modal.style.display = "block";
}

// When the user clicks on <span> (x), close the modal
span.onclick = function () {
    modal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
} */



//FONCTION DE CALCUL DE LA DATE DE FIN



var datesFin = document.getElementById("datefin");

var labelFin = document.getElementById("label-fin");

function getDateFinMinMax() {

    const HECTARE_TO_M2 = 10000;
    const POWER = 3;

    const MIN_SURFACE_ANIMAL_LENTE = 50;
    const MAX_SURFACE_ANIMAL_LENTE = 1000;
    const MIN_SURFACE_ANIMAL_MOYEN = 30;
    const MAX_SURFACE_ANIMAL_MOYEN = 49;
    const MIN_SURFACE_ANIMAL_RAPIDE = 10;
    const MAX_SURFACE_ANIMAL_RAPIDE = 29;

    const SURFACE_ANIMAL_JOUR = 5;

    const MIN_DUREE_TONTE_LENTE = MIN_SURFACE_ANIMAL_LENTE / SURFACE_ANIMAL_JOUR;
    const MAX_DUREE_TONTE_LENTE = MAX_SURFACE_ANIMAL_LENTE / SURFACE_ANIMAL_JOUR;
    const MIN_DUREE_TONTE_MOYENNE = MIN_SURFACE_ANIMAL_MOYEN / SURFACE_ANIMAL_JOUR;
    const MAX_DUREE_TONTE_MOYENNE = MAX_SURFACE_ANIMAL_MOYEN / SURFACE_ANIMAL_JOUR;
    const MIN_DUREE_TONTE_RAPIDE = MIN_SURFACE_ANIMAL_RAPIDE / SURFACE_ANIMAL_JOUR;
    const MAX_DUREE_TONTE_RAPIDE = MAX_SURFACE_ANIMAL_RAPIDE / SURFACE_ANIMAL_JOUR;

    var terrainSuperficie = document.getElementById("1").value;

    var idTypeTonte = document.getElementById("tonte-select").value;

    var dateDebut = new Date(document.getElementById("datedebut").value);

    var durees = [];

    switch (idTypeTonte) {
        case "1":

            durees[0] = MIN_DUREE_TONTE_LENTE;
            durees[1] = MAX_DUREE_TONTE_LENTE;
            break;
        case "2":
            durees[0] = MIN_DUREE_TONTE_MOYENNE;
            durees[1] = MAX_DUREE_TONTE_MOYENNE;
            break;
        case "3":
            durees[0] = MIN_DUREE_TONTE_RAPIDE;
            durees[1] = MAX_DUREE_TONTE_RAPIDE;
            break;
        case "4":
            durees[0] = MIN_DUREE_TONTE_LENTE;
            durees[1] = MAX_DUREE_TONTE_LENTE;
            break;
    }
    var terrainSuperficie = document.getElementById(document.getElementById("terrain-superficie").value).value;
    durees[0] += Math.ceil(Math.log(Math.pow(terrainSuperficie * HECTARE_TO_M2, POWER)) / 2);
    durees[1] += Math.ceil(Math.log(Math.pow(terrainSuperficie * HECTARE_TO_M2, POWER)) / 2);

    var dateFin1 = getYYYYMMDD(addDays(dateDebut, durees[0]));
    var dateFin2 = getYYYYMMDD(addDays(dateDebut, durees[1]));
    datesFin.setAttribute("min", dateFin1);
    datesFin.setAttribute("max", dateFin2);
    datesFin.setAttribute("value", getYYYYMMDD(addDays(dateDebut, ((durees[0] + durees[1]) / 2))));

    datesFin.removeAttribute("disabled");
    labelFin.innerHTML = "Date de fin (entre le " + dateFin1 + " et le " + dateFin2 + ") : ";
    document.getElementById("send").removeAttribute("disabled");
}

function addDays(date, days) {
    var result = new Date(date);
    result.setDate(result.getDate() + days);
    return result;
}

function getYYYYMMDD(d0) {
    const d = new Date(d0);
    return new Date(d.getTime() - d.getTimezoneOffset() * 60 * 1000).toISOString().split('T')[0];

}

//export { getDateFinMinMax }
