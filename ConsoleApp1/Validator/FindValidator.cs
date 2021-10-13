using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Validator
{
    class FindValidator : BaseValidator
    {
        public FindValidator(string[] parameters) : base(parameters)
        {

        }
        public override bool Validate()
        {
            bool name = ValidateName(parameters[0]);
            if(name == true)
            {
                return true;
            }
            ErrorMessage = new Task<string>(() =>
            {
                return "Wrong name or surname!\n";
            });
            //ErrorMessage = "Wrong name or surname!\n";
            return false;
        }
    }
}
