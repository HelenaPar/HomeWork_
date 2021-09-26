using System;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager()
            {
                Id = 1,
                Age = 20,
                Name = "Dima",
                ManagerID = 1
            };
            Manager manager2 = new Manager()
            {
                Id = 2,
                Age = 22,
                Name = "Dima",
                ManagerID = 2
            };
            var rep = new Repository<Manager>();
            Console.WriteLine(rep.Add(manager));
            Console.WriteLine(rep.Add(manager2));
            Console.WriteLine("List");
            ListCommand(rep);
            Console.WriteLine("Get 1");
            var per = rep.Get(1);
            Console.WriteLine(per.ToString());
            Console.WriteLine("Delete 1");
            var del = rep.Delete(1);
            Console.WriteLine(del);
            
            ListCommand(rep);
            Console.WriteLine("Find");
            FindCommand(rep, "Dima");
        }

        public static void ListCommand(Repository<Manager> rep)
        {
            StringBuilder sb = new StringBuilder();
            Person[] man = rep.List();
            for (int i = 0; i < man.Length; i++)
            {
                sb.AppendLine(man[i].ToString());
            }
            Console.WriteLine("List");
            Console.WriteLine(sb.ToString());
        }

        public static void FindCommand(Repository<Manager> rep, string name)
        {
            StringBuilder sb = new StringBuilder();
            Person[] man = rep.Find(name);
            for (int i = 0; i < man.Length; i++)
            {
                sb.AppendLine(man[i].ToString());
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
