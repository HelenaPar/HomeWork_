using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ConsoleApp1.Validator;

namespace ConsoleApp1.Command
{
    class SaveCommand : Command
    {
        public SaveCommand(Repository repository, string[] parameters) : base(repository, parameters)
        {
            validator = new SaveValidator(parameters);
        }
        public override string Execute()
        {
            Student[] students = repository.List();

            if (parameters[0].EndsWith(".json"))
            {
                using (Stream stream = File.Open(parameters[0], FileMode.Create))
                {
                     JsonSerializer.SerializeAsync(stream, students);
                }
            }
            else
            {
                parameters[0] += ".json";
                using (Stream stream = File.Open(parameters[0], FileMode.Create))
                {
                     JsonSerializer.SerializeAsync(stream, students);
                }
            }
            return "Done, check file!";
        }
    }
}
