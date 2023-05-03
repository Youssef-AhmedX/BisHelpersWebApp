let professorName = document.getElementById('professorName');
let HananGaber = new Option('Hanan Gaber', 'Hanan Gaber');
let HagerAbdelrahman = new Option('Hager Abdelrahman', 'Hager Abdelrahman');
let EmanSaad = new Option('Eman Saad', 'Eman Saad');
let MohamedShaban = new Option('Mohamed Shaban', 'Mohamed Shaban');
let MohiySamy = new Option('Mohiy Samy', 'Mohiy Samy');
let AbdelrahmanFarmawy = new Option('Abdelrahman Farmawy', 'Abdelrahman Farmawy');
let YehiaHelmy = new Option('Yehia Helmy', 'Yehia Helmy');
let ShereenTayaa = new Option('Shereen Tayaa', 'Shereen Tayaa');
let AssamShaaban = new Option('Assam Shaaban', 'Assam Shaaban');
let AhmedMounir = new Option('Ahmed Mounir', 'Ahmed Mounir');
let MohamedHassan = new Option('Mohamed Hassan', 'Mohamed Hassan');
let AhmedElsadawy = new Option('Ahmed Elsadawy', 'Ahmed Elsadawy');
let FahdElshreef = new Option('Fahd Elshreef', 'Fahd Elshreef');
let AhmedAbdelwahab = new Option('Ahmed Abdelwahab', 'Ahmed Abdelwahab');
let MostafaYoussef = new Option('Mostafa Youssef', 'Mostafa Youssef');
let OmarSakr = new Option('Omar Sakr', 'Omar Sakr');
let HamdyGomaa = new Option('Hamdy Gomaa', 'Hamdy Gomaa');
let AhlamElSaadi = new Option('Ahlam ElSaadi', 'Ahlam ElSaadi');
let MarwaMansoor = new Option('Marwa Mansoor', 'Marwa Mansoor');
let NehalAllam = new Option('Nehal Allam', 'Nehal Allam');
let WafaaAbdelsamieaa = new Option('Wafaa Abdelsamieaa', 'Wafaa Abdelsamieaa');

professorName.add(HananGaber, undefined);
professorName.add(HagerAbdelrahman, undefined);
professorName.add(MohamedShaban, undefined);
professorName.add(EmanSaad, undefined);
function detectChange(selectOS) {
  if (selectOS.value === "Auditing") {
    console.log("Yes")
    professorName.remove(0);
    professorName.remove(0);
    professorName.remove(0);
    professorName.remove(0);
    professorName.remove(0);
    professorName.add(HananGaber, undefined);
    professorName.add(HagerAbdelrahman, undefined);
    professorName.add(MohamedShaban, undefined);
    professorName.add(EmanSaad, undefined);
  }
  if (selectOS.value === "Cost Accounting") {
    professorName.remove(0);
    professorName.remove(0);
    professorName.remove(0);
    professorName.remove(0);
    professorName.remove(0);
    professorName.add(MohiySamy, undefined);
    professorName.add(AbdelrahmanFarmawy, undefined);
  }
  if (selectOS.value === "DataBase") {
    professorName.remove(0);
    professorName.remove(0);
    professorName.remove(0);
    professorName.remove(0);
    professorName.add(MohamedHassan, undefined);
    professorName.add(AssamShaaban, undefined);
    professorName.add(FahdElshreef, undefined);
    professorName.add(AhmedAbdelwahab, undefined);
    professorName.add(AhmedElsadawy, undefined);
  }
  if (selectOS.value === "E-Commerce") {
    professorName.remove(0);
    professorName.remove(0);
    professorName.remove(0);
    professorName.remove(0);
    professorName.remove(0);
    professorName.add(YehiaHelmy, undefined);
    professorName.add(AssamShaaban, undefined);
    professorName.add(AhmedMounir, undefined);
    professorName.add(ShereenTayaa, undefined);
  }
  if (selectOS.value === "Communication") {
    professorName.remove(0);
    professorName.remove(0);
    professorName.remove(0);
    professorName.remove(0);
    professorName.remove(0);
    professorName.add(MostafaYoussef, undefined);
    professorName.add(OmarSakr, undefined);
    professorName.add(HamdyGomaa, undefined);
    professorName.add(AhlamElSaadi, undefined);
  }
  if (selectOS.value === "HRM") {
    professorName.remove(0);
    professorName.remove(0);
    professorName.remove(0);
    professorName.remove(0);
    professorName.remove(0);
    professorName.add(MarwaMansoor, undefined);
    professorName.add(NehalAllam, undefined);
    professorName.add(WafaaAbdelsamieaa, undefined);
  }
}

/////////////////////////////////////////////////////////////////

