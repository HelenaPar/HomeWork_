using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Validator
{
    public abstract class BaseValidator : IValidator
    {
        public string ErrorMessage { get; set; }
        protected readonly string[] parameters;
        protected BaseValidator(string[] parameters)
        {
            this.parameters = parameters;
        }

        public abstract bool Validate();

        protected bool ValidateFile(string file)
        {
            if(file.EndsWith(".json") || file.EndsWith(".xml") || !file.Contains("."))
            {
                return true;
            }
            ErrorMessage += "Wrong name of file!\n";
            
            return false;
        }

        protected bool ValidateId(string id)
        {
            if (int.TryParse(id, out var result))
            {
                return true;
            }
            ErrorMessage += "Wrong id!\n";
            
            return false;
        }
       
        protected bool ValidateName(string nam) 
        {
            char[] num = new char[] {'1','2','3','4','5','6','7','8','9','0' };
            if (nam.Length < 50)
            {
                 if(nam.IndexOfAny(num) == -1)
                 { 
                     return true;
                 }
            }
            ErrorMessage += "Wrong name!\n";
            return false;
        }
        protected bool ValidateSurname(string sur)
        {
            char[] num = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            if (sur.Length < 50)
            {
                if (sur.IndexOfAny(num) == -1)
                {
                    return true;
                }
            }
            ErrorMessage += "Wrong surname!\n";
           
            return false;
        }
        protected bool ValidateAge(string age)
        {
            int Age = int.Parse(age);
            if (Age > 18 && Age < 99)
            {
                return true;
            }
            ErrorMessage += "Wrong age!\n";
            
            return false;
        }
        protected bool ValidateGender(string gender)
        {
            if(gender == "М" || gender == "Ж" || gender == "муж" || gender == "жен" || gender == "мужской" || gender == "женский" || gender == "men" || gender == "woman")
            {
                return true;
            }
            ErrorMessage += "Wrong gender!\n";
           
            return false;
        }
    }
}
