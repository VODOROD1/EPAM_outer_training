// var d = document;
// var baseStringElem = d.getElementById("baseString");

   function splitString(){
   //   var str = baseStringElem.innerText();
     var str = "ССтрока;котораясоответствует условию?которое:установлено;в,задании по.фронту";
     var tempSubStr="";
     var newSubStr="";
     var resultStr="";
     var logic = true;
     var masOfRepeatSymbols = [];
     for(var i=0; i<str.length; i++){
       if(str[i] == " " || str[i] == "?" || str[i] == "!" || str[i] == ":" || str[i] == ";" || str[i] == "," || str[i] == "." || i == str.length-1){
         
         //Проверяем подстроку между разделителями на пустоту
         if(tempSubStr.length != 0){
            if(tempSubStr.length > 1){
               //Формируем массив из повторяющихся символов
               for(var j=0; j<tempSubStr.length-1;j++){
                  for(var k=j+1; k<tempSubStr.length;k++){
                     if(tempSubStr[j]==tempSubStr[k]){
                        masOfRepeatSymbols.push(tempSubStr[k]);
                           break;
                     }
                  }
               }
               //Прибавляем неповторяющийся символ подстроки к результирующей строке
               if(masOfRepeatSymbols.length != 0){
                  for(var j=0; j<tempSubStr.length; j++){
                     logic=true;
                     for(var k=0; k<masOfRepeatSymbols.length; k++){
                        if(tempSubStr[j] == masOfRepeatSymbols[k]){
                           logic=false;
                           break;
                        }
                     }
                     if(logic){
                        resultStr+=tempSubStr[j];
                     }
                  }
               } else{resultStr+=tempSubStr;}
         } else{resultStr+=tempSubStr;}
            //Обязательно обнуляем переменную подстроку и массив повторяющихся символов
            tempSubStr="";
            masOfRepeatSymbols = [];
         }
         //Прибавляем разделители к формирующейся результирующей строку
         resultStr+=str[i];
        } else{    
         tempSubStr+=str[i];
      }
     }
     console.log(resultStr);
   }
   splitString();
//d.addEventListener("click", splitString);
