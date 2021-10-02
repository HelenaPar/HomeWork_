using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Counter
    {
        private int[] array = new int[1000_000];
        private int totalCount;
        private static int work;
        private static int nwork;
        static Work workk;
        public Counter(int[] array)
        {
            this.array = array;
        }
        public long Calculate()
        {
            workk = new Work();
            Task[] tasks = new Task[10];
            for (int i = 0; i < 10; i++)
            {
                int[] part = array.Skip(i * 100_000).Take(100_000).ToArray();
                tasks[i] = new Task(() =>
                {
                    int[] partOfArray = part as int[];
                    foreach (int item in partOfArray)
                    {
                        Interlocked.Add(ref totalCount, item);
                        work = 10 - i;
                        nwork = i;
                    }
                });
                tasks[i].RunSynchronously();
                workk.Event += Message;
                workk.Event += Work;
                workk.InitializeEvent();
                Thread.Sleep(1000);
            }
            foreach (var item in tasks)
            {
                item.Dispose();
            }
            return totalCount;
        }

        private static void Work(object obj, EventArgs eventArgs)
        {
            var MesEventArgs = eventArgs as MesEventArgs;
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
