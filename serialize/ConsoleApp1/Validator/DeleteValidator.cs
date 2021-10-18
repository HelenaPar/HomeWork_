using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Validator
{
    class DeleteValidator : BaseValidator
    {
        public DeleteValidator(string[] parameters):base(parameters)
        {

        }
        public override bool Validate()
        {
            return ValidateId(parameters[0]);
        }
    }
}
