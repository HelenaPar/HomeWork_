using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Command
{
    public class CommandParser
    {
        private Repository repository;

        public CommandParser(Repository repository)
        {
            this.repository = repository;
        }

        public Command Parse(string input)
        {
            var inputArr = input.Split();
            string[] parameters = new string[6];
            int index = 0;
            foreach(var item in inputArr)
            {
                if(!string.IsNullOrEmpty(item) && index < parameters.Length && item != inputArr[0])
                {
                    parameters[index] = item;
                    index++;
                }
            }
            switch(inputArr[0]?.ToUpper())
            {
                case "ADD":
                    return new AddCommand(repository, parameters);
                case "EDIT":
                    return new EditCommand(repository, parameters);
                case "GET":
                    return new GetCommand(repository, parameters);
                case "DELETE":
                    return new DeleteCommand(repository, parameters);
                case "LIST":
                    return new ListCommand(repository, parameters);
                case "RAND":
                    return new RandCommand(repository, parameters);
                case "FIND":
                    return new FindCommand(repository, parameters);
                case "SAVE":
                    return new SaveCommand(repository, parameters);
                case "LOAD":
                    return new LoadCommand(repository, parameters);
                default:
                    return new UnknownCommand(repository, parameters);
            }
        }
    }
}
