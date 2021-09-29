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
        public Action action;
        public int milsec;
        public Thread thread;
        private int start = 0;
        public Timer(Action act, int second)
        {
            this.action = act;
            this.milsec = second * 1000;
        }

        private void Action()
        {
            start = 1;
            while (true)
            { 
                action();
                Thread.Sleep(milsec);
            }
        }

        public void Start()
        {
            if (start == 0)
            {
                thread = new Thread(Action);
                thread.Start();
            }
            else thread.Start();
        }

        public void Restart()
        {
            Stop();
            thread = new Thread(Action);
            thread.Start();
        }

        public void Stop()
        {
            thread.Join();
        }
    }
}
