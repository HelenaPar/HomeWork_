using System;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // var CreatePerson = PersonFactory.CreateManager(1, "Vitya", 20, 1);
            //var CreatePerson2 = PersonFactory.CreateEmployee(2, "Dima", 21, 1);
            //  var CreatePerson3 = PersonFactory.CreateClient(3, "Victor", 24, 1);
            Manager manager = new Manager()
            {
                IdPer = 1,
                Age = 20,
                Name = "Dima",
                ID = 1
            };
            var rep = new Repository<Manager>();
            rep.Add(manager);

            StringBuilder sb = new StringBuilder();
            Person[] man = rep.List();
            for (int i = 0; i < man.Length; i++)
            {
                sb.AppendLine(man[i].ToString());
            }
            sb.ToString();
        }
    }
}
