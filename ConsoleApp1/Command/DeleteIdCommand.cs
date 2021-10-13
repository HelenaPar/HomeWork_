using ConsoleApp1.Validator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Command
{
    class DeleteCommand : Command
    {
        public DeleteCommand(Repository repository, string[] parameters) : base(repository, parameters)
        {
            validator = new DeleteValidator(parameters);
        }
        public async override Task<string> Execute()
        {
            bool result = repository.Delete(Convert.ToInt32(this.parameters[0]));
            return result == true ? "Запись успешно удалена!" : "Запись не удалена!";
        }
    }
}
