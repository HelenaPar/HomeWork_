using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class MesEventArgs : EventArgs
    {
        public string Message { get; private set; }
        public MesEventArgs(string message)
        {
            this.Message = message;
        }

        public override string ToString()
        {
            return $"{Message}";
        }
    }
}
