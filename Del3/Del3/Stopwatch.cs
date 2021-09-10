using System;
using System.Collections.Generic;
using System.Text;

namespace Del3
{
    class Stopwatch
    {
        private int second = 1;
        private EventHandler eventt;

        public event EventHandler Event
        {
            add
            {
                eventt += value;
            }
            remove
            {
                eventt -= value;
            }
        }

        public void InitializeEvent()
        {
            while (true)
            {
                eventt(this, new MessageEventArgs(second, "Событие произошло..."));
                second++;
                System.Threading.Thread.Sleep(1000);
            }
        }

    }
}
