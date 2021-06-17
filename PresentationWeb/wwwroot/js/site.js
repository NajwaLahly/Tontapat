// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


// Write your JavaScript code.


/*// Get the modal
var modal = document.getElementById("Search-modal");

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
} 
*/

// Stars rating


const starsTotal = 5;




function getRating(rating) {


    const starPercentage = (rating / starsTotal) * 100;


    const starPercentageRounded = `${Math.round(starPercentage / 10) * 10}%`;


    document.querySelector(`.rating .stars-inner`).style.width = starPercentageRounded;


   /* document.querySelector(`.rating .number-rating`).innerHTML = rating;*/
}

export { getRating }