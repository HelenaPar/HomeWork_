using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Validator
{
    public interface IValidator
    {
        public bool Validate();
        public string ErrorMessage { get; set; }
    }
}
