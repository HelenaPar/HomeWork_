using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Client : Person
    {
        public int IDCl { get; set; }
        public override string ToString()
        {
            return $"{Id} {Name} {Age} {IDCl}";
        }
    }
}
