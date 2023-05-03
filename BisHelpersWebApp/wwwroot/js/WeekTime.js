
///////////////////////////////////////////////////////

let datenow = new Date();

let week4 = new Date("10/31/2022");
let week5 = new Date("11/10/2022");
let week6 = new Date("11/17/2022");
let week7 = new Date("11/24/2022");
let week8 = new Date("12/01/2022");
let week9 = new Date("12/08/2022");
let week10 = new Date("12/15/2022");
let week11 = new Date("12/22/2022");
let week12 = new Date("12/29/2022");
let week13 = new Date("01/05/2023");

let weekBoxs4 = document.getElementById("weekBoxs4");
let weekBoxs5 = document.getElementById("weekBoxs5");
let weekBoxs6 = document.getElementById("weekBoxs6");
let weekBoxs7 = document.getElementById("weekBoxs7");
let weekBoxs8 = document.getElementById("weekBoxs8");
let weekBoxs9 = document.getElementById("weekBoxs9");
let weekBoxs10 = document.getElementById("weekBoxs10");
let weekBoxs11 = document.getElementById("weekBoxs11");
let weekBoxs12 = document.getElementById("weekBoxs12");
let weekBoxs13 = document.getElementById("weekBoxs13");

if (datenow >= week4) {
  weekBoxs4.classList.remove("hide");
}
if (datenow.getTime() >= week5.getTime()) {
  weekBoxs5.classList.remove("hide");
}
if (datenow >= week6) {
  weekBoxs6.classList.remove("hide");
}
if (datenow >= week7) {
  weekBoxs7.classList.remove("hide");
}
if (datenow >= week8) {
  weekBoxs8.classList.remove("hide");
}
if (datenow >= week9) {
  weekBoxs9.classList.remove("hide");
}
if (datenow >= week10) {
  weekBoxs10.classList.remove("hide");
}
if (datenow >= week11) {
  weekBoxs11.classList.remove("hide");
}
if (datenow >= week12) {
  weekBoxs12.classList.remove("hide");
}
if (datenow >= week13) {
  weekBoxs13.classList.remove("hide");
}

