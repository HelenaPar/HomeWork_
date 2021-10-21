using ConsoleApp1.Validator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Command
{
    class EditCommand : Command
    {
        public EditCommand(IRepository repository, string[] parameters) : base(repository, parameters)
        {
            validator = new EditValidator(parameters);
        }
        public override string Execute()
        {
           Student student = new Student(Convert.ToInt32(parameters[0]), parameters[1], parameters[2], parameters[3], Convert.ToInt32(parameters[4]));
           bool result = repository.EditAll(student);
           return result == true ?  "Запись успешно изменена!" : "Запись не изменена!";
        }
    }
}
