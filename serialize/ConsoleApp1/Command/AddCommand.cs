using ConsoleApp1.Validator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Command
{
    class AddCommand : Command
    {
        public AddCommand(Repository repository, string[] parametrs) : base(repository, parametrs)
        {
            validator = new AddValidator(parameters);
        }

        public async override Task<string> Execute()
        {
            string nam = parameters[0];
            string name = nam.Substring(0, 1).ToUpper() + nam.Substring(1, nam.Length - 1).ToLower();
            string sur = parameters[1];
            string surname = sur.Substring(0, 1).ToUpper() + sur.Substring(1, sur.Length - 1).ToLower();
            Student student = new Student(0, name, surname, this.parameters[2], Convert.ToInt32(this.parameters[3]));        
            int result = repository.Add(student);
            return result == 0 ? "Запись не добавлена!" : "Запись успешно добавлена!";
        }
    }
}
