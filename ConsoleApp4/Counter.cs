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
        private static int work = 10;
        private static int notWork = 0;
        private EventHandler finishEvent;

        public event EventHandler FinishEvent
        {
            add
            {
                finishEvent += value;
            }
            remove
            {
                finishEvent -= value;
            }
        }

        public Counter(int[] array)
        {
            this.array = array;
        }
        public long Calculate()
        {
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
                    }
                Interlocked.Decrement(ref work);
                Interlocked.Increment(ref notWork);
                finishEvent?.Invoke(this, new MesEventArgs(work, notWork));
                });
                tasks[i].Start();
                Thread.Sleep(1000);
            }
            foreach (var item in tasks)
            {
                item.Dispose();
            }
            return totalCount;
        }
    }
}

