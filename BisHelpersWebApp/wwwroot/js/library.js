let btnAssignment = document.querySelector("#Assignments");
let btnOne = document.querySelector("#one");
let btnSummarizes = document.querySelector("#Summarizes");
let btnTwo = document.querySelector("#two");
let btnlectures = document.querySelector("#lectures");
let btnThree = document.querySelector("#three");

let AssignmentsSupport = document.querySelector(".AssignmentsSupport");
let QuizzesAndsummarizes = document.querySelector(".QuizzesAndsummarizes");
let lecturesAndSectionsGuide = document.querySelector(".lecturesAndSectionsGuide");

AssignmentsSupport.classList.add("hide");
QuizzesAndsummarizes.classList.add("hide");
lecturesAndSectionsGuide.classList.add("hide");

btnAssignment.onclick = function () {
  AssignmentsSupport.classList.remove("hide");
  QuizzesAndsummarizes.classList.add("hide");
  lecturesAndSectionsGuide.classList.add("hide");
  document.querySelector('#AssignmentsAndSupport').scrollIntoView({
    behavior: 'smooth'
  });
}

btnOne.onclick = function () {
  AssignmentsSupport.classList.remove("hide");
  QuizzesAndsummarizes.classList.add("hide");
  lecturesAndSectionsGuide.classList.add("hide");
}

btnSummarizes.onclick = function () {
  QuizzesAndsummarizes.classList.remove("hide");
  AssignmentsSupport.classList.add("hide");
  lecturesAndSectionsGuide.classList.add("hide");
  document.querySelector('#back-two').scrollIntoView({
    behavior: 'smooth'
  });
}

btnTwo.onclick = function () {
  QuizzesAndsummarizes.classList.remove("hide");
  AssignmentsSupport.classList.add("hide");
  lecturesAndSectionsGuide.classList.add("hide");
}

btnlectures.onclick = function () {
  lecturesAndSectionsGuide.classList.remove("hide");
  AssignmentsSupport.classList.add("hide");
  QuizzesAndsummarizes.classList.add("hide");
  document.querySelector('#back-three').scrollIntoView({
    behavior: 'smooth'
  });
}

btnThree.onclick = function () {
  lecturesAndSectionsGuide.classList.remove("hide");
  AssignmentsSupport.classList.add("hide");
  QuizzesAndsummarizes.classList.add("hide");
}

//////////////////////////////////////////
let accordion = document.getElementById("weekBoxs");
let accordionl = document.getElementsByClassName("weekBoxs");
let weekly = document.getElementsByClassName("weekly");
let auditing = document.getElementsByClassName('auditing');
let cost = document.getElementsByClassName('cost');
let database = document.getElementsByClassName('database');
let ecommerce = document.getElementsByClassName('e-commerce');
let communication = document.getElementsByClassName('communication');
let HRM = document.getElementsByClassName('HRM');
console.log(weekly)
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
console.log(auditing)
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
///////////////////////////////////////////////////

function myFunction() {
  // Declare variables
  var input, filter, table, tr, td, i, txtValue;
  input = document.getElementById("myInput");
  filter = input.value.toUpperCase();
  table = document.getElementById("myTable");
  tr = table.getElementsByTagName("tr");

  // Loop through all table rows, and hide those who don't match the search query
  for (i = 1; i < tr.length; i++) {
    td = tr[i].getElementsByTagName("td")[2];
    console.log(tr)
    if (td) {
      txtValue = td.textContent || td.innerText;
      // console.log(txtValue.toUpperCase().indexOf(filter))
      if (txtValue.toUpperCase().indexOf(filter) > -1) {
        tr[i].style.display = "";
      } else {
        tr[i].style.display = "none";
      }
    }
  }
}

function myFunctiontwo() {
  // Declare variables
  var inputs, filter, tables, trs, tds, z, txtValues;
  inputs = document.getElementById("myInputs");
  filter = inputs.value.toUpperCase();
  tables = document.getElementById("myTables");
  trs = tables.getElementsByTagName("tr");

  // Loop through all table rows, and hide those who don't match the search query
  for (z = 1; z < trs.length; z++) {
    tds = trs[z].getElementsByTagName("td")[1];
    console.log(trs)
    if (tds) {
      txtValues = tds.textContent || tds.innerText;
      console.log(txtValues.toUpperCase().indexOf(filter))
      if (txtValues.toUpperCase().indexOf(filter) > -1) {
        trs[z].style.display = "";
      } else {
        trs[z].style.display = "none";
      }
    }
  }
}

/////////////////////////////////////////////////////////
const icon = document.querySelector(".icon");
const search = document.querySelector(".search");
const myInputs = document.getElementById("myInputs");
const searchBox = document.querySelector(".input");
console.log(icon)
icon.onclick = function () {
  search.classList.toggle("active");
  searchBox.classList.toggle("hideCaret");
  myInputs.focus();
}

const icons = document.querySelector(".icons");
const searchs = document.querySelector(".searchs");
const searchBoxs = document.querySelector(".inputs");
console.log(icon)
icons.onclick = function () {
  searchs.classList.toggle("active");
  searchBoxs.classList.toggle("hideCaret");
}
