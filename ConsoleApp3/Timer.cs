using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Timer
    {
        private readonly Action action;
        private readonly int milsec;
        private readonly ManualResetEvent threadFinish = new ManualResetEvent(true);
        public bool IsRun { get; private set; }
        public Timer(Action act, int second)
        {
            this.action = act;
            this.milsec = second * 1000;
        }

        public void Start()
        {
            if (IsRun)
            {
                return;
            }
            IsRun = true;
            Thread thread = new Thread(() =>
            {
                threadFinish.Reset();
                
                while (IsRun)
                {
                    action();
                    Thread.Sleep(milsec);
                }
                threadFinish.Set();
            });
            thread.Start();
        }

        public void Restart()
        {
            Stop();
            Console.WriteLine();
            Start();
        }

        public void Stop()
        {
            IsRun = false;
            threadFinish.WaitOne();
        }
    }
}
