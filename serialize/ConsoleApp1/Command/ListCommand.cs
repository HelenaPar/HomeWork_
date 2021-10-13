using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Validator;

namespace ConsoleApp1.Command
{
    class ListCommand : Command
    {
        //Student student;
        public ListCommand(Repository repository, string[] parametrs) : base(repository, parametrs)
        {
            
        }
        public async override Task<string> Execute() 
        {          
           StringBuilder sb = new StringBuilder();
           Student[] student = repository.List();
           for(int i = 0; i < student.Length; i++)
            {
                sb.AppendLine(student[i].ToString());
            }
            return sb.ToString(); 
        }
    }
}
