using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Command
{
    class RandCommand : Command
    {
        public RandCommand(Repository repository, string[] parameters) : base(repository, parameters)
        {

        }
        public override string Execute()
        {
            Student[] student = repository.List();
            Random rnd = new Random();
            int value = rnd.Next(0, student.Length);
            return student[value].ToString();
        }
    }
}
