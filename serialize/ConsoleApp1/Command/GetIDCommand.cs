using ConsoleApp1.Validator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Command
{
    class GetCommand : Command
    {
        public GetCommand(Repository repository, string[] parameters) : base(repository, parameters)
        {
            validator = new GetValidator(parameters);
        }
        public override string Execute()
        {
            Student student = repository.GetId(Convert.ToInt32(this.parameters[0]));
            return student.ToString();
        }
    }
}
