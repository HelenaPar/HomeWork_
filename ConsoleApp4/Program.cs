using System;
using System.Linq;
using System.Threading;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Timer timer = new Timer(() => Console.WriteLine("///"), 1);
            //timer.Start();
            //Thread.Sleep(5000);
            //timer.Restart();

            int[] array = Enumerable.Range(1, 1000_000).ToArray();
            int count = 0;
            foreach (int item in array)
            {
                count += item;
            }
            Console.WriteLine("Sum without task = " + count);
            Counter counter = new Counter(array);
            Console.WriteLine();
            Console.WriteLine("Sum in all tasks = " + counter.Calculate());
        }
    }
}
