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
      $("img#imgpreview").attr("src", e.target.result).width(150).height(150);
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

$(document).ready(function(){
  $('#hideshow').live('click', function(event) {        
    $('#content').toggle('show');
  });
})

$("#toggle").on("click", function(){
  $("#content").toggle();                 // .fadeToggle() // .slideToggle()
});

//Movement Animation to happen
const parallax = document.querySelector(".parallax");
//Items
const item = document.querySelector(".parallax img");
const category = document.querySelector(".productname");
const desc = document.querySelector(".parallax p");
const head = document.querySelector(".parallax h5");
const price = document.querySelector(".spanprice");
//Moving Animation Event
parallax.addEventListener("mousemove", (e) => {
  let xAxis = (window.innerWidth / 2 - e.pageX) / 25;
  let yAxis = (window.innerHeight / 2 - e.pageY) / 25;
  parallax.style.transform = `rotateY(${xAxis}deg) rotateX(${yAxis}deg)`;
});
//Animate In
parallax.addEventListener("mouseenter", (e) => {
  parallax.style.transition = "none";
  //Popout
  item.style.transform = "translateZ(50px)";
  category.style.transform = "translateZ(50px)";
  desc.style.transform = "translateZ(50px)";
  head.style.transform = "translateZ(50px)";
  price.style.transform = "translateZ(50px)";
});
//Animate Out
parallax.addEventListener("mouseleave", (e) => {
  parallax.style.transition = "all 0.5s ease";
  parallax.style.transform = `rotateY(0deg) rotateX(0deg)`;
  //Popback
  item.style.transform = "translateZ(0px)";
  category.style.transform = "translateZ(0px)";
  desc.style.transform = "translateZ(0px)";
  head.style.transform = "translateZ(0px)";
  price.style.transform = "translateZ(0px)";

});