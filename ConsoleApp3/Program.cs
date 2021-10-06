using System;
using System.Linq;
using System.Threading;

namespace ConsoleApp3
{
    class Program
    {
       // public delegate Action act;
        public static int sec = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("1 - first task (timer)");
            Console.WriteLine("2 - second task (calculate)");
            int m = Convert.ToInt32(Console.ReadLine());
            switch(m)
            { 
                case 1:
                    Timer timer = new Timer(() => Console.WriteLine("///"), 2);
                    timer.Start();
                    Thread.Sleep(50);
                   // timer.Stop();
                 //   timer.Start();
                    timer.Restart();
                break;
               
                case 2:
                    int[] array = Enumerable.Range(1, 1000_000).ToArray();
                    long count = 0;
                    foreach(int item in array)
                    {
                        count += item;
                    }
                    Console.WriteLine((int)count);
                    Counter counter = new Counter(array);
                   // counter.FinishEvent += Message;
                    counter.FinishEvent += Work;
                    Console.WriteLine();
                    Console.WriteLine("Sum in all threads = " + counter.Calculate());
                    break;
            }
        }
        private static void Message(object obj, EventArgs eventArgs)
        {
            Console.WriteLine(eventArgs.ToString());
        }

        private static void Work(object obj, EventArgs eventArgs)
        {
            var mesEventArgs = eventArgs as MessageEventArgs;
            if (mesEventArgs == null)
            {
                return;
            }
            Console.WriteLine(mesEventArgs.ToString());
        }
    }
}
