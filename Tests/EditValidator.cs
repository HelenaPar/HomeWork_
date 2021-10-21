using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Validator
{
    internal class EditValidator : BaseValidator
    {
        public EditValidator(string[] parameters) : base(parameters)
        {

        }
        public override bool Validate()
        {
            bool id = ValidateId(parameters[0]);
            bool name = ValidateName(parameters[1]);
            bool surname = ValidateSurname(parameters[2]);
            bool gen = ValidateGender(parameters[3]);
            bool age = ValidateAge(parameters[4]);
            if (id == true && name == true && surname == true && gen == true && age == true)
            {
                return true;
            }
            else return false;
        }
    }
}
