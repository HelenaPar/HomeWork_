using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Validator
{
    class SaveValidator : BaseValidator
    {
        public SaveValidator(string[] parameters) : base(parameters)
        {

        }
        public override bool Validate()
        {
            return ValidateFile(parameters[0]);
        }
    }
}
