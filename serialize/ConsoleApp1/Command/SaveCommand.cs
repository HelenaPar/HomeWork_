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
            if (!parameters[0].EndsWith(".json"))
            {
                parameters[0] += ".json";
            }
            using (Stream stream = File.Open(parameters[0], FileMode.Create))
            {
                Task task = JsonSerializer.SerializeAsync(stream, students);
                task.Wait();
            }
            return "Done, check file!";
        }
    }
}
