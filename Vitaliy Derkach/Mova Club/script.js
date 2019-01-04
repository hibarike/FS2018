var buttonsClickList = document.getElementsByClassName("navigation-mobile__button--clickable");
for(var i = 0; i< buttonsClickList.length; i++){
	buttonsClickList[i].onclick =  function(){
		OpenNavigationList(this);
	}
}

var screenWidth = window.matchMedia("(min-width: 1025px)");
HideElemLargeScr(screenWidth);
screenWidth.addListener(HideElemLargeScr);


var buttonMobNav = document.getElementsByClassName("button-mobile");
for(var i = 0; i< buttonMobNav.length; i++){
	buttonMobNav[i].onclick =  function(){
		OpenMobileHeader(this);
	}
}

var layout = document.querySelector("mdl-layout");
console.log(layout);
window.addEventListener('scroll', function(){ 
console.log("Hello");
	kaka();});
    


function kaka(){
	var d = document.getElementById("ggg");
	console.log(d.scrollTop);
}


function OpenNavigationList(button){
var node = button.parentNode;
var lists = node.getElementsByClassName("navigation-mobile__clickable-content");
for(var i = 0; i < lists.length; i++){
lists[i].style.display = "flex";
}
button.innerText = "-";
button.onclick = function(){
		CloseNavigationList(button);
	}
}


function CloseNavigationList(button){
	var node = button.parentNode;
var lists = node.getElementsByClassName("navigation-mobile__clickable-content");
button.innerText = "+";
for(var i = 0; i < lists.length; i++){
lists[i].style.display = "none";
}
button.onclick = function(){
		OpenNavigationList(button);
	}
}

function OpenMobileHeader(button){
var node = button.parentNode;
var headers = node.getElementsByClassName("header-mobile");
button.innerText = "\u26cc";
for(var i = 0; i < headers.length; i++){
if (!headers[i].className.includes("header-mobile--opened")) {
		headers[i].classList.add("header-mobile--opened");
	}
	if (headers[i].className.includes("header-mobile--opened")) {
		headers[i].classList.remove("header-mobile--closed");
	}
}
button.onclick = function(){
		CloseMobileHeader(button);
	}
}

function CloseMobileHeader(button){
var node = button.parentNode;
var headers = node.getElementsByClassName("header-mobile");
button.innerText = "\u2630";
for(var i = 0; i < headers.length; i++){
	if (headers[i].className.includes("header-mobile--opened")) {
		headers[i].classList.remove("header-mobile--opened");
	}
	if (!headers[i].className.includes("header-mobile--opened")) {
		headers[i].classList.add("header-mobile--closed");
	}
}
button.onclick = function(){
		OpenMobileHeader(button);
	}
}

function HideElemLargeScr(screenWidth){
	if(screenWidth.matches)
{
	var headers = document.getElementsByClassName("header-mobile");
	for(var i = 0; i < headers.length; i++){
		headers[i].style.display = "none";
}
}
else{
var headers = document.getElementsByClassName("header-mobile");
	for(var i = 0; i < headers.length; i++){
headers[i].style.display = null;
	}
	}
}



