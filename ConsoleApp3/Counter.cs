using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Counter
    {
        private int[] array = new int[1000_000];
        private Thread[] threads;
        private int[] sum = new int[10];
        private int totalCount;
        private static int work;
        private static int nwork;
        private static Work workk; 

        public Counter(int[] array)
        {
            this.array = array;
        }

        public long Calculate()
        {
            threads = new Thread[10];
            for (int i = 0; i < 10; i++)
            {
                int[] part = array.Skip(i * 100_000).Take(100_000).ToArray();
                threads[i] = new Thread(InternalCalc);
                threads[i].Start(part);
                work = 10 - i;
                nwork = i;
                Thread.Sleep(2000);
            }
            foreach (var item in threads)
            {
                item.Join();
            }
            return totalCount;
        }

        private void InternalCalc(object obj)
        {
            workk = new Work();
            workk.Event += Message;
            int[] partOfArray = obj as int[];
            foreach (int item in partOfArray)
            {
                Interlocked.Add(ref totalCount, item);
            }
            workk.Event += Work;
            workk.InitializeEvent();
            Thread.Sleep(2000);
        }

        private static void Work(object obj, EventArgs eventArgs)
        {
            var MesEventArgs = eventArgs as MessageEventArgs;
            if (MesEventArgs == null)
            {
                return;
            }
            Console.WriteLine("Work: " + work);
            Console.WriteLine("Not work: " + nwork);
        }

        private static void Message(object obj, EventArgs eventArgs)
        {
            Console.WriteLine(eventArgs.ToString());
        }
    }
}



