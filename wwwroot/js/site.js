// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var slideIndex = 0;
showSlides();

var bleep= new Audio() ;
var slidenav= new Audio() ;
bleep.src = "/css/audio/Sound.mp3";
slidenav.src ="/css/audio/Navsound.mp3";

var audio  = new Audio('/css/audio/Buttonbiasa.mp3');
$(".buttonbleep").mousedown(function() {
  audio.load();
  audio.play();
});


function showSlides() {
  var i;
  var slides = document.getElementsByClassName("mySlides");
  var dots = document.getElementsByClassName("dot");
  for (i = 0; i < slides.length; i++) {
    slides[i].style.display = "none";
  }
  for (i = 0; i < dots.length; i++) {
    dots[i].className = dots[i].className.replace(" active", "");
  }
  slideIndex++;
  if (slideIndex > slides.length) {slideIndex = 1}
  slides[slideIndex-1].style.display = "block";
  dots[slideIndex-1].className += " active";
  setTimeout(showSlides, 2000); // Change image every 2 seconds
} 

function readURL(input) {
  if(input.files && input.files[0]) {
    let reader = new FileReader();

    reader.onload = function (e) {
      $("img#imgpreview").attr("src", e.target.result).width(200).height(200);
    }
    
    reader.readAsDataURL(input.files[0]);
  }
}
$( ".change" ).on("click", function() {
  if( $( "body" ).hasClass( "dark-mode" )) {
      $( "body" ).removeClass( "dark-mode" );
      $( ".change" ).text( "OFF" );
  } else {
      $( "body" ).addClass( "dark-mode" );
      $( ".change" ).text( "ON" );
  }
});

var delay = 5000;;

$(document).ready(function(){
$(".preloader").fadeIn(3000).delay(3000).fadeOut();
})

