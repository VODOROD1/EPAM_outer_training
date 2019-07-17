using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._4.MY_STRING
{
    class MyString
    {
        String str = "";
        char[] ch;
        public MyString(String str)
        {
            this.str = str;
        }

        public void ToCharArray(String someStr) {
            ch = new char[str.Length];
            for(int i = 0; i < str.Length; i++)
            {
                ch[i] = someStr[i];
            }
        }

        public void ToString(char [] someCh) {
            for (int i = 0; i < ch.Length; i++)
            {
                str[i] = someCh[i];
            }
        }

        public static MyString operator +(MyString c1, MyString c2)
        {
            String newStr = c1.str + c2.str;
            return new MyString( newStr );
        }

        public static bool operator <(MyString c1, MyString c2)
        {
            return c1.Value < c2.Value;
        }

    }
}
