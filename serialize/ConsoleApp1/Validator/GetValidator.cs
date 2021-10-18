using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Validator
{
    class GetValidator : BaseValidator
    {
        public GetValidator(string[] parameters) : base(parameters)
        {

        }
        public override bool Validate()
        {
            return ValidateId(parameters[0]);
        }
    }
}
