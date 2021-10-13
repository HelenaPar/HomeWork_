using ConsoleApp1.Validator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Command
{
    class FindCommand : Command
    {
        public FindCommand(Repository repository, string[] parameters) : base(repository, parameters)
        {
            validator = new FindValidator(parameters);
        }
        public async override Task<string> Execute()
        {
            string nam = parameters[0];
            string name = nam.Substring(0, 1).ToUpper() + nam.Substring(1, nam.Length - 1).ToLower();           
            Student[] student = repository.Find(name);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < student.Length; i++)
            {
                sb.AppendLine(student[i].ToString());
            }
            return sb.ToString();
        }
    }
}
