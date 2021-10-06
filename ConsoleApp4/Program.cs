using System;
using System.Linq;
using System.Threading;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = Convert.ToInt32(Console.ReadLine());
                switch (num)
                {
                    case 1:
                        Timer timer = new Timer(() => Console.WriteLine("///"), 1);
                        timer.Start();
                        Thread.Sleep(50);
                        //  timer.Stop();
                        timer.Restart();
                        break;
                    case 2:
                        int[] array = Enumerable.Range(1, 1000_000).ToArray();
                        int count = 0;
                        foreach (int item in array)
                        {
                            count += item;
                        }
                        Console.WriteLine("Sum without threads = " + count);
                        Counter counter = new Counter(array);
                        counter.FinishEvent += Work;
                        Console.WriteLine();
                        Console.WriteLine("Sum in all threads = " + counter.Calculate());
                        break;
                    default:
                        Console.WriteLine("Enter 1 or 2");
                        break;
                
            }
        }

        private static void Work(object obj, EventArgs eventArgs)
        {
            var mesEventArgs = eventArgs as MesEventArgs;
            if (mesEventArgs == null)
            {
                return;
            }
            Console.WriteLine("Work: " + mesEventArgs.Work);
            Console.WriteLine("Not work: " + mesEventArgs.NotWork);
        }
    }
}

