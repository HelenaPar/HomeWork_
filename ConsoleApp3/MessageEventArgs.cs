using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class MessageEventArgs : EventArgs
    {
        public int Work { get; private set; }
        public int NotWork { get; private set; }


        public MessageEventArgs(int work, int notWork)
        {
            this.Work = work;
            this.NotWork = notWork;
        }

        public override string ToString()
        {
            return $"Work: {Work}, not work: {NotWork}";
        }
    }
}
