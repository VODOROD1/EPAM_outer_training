var d = document;
//создаем массив ссылок на местоположение html-документов
var link = d.location.href.match(/(page\d\.html)/g);
var pause = d.getElementById("pause");
var restart = d.getElementById("restart");
var resume = d.getElementById("resume");
var moveBack = d.getElementById("moveBack");
var timer = d.getElementById("timer");
var value ="0";
var intervalID;
var seconds = 5; //задаем количество секунд таймера

var pageAddresses = {
    page1: "page1.html",
    page2: "page2.html",
    page3: "page3.html",
    page4: "page4.html",
    page5: "page5.html",
};

var linkArr = [];
for (var value of Object.values(pageAddresses)){
    linkArr.push(value);
}
//Отсчет времени перехода на след страницу
function goToNextPage(adress){
    function countdown(){
        timer.innerText = seconds +" sec";
        seconds--;
        // if (seconds == 1){
        //     window.location = adress;
        // }
        if (seconds < 0){
            window.location = adress;
        }
    }
    countdown();
    intervalID = setInterval(countdown, 1000);
}

choosePage(seconds);

function choosePage(time){
    switch (link[0]){
       case "page1.html":
        goToNextPage(pageAddresses.page2, time);
           break;
       case "page2.html":
        goToNextPage(pageAddresses.page3, time);
           break;
       case "page3.html":
        goToNextPage(pageAddresses.page4, time);
           break;
       case "page4.html":
        goToNextPage(pageAddresses.page5, time);
           break;
       case "page5.html":
               setTimeout(()=>(scrollAgainOrEndScroll()), 1000);
           break;
    }
}
//Подписываем события на кнопки интерфейса
restart.addEventListener("click", restartTimer, false);
function restartTimer(){
    window.location = link[0];
}

pause.addEventListener("click", pauseTimer, false);
function pauseTimer(){
    togglePauseResume();
    resume.disabled = false;
    pause.disabled = true;
    value = timer.textContent;
    clearInterval(intervalID);
}

resume.addEventListener("click", resumeTimer, false);
function resumeTimer(){
    togglePauseResume();
    pause.disabled = false;
    resume.disabled = true;
    choosePage(value);
}

moveBack.addEventListener("click", goToPreviousPage, false);
function goToPreviousPage(){
    var linkToFind = linkArr.indexOf(link[0]);
    window.location = linkArr[linkToFind - 1];
}
///////////////////////////////////////////////////////
//Метод спрашивает у пользователя хочет он уйти или начала пролистывание заново
function scrollAgainOrEndScroll(){
    var valid = confirm("Repeat page scrolling (ok), or exit (cancel)?");
    if (valid == true){
        window.location = "page1.html";

    } else if (valid == false){
        window.open('','_self').close();
    }
}
//Метод переключения доступности функциональности кнопок управления временем
function togglePauseResume(){
    if (pause.disabled == false){
        resume.disabled = true;
    } else if (pause.disabled == true){
        resume.disabled = false;
    }
    if (resume.disabled == false){
        pause.disabled = true;
    } else if (resume.disabled == true){
        pause.disabled = false;
    }
}
//Ставим в самом начале кнопку resume неактивной т.к. таймер начинает отсчет сам по себе
window.onload = function(){
    pause.disabled == false;
    resume.disabled = true;
}