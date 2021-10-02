using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Work
    {
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
            eventt(this, new MessageEventArgs("Событие произошло..."));
            System.Threading.Thread.Sleep(2000);
        }
    }
}
