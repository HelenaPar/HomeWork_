using System;
using System.Collections.Generic;
using System.Text;

namespace Del3
{
    class MessageEventArgs : EventArgs
    {
        public string Message { get; private set; }
        public int Second { get; private set; }

        public MessageEventArgs(int second, string message)
        {
            Second = second;
            Message = message;
        }

        public override string ToString()
        {
            return $"{Message}";
        }
    }
}
