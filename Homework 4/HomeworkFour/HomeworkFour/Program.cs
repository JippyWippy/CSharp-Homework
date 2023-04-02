using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeworkFour
{
    public delegate void EventDelegate();
    internal class Program
    {
        static void Main(string[] args)
        {
            Counter counter = new Counter();
            Handler1 handler1 = new Handler1();
            Handler2 handler2 = new Handler2();

            counter.myEvent += handler1.ShowHandler1;
            counter.myEvent += handler2.ShowHandler2;

            counter.Count(0, 100);

        }
    }

    class Counter
    {
        public event EventDelegate myEvent;

        public void Count(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write(i);

                if (i == 77)
                {
                    myEvent();
                }
                Console.WriteLine("\n");
            }
        }
    }

    public class Handler1
    {

        public void ShowHandler1()
        {
            Console.WriteLine(" - Вот это цифрка!");
        }
    }

    public class Handler2
    {
        public void ShowHandler2()
        {
            Console.WriteLine("А после неё идёт другая!");
        }
    }
}
