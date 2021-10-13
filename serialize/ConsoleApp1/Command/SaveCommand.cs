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
        public async override Task<string> Execute()
        {
            StringBuilder sb = new StringBuilder();
            Student[] students = repository.List();
            //for (int i = 0; i < student.Length; i++)
            //{
            //    sb.AppendLine(student[i].ToString());
            //}
            if (parameters[0].EndsWith(".json"))
            {
                using (Stream stream = File.Open(parameters[0], FileMode.Create))
                {
                    // await JsonSerializer.SerializeAsync(stream, sb.ToString());
                    for (int i = 0; i < students.Length; i++)
                    {
                        await JsonSerializer.SerializeAsync(stream, students[i].ToString());
                    }
                }
            } 
            //else
            //{
            //    parameters[0] += ".json";
            //    using (Stream stream = File.Open(parameters[0], FileMode.Create))
            //    {
            //        await JsonSerializer.SerializeAsync(stream, sb.ToString());
            //    }
            //}
            return "Done, check file!";
        }
    }
}
