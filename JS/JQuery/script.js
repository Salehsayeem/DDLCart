$(function(){
console.log('Document is ready');
});

document.addEventListener("DOMContentLoaded",pageLoadedFunction(event));
function pageLoadedFunction(event){
    console.log("DOM is ready");
}

document.onload = pageLoadedFunction();