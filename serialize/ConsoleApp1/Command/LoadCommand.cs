using ConsoleApp1.Validator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp1.Command
{
    class LoadCommand : Command
    {
        public LoadCommand(Repository repository, string[] parameters) : base(repository, parameters)
        {
            validator = new SaveValidator(parameters);
        }
        public async override Task<string> Execute()
        {
            StringBuilder sb = new StringBuilder();
            if (parameters[0].EndsWith(".json"))
            {
                using (Stream stream = File.Open(parameters[0], FileMode.Open))
                {
                    Student[] student = await JsonSerializer.DeserializeAsync<Student[]>(stream);
                    for (int i = 0; i < student.Length; i++)
                    {
                        sb.AppendLine(student[i].ToString());
                    }
                    return sb.ToString();
                }
            }
            else
            {
                parameters[0] += ".json";
                using (Stream stream = File.Open(parameters[0], FileMode.Open))
                {
                    //sb = await JsonSerializer.DeserializeAsync<StringBuilder>(stream);
                   // return sb.ToString();
                }
            }
           // return sb.ToString();
        }
    }
}
