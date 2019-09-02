// var d = document;
// var baseStringElem = d.getElementById("baseString");

// function splitString(){
//     var baseString = baseStringElem.innerText();
//     var mas1;
//     var mas2;
//     var mas3;
//     var mas4;
//     var mas5;
//     var mas6;
//     var mas7;
//     var mas8;
//     if(baseString.includes(" ")){
//       mas1 = baseString.split(" ");
//     }
//     baseString.split(" ");
//     baseString.split(" ");
//     baseString.split(" ");
//     baseString.split(" ");
//     baseString.split(" ");
//     baseString.split(" ");
//     baseString.split(" ");
//     baseString.split(" ");
// }
function splitString(){
   //   var str = baseStringElem.innerText();
   var str = "Строка котораясоответствует;условию?которое:установлено;в,задании.по фронту";
     var logic = true;
     var tempSubStr="";
     var newSubStr="";
     var resultStr="";
     for(var i=1; i<baseString.length-1;i++){
       if(str[i] == " " || str[i] == "?" || str[i] == "!" || str[i] == ":" || str[i] == ";" || str[i] == "," || str[i] == "."){
         //Проверяем подстроку между разделителями на пустоту
         if(tempSubStr!=""){
             for(var j=0; j<tempSubStr.length-1;j++){
               for(var k=j+1; k<tempSubStr.length;k++){
                  if(tempSubStr[j]==tempSubStr[k]){
                      logic = false;
                      //break;
                  }
               }
               if(logic){
                  newSubStr += tempSubStr[j];
                }
             }
             tempSubStr="";
         }
         //Прибавляем разделители к формирующейся незультирующей строку
         resultStr+=str[i];
        } else{tempSubStr+=str[i]}
     }
     console.log(resultStr);
   }
//d.addEventListener("click", splitString);

function splitString();