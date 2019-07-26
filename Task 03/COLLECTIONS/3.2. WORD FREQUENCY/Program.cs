using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._2.WORD_FREQUENCY
{
    class Program
    {
        static void Main(string[] args)
        {
            String str;
            List<String> words = new List<String>();
            Dictionary<String, int> matchedWords = new Dictionary<String, int> ();
            Ask(out str);
            CreateMas(str, words);
            FindMatch(words, matchedWords);
            WriteMatchedWords(matchedWords);
            Console.ReadKey();
        }
        public static void Ask(out String str)
        {
            bool flag;
            while (true)
            {
                flag = true;
                Console.Write("Введите текст: ");
                str = Console.ReadLine();
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] >= 'А' && str[i] <= 'я')
                    {
                        Console.WriteLine("Текст не должен содержать русских символов!");
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    break;
                }
            }      
        }
        public static void CreateMas(String str, List<String> words)
        {
            String[] strings = str.Split(new char[] { ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < strings.Length; i++)
            {
                words.Add(strings[i].ToLower());
            }
        }
        public static void FindMatch(List<String> words, Dictionary<String, int> matchedWords)
        {
            int count = 1;
            for (int i = 0; i < words.Count; i++)
            {   
                if (words[i] != " ") {
                    for (int j = i + 1; j < words.Count; j++)
                    {
                        if (String.Compare(words[i], words[j]) == 0)
                        {
                            count++;
                            words[j] = " ";
                        }
                    }
                }
                if (count > 1)
                {
                    matchedWords.Add(words[i], count);
                    count = 1;
                }
            }
        }
        public static void WriteMatchedWords(Dictionary<String, int> matchedWords)
        {
            Console.WriteLine("Слова, повторяющиеся в тексте: ");
            foreach (KeyValuePair<string, int> keyValue in matchedWords)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }
        }
    }
}