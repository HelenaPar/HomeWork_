using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class MesEventArgs : EventArgs
    {
        public int Work { get; private set; }
        public int NotWork { get; private set; }

        public MesEventArgs(int work, int notWork)
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
