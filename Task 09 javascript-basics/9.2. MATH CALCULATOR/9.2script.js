   const arithmExpress = document.getElementById('arithmExpress');
   const equalityButton = document.getElementById('equality');
   const outputResult = document.getElementById('result');
   var result = "";

   equalityButton.addEventListener("click", CalculateString);

   function CalculateString(e) {
      str = arithmExpress.value;
      // str = "3 - 8 +6 - 12+ 24";
		matchArr = [],
		searchPattern = /\-?\d+(\.\d+)?|[\+,\-,\*,\/,\=]{1}/ig;
		matchArr = str.match(searchPattern);

		if(matchArr[0]*1+"" !== "NaN") {
			result += matchArr[0]*1;
		}

		for(var i = 0; i < matchArr.length; i++) {
			switch(matchArr[i]) {
				case "+": result += matchArr[i+1] * 1; break;
				case "-": result -= matchArr[i+1] * 1; break;
				case "*": result *= matchArr[i+1] * 1; break;
				case "/": result /= matchArr[i+1] * 1; break;
				case "=": break;
				default: continue;
			}
      }
      output();
   }
   function output(){
      outputResult.value = result;
   }



