using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    int arrayElement;
                    Console.Write("Введите размер Вашего массива: ");
                    int arraySize;
                    arraySize = Convert.ToInt32(Console.ReadLine());

                    int[] array = new int[arraySize];

                    Console.SetCursorPosition(0, 5);

                    for (int i = 0; i < array.Length; i++)
                    {
                        Console.Write($"Введите элемент {i + 1} Вашего массива: ");

                        arrayElement = Convert.ToInt32(Console.ReadLine());
                        array[i] = arrayElement;
                    }

                    int maxElement = 0;
                    int prevMaxElement = 0;

                    for (int i = 0; i < array.Length; i++)
                    {
                        int currentElement = array[i];

                        if (currentElement > maxElement)
                        {
                            prevMaxElement = maxElement;
                            maxElement = currentElement;

                        }
                        else if (currentElement < maxElement && currentElement > prevMaxElement)
                        {
                            prevMaxElement = currentElement;
                        }
                    }
                    Console.WriteLine("Второй наибольший элемент массива: " + prevMaxElement);
                    Console.ReadKey();
                    Console.Clear();
                }
                catch (OverflowException e)
                {
                    Console.WriteLine("Вы ввели неправильное значение для размера массива! Попробуйте ещё раз, нажав любую кнопку!");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Вы ввели нечисловое значение! Пожалуйста, вводите только числовые значений! Нажммите любую кнопку, чтобы попробовать ещё раз");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

            }
        }
    }
}
