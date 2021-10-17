using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Command
{
    class UnknownCommand : Command
    {
        public UnknownCommand(Repository repository, string[] parameters) : base(repository, parameters)
        {

        }

        public override string Execute()
        {
            return "Вы ввели неизвестную команду!";
        }
    }
}
