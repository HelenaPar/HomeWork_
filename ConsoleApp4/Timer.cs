using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Timer
    {
        private readonly Action action;
        private readonly int milsec;
        private readonly ManualResetEvent threadFinish = new ManualResetEvent(true);
        private Task task;
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
            task = new Task(() =>
            {
                threadFinish.Reset();
                IsRun = true;
                while (IsRun)
                {
                    action();
                    Thread.Sleep(milsec);
                }
                threadFinish.Set();
            });
            task.RunSynchronously();
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

