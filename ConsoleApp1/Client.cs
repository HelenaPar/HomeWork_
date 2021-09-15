using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Client : Person
    {
        public int ID { get; set; }
        public override string ToString()
        {
            return $"{IdPer} {Name} {Age} {ID}";
        }
    }
}
