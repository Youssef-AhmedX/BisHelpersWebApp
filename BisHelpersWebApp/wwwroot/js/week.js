let accordion = document.getElementById("weekBoxs");
let accordionl = document.getElementsByClassName("weekBoxs");
let weekly = document.getElementsByClassName("weekly");
// console.log(weekly)
for (let i = 0; i < accordionl.length; i++) {
  weekly[i].addEventListener("click", function () {
    accordionl[i].classList.toggle('active');
    auditing[i].classList.remove('active');
    cost[i].classList.remove('active');
    database[i].classList.remove('active');
    ecommerce[i].classList.remove('active');
    communication[i].classList.remove('active');
    HRM[i].classList.remove('active');
  })
}
let auditing = document.getElementsByClassName('auditing');
let cost = document.getElementsByClassName('cost');
let database = document.getElementsByClassName('database');
let ecommerce = document.getElementsByClassName('e-commerce');
let communication = document.getElementsByClassName('communication');
let HRM = document.getElementsByClassName('HRM');
// console.log(auditing)
for (let i = 0; i < auditing.length; i++) {
  auditing[i].addEventListener("click", function () {
    auditing[i].classList.toggle('active')
  })
}
for (let i = 0; i < cost.length; i++) {
  cost[i].addEventListener("click", function () {
    cost[i].classList.toggle('active')
  })
}
for (let i = 0; i < database.length; i++) {
  database[i].addEventListener("click", function () {
    database[i].classList.toggle('active')
  })
}
for (let i = 0; i < ecommerce.length; i++) {
  ecommerce[i].addEventListener("click", function () {
    ecommerce[i].classList.toggle('active')
  })
}
for (let i = 0; i < communication.length; i++) {
  communication[i].addEventListener("click", function () {
    communication[i].classList.toggle('active')
  })
}
for (let i = 0; i < HRM.length; i++) {
  HRM[i].addEventListener("click", function () {
    HRM[i].classList.toggle('active')
  })
}

