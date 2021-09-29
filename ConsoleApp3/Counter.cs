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
        int[] mass = new int[1000_000];
        Thread[] threads;
        private int[] sum = new int[10];
        private int mainsum;
        public int Calculate()
        {
            threads = new Thread[10];
            Random random = new Random();
            for (int i = 0; i < mass.Length; i++)
            { 
                mass[i] = random.Next(0, 1000_000);
            }
            foreach(Thread thread in threads)
            {
               // thread = new Thread(Calc);
                thread.Start();
            }
            return mainsum;
        }

        public void Calc()
        {
            for (int i = 0; i < 10; i++)
            {
                int suum = 0;
                int[] newmas = new int[100_000];
                mass.CopyTo(newmas, i * 100_000);
                for (int j = 0; j < newmas.Length; j++)
                {
                    suum += newmas[j];
                    j++;
                }
                sum[i] = suum;
                Console.WriteLine(sum[i]);
                mainsum = Interlocked.Add(ref mainsum, sum[i]);
            }
        }
    }
}
