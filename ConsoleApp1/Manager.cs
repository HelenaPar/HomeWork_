using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Manager : Person
    {
        public int IDPer { get; set; }
        public override string ToString()
        {
            return $"{Id} {Name} {Age} {IDPer}";
        }
    }
}
