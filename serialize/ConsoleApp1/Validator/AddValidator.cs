using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Validator
{
    class AddValidator : BaseValidator
    {
        public AddValidator(string[] parameters) : base(parameters)
        {

        }
        public override bool Validate()
        {
            bool name = ValidateName(parameters[0]);
            bool surname = ValidateSurname(parameters[1]);
            bool gen = ValidateGender(parameters[2]);
            bool age = ValidateAge(parameters[3]);
            if (name == true && surname == true && gen == true && age == true)
            {
                return true;
            }
            else return false;
        }
    }
}
