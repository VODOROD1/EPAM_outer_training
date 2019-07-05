using System;

namespace _1._6._FONT_ADJUSTMENT
{
    class Program
    {
        static void Main(string[] args)
        {
            workWithEnum();
        }

        [Flags]
        public enum Font
        {
            None = 0,
            Bold = 1,
            Italic = 2,
            Underline = 4,
            BoldItalic = Font.Bold | Font.Italic,
            BoldUnderline = Font.Bold | Font.Underline,
            ItalicUnderline = Font.Italic | Font.Underline,
            BoldItalicUnderline = Font.Bold | Font.Italic | Font.Underline
        }
        public static Font currentFont = Font.None;
        public static void workWithEnum()
        {
            String selectedStyle = "";

            Console.WriteLine($"Параметры надписи: {currentFont}");
            Console.WriteLine("Введите:");
            while (true)
            {
                Console.WriteLine("\t1: none");
                Console.WriteLine("\t2: bold");
                Console.WriteLine("\t3: italic");
                Console.WriteLine("\t4: underline");

                selectedStyle = Console.ReadLine();

                if (selectedStyle == "1")
                {
                    switch (currentFont)
                    {
                        case Font.None:
                            Console.WriteLine($"Стиль {currentFont} является базовым!");
                            break;

                        case Font.Bold:
                        case Font.Italic:
                        case Font.Underline:
                        case Font.BoldItalic:
                        case Font.BoldUnderline:
                        case Font.ItalicUnderline:
                        case Font.BoldItalicUnderline:
                            currentFont = Font.None;
                            break;
                    }
                }
                else if (selectedStyle == "2")
                {
                    switch (currentFont)
                    {
                        case Font.None:
                            currentFont = Font.Bold;
                            break;

                        case Font.Bold:
                            currentFont = Font.None;
                            break;
                        case Font.Italic:
                            currentFont = Font.BoldItalic;
                            break;
                        case Font.Underline:
                            currentFont = Font.BoldUnderline;
                            break;
                        case Font.BoldItalic:
                            currentFont = Font.Italic;
                            break;
                        case Font.BoldUnderline:
                            currentFont = Font.Underline;
                            break;
                        case Font.ItalicUnderline:
                            currentFont = Font.BoldItalicUnderline;
                            break;
                        case Font.BoldItalicUnderline:
                            currentFont = Font.ItalicUnderline;
                            break;
                    }
                }
                else if (selectedStyle == "3")
                {
                    switch (currentFont)
                    {
                        case Font.None:
                            currentFont = Font.Italic;
                            break;

                        case Font.Bold:
                            currentFont = Font.BoldItalic;
                            break;
                        case Font.Italic:
                            currentFont = Font.None;
                            break;
                        case Font.Underline:
                            currentFont = Font.ItalicUnderline;
                            break;
                        case Font.BoldItalic:
                            currentFont = Font.Bold;
                            break;
                        case Font.BoldUnderline:
                            currentFont = Font.BoldItalicUnderline;
                            break;
                        case Font.ItalicUnderline:
                            currentFont = Font.Underline;
                            break;
                        case Font.BoldItalicUnderline:
                            currentFont = Font.BoldUnderline;
                            break;
                    }
                }
                else if (selectedStyle == "4")
                {
                    switch (currentFont)
                    {
                        case Font.None:
                            currentFont = Font.Underline;
                            break;

                        case Font.Bold:
                            currentFont = Font.BoldUnderline;
                            break;
                        case Font.Italic:
                            currentFont = Font.ItalicUnderline;
                            break;
                        case Font.Underline:
                            currentFont = Font.None;
                            break;
                        case Font.BoldItalic:
                            currentFont = Font.BoldItalicUnderline;
                            break;
                        case Font.BoldUnderline:
                            currentFont = Font.Bold;
                            break;
                        case Font.ItalicUnderline:
                            currentFont = Font.Italic;
                            break;
                        case Font.BoldItalicUnderline:
                            currentFont = Font.BoldItalic;
                            break;
                    }
                }
                else { Console.WriteLine("Нет такого стиля!"); }

                Console.WriteLine($"Параметры надписи: {(int)currentFont}");
            }
        }
    }
}
