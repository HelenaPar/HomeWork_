using ConsoleApp1.Command;
using System;

namespace ConsoleApp1
{

    class Program
    {
        static void Main(string[] args)
        {
            Repository repository = new Repository();
            while (true)
            {
                string input = Console.ReadLine();
                var parser = new CommandParser(repository);
                var command = parser.Parse(input);
                var result = command.ExecuteWithValidation();
                Console.WriteLine(result);
            }
        }
    }
}
