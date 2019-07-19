using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._4.MY_STRING
{
    class MyString
    {
        private char[] ch;
        public MyString(String str)
        {
            ch = str.ToCharArray();
        }
        public MyString(char[] ch)
        {
            this.ch = ch;
        }
        // индексатор
        public char this[int index]
        {
            get
            {
                return ch[index];
            }
            set
            {
                ch[index] = value;
            }
        }
        public char[] getCh()
        {
            return ch;
        }
        public void setCh(char[] ch)
        {
            this.ch=ch;
        }
        public static MyString operator +(MyString c1, MyString c2)
        {
            char[] newStr = c1.getCh().Concat(c2.getCh()).ToArray();
            return new MyString( newStr );
        }
        static bool Equals(MyString m1, MyString m2)
        {
            char[] c1 = m1.ToCharArray();
            char[] c2 = m2.ToCharArray();
            if (c1.Length == c2.Length)
            {
                for (int i = 0; i < c1.Length; i++)
                {
                    if (!c1[i].Equals(c2[i]))
                        return false;
                }
                return true;
            }
            return false;
        }
        public int indexOf( char someCh)
        {
            int index = 0;
            for (int i=0; i< ch.Length; i++)
            {
                if (ch[i] == someCh)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }  
        public int lastIndexOf(char someCh)
        {
            int index = 0;
            for (int i = 0; i < ch.Length; i++)
            {
                if (ch[i] == someCh)
                {
                   index = i;
                }

            }
            return index;
        }
        public char[] ToCharArray() => ch;
        public override String ToString() => new String(ch);
    }
}