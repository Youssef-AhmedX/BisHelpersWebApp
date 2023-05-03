let btnFront = document.querySelector("#front-end");
let btnOne = document.querySelector("#one");
let btnBackOne = document.querySelector("#back-end-one");
let btnTwo = document.querySelector("#two");
let btnBackTwo = document.querySelector("#back-end-two");
let btnThree = document.querySelector("#three");

let backTwo = document.querySelector(".backTwo");
let backThree = document.querySelector(".backThree");
let front = document.querySelector(".front");

front.classList.add("hide");
backTwo.classList.add("hide");
backThree.classList.add("hide");

btnFront.onclick = function () {
  front.classList.remove("hide");
  backTwo.classList.add("hide");
  backThree.classList.add("hide");
  document.querySelector('#front-end-one').scrollIntoView({
    behavior: 'smooth'
  });
}

btnOne.onclick = function () {
  front.classList.remove("hide");
  backTwo.classList.add("hide");
  backThree.classList.add("hide");
}

btnBackOne.onclick = function () {
  backTwo.classList.remove("hide");
  front.classList.add("hide");
  backThree.classList.add("hide");
  document.querySelector('#back-two').scrollIntoView({
    behavior: 'smooth'
  });
}

btnTwo.onclick = function () {
  backTwo.classList.remove("hide");
  front.classList.add("hide");
  backThree.classList.add("hide");
}

btnBackTwo.onclick = function () {
  backThree.classList.remove("hide");
  front.classList.add("hide");
  backTwo.classList.add("hide");
  document.querySelector('#back-three').scrollIntoView({
    behavior: 'smooth'
  });
}

btnThree.onclick = function () {
  backThree.classList.remove("hide");
  front.classList.add("hide");
  backTwo.classList.add("hide");
}