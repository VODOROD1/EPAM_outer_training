//Как я понял: нужно сохранять в противополжном списке те выбранные элементы,
//которых в нём нет, а те выбранные элементы которые есть -- остаются в текущем списке
var d = document;
var leftUL = d.getElementById('leftUL');
var leftList = leftUL.getElementsByTagName('li');
var rightUL = d.getElementById('rightUL');
var rightList = rightUL.getElementsByTagName('li');
var buttons = d.forms[0].getElementsByTagName("button");
var doubleRightButton = buttons[0];
var rightButton = buttons[1];
var leftButton = buttons[2];
var doubleLeftButton = buttons[3];

//Изменяем фон выбранного элемента
function mutateLI(li){
  li.classList.toggle('selected');
}

//Далее идет приписка событий на кнопки в центре

/*перенос элементов левого списка в правый список*/
//кнопка переноса всех элементов левого списка, которые не перекрывают элементы правого списка
doubleRightButton.addEventListener("click", doubleRightButtonEvent);
function doubleRightButtonEvent(e){
  if(leftList.length != 0){
    addClassSelected(leftList);
    var nonOverlapList = checkOverlap(leftList, rightList); //массив неперекрывающих элементов
    addElementsInRightList(nonOverlapList);//добавим класс selected во все элемы левого списка
  } else{alert("There are no elements!")}
  removeClassSelected(leftList);//удалим класс selected из тех элементов, которые не удалось перенести
  e.preventDefault();
}

//одинарная кнопка переноса в правый список
rightButton.addEventListener("click", rightButtonEvent);
function rightButtonEvent(e){
  var nonOverlapList = selectionChosenElements(leftList, rightList);
  if(nonOverlapList.length != 0){
    addElementsInRightList(nonOverlapList);
  } else {alert("It's impossible to execute chosen operation!")}
  removeClassSelected(leftList);//удалим класс selected из тех элементов, которые не удалось перенести
  e.preventDefault();
}
//Универсальная функция, используемая двумя кнопками переноса в правый список
function addElementsInRightList(nonOverlapList){
  for(var i = 0; i<nonOverlapList.length; i++){
    var cloneLI = nonOverlapList[i].cloneNode(true);
    leftUL.removeChild(nonOverlapList[i]); //удалим элемент из левого списка
    cloneLI.classList.toggle('selected');
    rightUL.appendChild(cloneLI);
  }
}
//////////////////////////////////////

/*перенос элементов правого списка в левый список*/
//кнопка переноса всех элементов правого списка, которые не перекрывают элементы левого списка
doubleLeftButton.addEventListener("click", doubleLeftButtonEvent);
function doubleLeftButtonEvent(e){
  if(rightList.length != 0){
    addClassSelected(rightList);
    var nonOverlapList = checkOverlap(rightList, leftList);
    addElementsInLeftList(nonOverlapList);//добавим класс selected во все элемы левого списка
  } else{alert("There are no elements!")}
  removeClassSelected(rightList);//удалим класс selected из тех элементов, которые не удалось перенести
  e.preventDefault();
}

//одинарная кнопка переноса в левый список
leftButton.addEventListener("click", leftButtonEvent);
function leftButtonEvent(e){
  var nonOverlapList = selectionChosenElements(rightList, leftList);
  if(nonOverlapList.length != 0){
    addElementsInLeftList(nonOverlapList);
  } else {alert("It's impossible to execute chosen operation!")}
  removeClassSelected(rightList);//удалим класс selected из тех элементов, которые не удалось перенести
  e.preventDefault();
}
//Универсальная функция, используемая двумя кнопками переноса в левый список
function addElementsInLeftList(nonOverlapList){
  for(var i = 0; i<nonOverlapList.length; i++){
    var cloneLI = nonOverlapList[i].cloneNode(true);
    rightUL.removeChild(nonOverlapList[i]); //удалим элемент из правого списка
    cloneLI.classList.toggle('selected');
    leftUL.appendChild(cloneLI);
  }
}
////////////////////////////////////////////

/*Далее идут универсальные функции, используемые всеми кнопками*/
//Универсальная функция, составляющая массив из выбранных элементов
//chosenUL и oppositeUL -- это уже сами списки элементов li
function selectionChosenElements(chosenUL, oppositeUL){
  var selectedList = []; //Массив из элементов, имеющих класс selected
  var nonOverlapList = [];//массива из неперекрывающих элементов
  if(chosenUL.length != 0){
    for(var i = 0; i<chosenUL.length; i++){
      //находим элемы с классом selected
      if(chosenUL[i].classList.contains('selected')){
        selectedList.push(chosenUL[i]); 
      }
    }
    if(selectedList.length != 0){
      nonOverlapList = checkOverlap(selectedList, oppositeUL);//вызываем функцию проверки
      if(nonOverlapList.length == 0){
        alert("These elements are already present on the opposite list!");
      }else{
        return nonOverlapList;
      }
    }else {alert("You have to select element(s)!");}
  } else {alert("There are no elements!");}
  return nonOverlapList;
}

//Универсальная функция проверки перекрытия и составления на основе этого действия --
//-- массива nonOverlapList из неперекрывающих элементов
//oppositeUL -- это уже сам список элементов li
function checkOverlap(selectedList, oppositeUL){
  var nonOverlapList = [];
  var logic = true;
  if(oppositeUL.length != 0){
    for(var i = 0; i<selectedList.length; i++){
      logic = true;
      for(var j = 0; j<oppositeUL.length; j++){
        //Сравнение идет по тексту внутри элементов
        if(selectedList[i].innerHTML == oppositeUL[j].innerHTML){
          logic = false;
          break;
        } else {continue;}
      }
      if(logic){
        nonOverlapList.push(selectedList[i]);
      }
    }
  } else {nonOverlapList = selectedList}
  return nonOverlapList;
}
//Универсальная функция добавления класса selected во все элементы списка
function addClassSelected(list){
  for(var i = 0; i<list.length; i++){
    if(!list[i].classList.contains('selected')){
      list[i].classList.add('selected');
    }
  }
}
//Универсальная функция удаления класса selected из оставшихся элементов списка из которого мы выбирали элементы
function removeClassSelected(list){
  for(var i = 0; i<list.length; i++){
    if(list[i].classList.contains('selected')){
      list[i].classList.remove('selected');
    }
  }
}
//Конец приписки событий на кнопки

