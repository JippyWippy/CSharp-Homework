using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            Console.Write("Доброго дня! Введите своё имя: ");
            name = Console.ReadLine();

            Console.WriteLine($"Привет, { name}!");
        }
    }
}
