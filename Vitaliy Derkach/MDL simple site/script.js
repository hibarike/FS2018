"use strict";

////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Founds top header and does it changing color while scrolling
var divs_top = document.getElementsByClassName("mdl-layout--top");
for (var i = 0; i < divs_top.length; i++) {
divs_top[i].onscroll = function () {
var header = document.querySelector(".mdl-layout__header.mdl-layout__header--transparent");
var drawer_icon = document.querySelector(".mdl-layout__drawer-button i");
var image = document.querySelector(".mdl-grid--on-top img");
console.log(header.height);
    if (this.scrollTop >= image.height -30) {
        header.style.backgroundColor = "#3D1C05";
        drawer_icon.style.color = "#3D1C05";
    } 
    else {
         header.style.backgroundColor = "transparent";
         drawer_icon.style.color = "white";
    }
}
};
////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Founds inputs with data pickers and creates the data pickers for them
var inputs_with_calendars = document.getElementsByClassName("mdl-textfield__input--date-picker");
for (var i = 0; i < inputs_with_calendars.length; i++) {
inputs_with_calendars[i].value = GetCurrDate();
var div_parent =  inputs_with_calendars[i].parentNode;
for (var j = 1; j < div_parent.childNodes.length; j+=2) {
if (div_parent.childNodes[j].className.includes("calendar-picker")) {
inputs_with_calendars[i].onclick = function(){
var div_parent =  this.parentNode;
        for (var j = 1; j < div_parent.childNodes.length; j+=2) {
if (div_parent.childNodes[j].className.includes("calendar-picker")) {
	if(div_parent.childNodes[j].firstChild == null){
	WorkWithCalendar(div_parent.childNodes[j], this);
}
break;
}
}
};
}
}
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////

//Creates MyCoffee's geolocotion marker for  Google Maps JavaScript
function initMap() {
  // The location of MyCoffee cafe
  var mycoffee = {lat: 48.460394, lng: 35.046892};
  // The map, centered at MyCoffee cafe
  var map = new google.maps.Map(
      document.getElementById('mdl-map--mycoffee-geomarker'), {zoom: 16, center: mycoffee});
  // The marker, positioned at MyCoffee cafe
  var marker = new google.maps.Marker({position: mycoffee, map: map});
};

////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Creates new data picker for target element
function WorkWithCalendar(div_for_calendar, target){
	console.log(div_for_calendar);
		var calendar = jsCalendar.new(div_for_calendar, GetCurrDate(), {
			language: "en",
			zeroFill: false,
			monthFormat: "month YYYY",
			dayFormat: "D",
			firstDayOfTheWeek: 1,
			navigator: true,
			navigatorPosition: "both"

		});

		calendar.onDateClick(function(event, date){
		var target_day=date.getDate();
		var target_month=date.getMonth()+1;
		var target_year=date.getFullYear();
		var target_date=target_day + "/" + target_month + "/" + target_year;
        target.value=target_date;
        var div_parent =  target.parentNode;
        for (var j = 1; j < div_parent.childNodes.length; j+=2) {
if (div_parent.childNodes[j].className.includes("calendar-picker")) {
	while(div_parent.childNodes[j].firstChild){
div_parent.childNodes[j].removeChild(div_parent.childNodes[j].firstChild);
	}

}
}
		});


};

////////////////////////////////////////////////////////////////////////////////////////////////////////////

//Finds current data as dd/mm/yyyy
function GetCurrDate(){
		var curr_date=new Date();
		var curr_day=curr_date.getDate();
		var curr_month=curr_date.getMonth()+1;
		var curr_year=curr_date.getFullYear();
		var target_date = curr_day + "/" + curr_month + "/" + curr_year;
		return target_date;

}
