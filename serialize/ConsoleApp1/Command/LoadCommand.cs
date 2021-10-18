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
        public override string Execute()
        {
            Student[] mainStud = repository.List();
            if (!parameters[0].EndsWith(".json"))
            {
                parameters[0] += ".json";
            }
            Serialize();
            return "Done!";
        }

        private void Serialize()
        {
            Student[] mainStud = repository.List();
            using (Stream stream = File.Open(parameters[0], FileMode.Open))
            {
                Student[] students = JsonSerializer.DeserializeAsync<Student[]>(stream).Result;
                for (int i = 0; i < students.Length; i++) 
                {
                    if (mainStud.FirstOrDefault(s => s.id == students[i].id) != null)
                    { 
                        Student st = new Student(students[i].id, students[i].name, students[i].surname, students[i].gender, students[i].age);
                        repository.EditAll(st);
                    }
                    else repository.Add(students[i]);
                }
             }
          }
       }
    }

