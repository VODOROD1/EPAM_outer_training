using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1.LOST
{
    class Program
    {
        static void Main(string[] args)
        {
            uint N;
            List<Person> people;
            ExecuteTask(out N);
            MakeList(N, out people);
            CircularBill(people);
            Console.WriteLine($"Последний оставшийся элемент: {people[0].Number}");
            Console.ReadKey();
        }
        public static void ExecuteTask(out uint N)
        {
            while (true) {
                Console.Write("Введите число N:");
                var n = Console.ReadLine();
                if (uint.TryParse(n, out N))
                {
                    N = Convert.ToUInt32(n);
                    break;
                }
                else { Console.WriteLine("Неверный ввод!"); }
            }
        }
        public static void MakeList(uint N, out List<Person> people)
        {
            people = new List<Person>((int)N);
            for (int i = 0; i < N; i++ )
            {
                people.Add(new Person(i+1));
            }
        }
        public static void CircularBill(List<Person> people)
        {
            while (people.Count > 1) {
                for (int i = 0; i < people.Count; i++)
                {
                    if (people[i].Number % 2 == 0)
                    {   
                        if (i != people.Count - 1)
                        {
                            people[i + 1].Number = people[i].Number;
                        }
                        people.RemoveAt(i);
                    }
                }
            }
        }
    }
    class Person
    {
        public int Number { get; set; }
        public Person(int number)
        {
            Number = number;
        }
    }
}