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
            threads = new Thread[10];
            for (int i = 0; i < 10; i++)
            {
                int[] part = array.Skip(i * 100_000).Take(100_000).ToArray();
                threads[i] = new Thread(InternalCalc);
                threads[i].Start(part);
            }
            foreach (var item in threads)
            {
                item.Join();
            }
            return totalCount;
        }

        private void InternalCalc(object obj)
        {
            int[] partOfArray = obj as int[];
            foreach (int item in partOfArray)
            {
                Interlocked.Add(ref totalCount, item);
            }
            Thread.Sleep(new Random().Next(1000, 3000));
            Interlocked.Decrement(ref work);
            Interlocked.Increment(ref notWork);
            finishEvent?.Invoke(this, new MessageEventArgs(work, notWork));
        }
    }
}



