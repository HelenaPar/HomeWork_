using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class PersonFactory
    {
        private static T CreatePerson<T>(int id, string name, int age) 
            where T: Person, new()
        {
            return new T()
            {
                Id = id,
                Name = name,
                Age = age
            };
        }

        public static Manager CreateManager(int id, string name, int age, int managerid)
        {
            var manager = CreatePerson<Manager>(id, name, age);
            manager.IDMan = managerid;
            return manager;
        }
        public static Employee CreateEmployee(int id, string name, int age, int employeeid)
        {
            var employee = CreatePerson<Employee>(id, name, age);
            employee.IDEmp = employeeid;
            return employee;
        }
        public static Client CreateClient(int id, string name, int age, int clientid)
        {
            var client = CreatePerson<Client>(id, name, age);
            client.IDCl = clientid;
            return client;
        }
    }
}
