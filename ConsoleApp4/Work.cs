using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Work
    {
        private EventHandler eventt;
        private int num;
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
            num++;
            eventt(this, new MesEventArgs($"Событие {num} произошло..."));
            System.Threading.Thread.Sleep(1000);
        }
    }
}
