using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Repository<T> where T: Person
    {
        private T[] persons = new T[100];
        int nextId = 1;
         public string Add(T person)
         {
            for (int i = 0; i < persons.Length; i++)
            {
                if (persons[i] == null)
                {
                    person.Id = nextId;
                    persons[i] = person;
                    nextId++;
                    return "Добавлен!";
                }
            }
            return "Не добавлено!";
        }

        public string Delete(int id)
        {
            for (int i = 0; i < persons.Length; i++)
            {
                Person person = new Manager();

                if (id == persons[i]?.Id)
                {
                    persons[i] = null;
                    return "Удалено!";
                }
            }
            return "Не удалено!";
        }

        public Person Get(int id)
        {
            for (int i = 0; i < persons.Length; i++)
            {
                if (id == persons[i]?.Id)
                {
                    return persons[i];
                }
            }
            return null;
        }
        public T[] List()
        {
            T[] mass = new T[persons.Length];
            int k = 0;
            for (int i = 0; i < persons.Length; i++)
            {
                if (persons[i] != null)
                {
                    mass[k++] = persons[i];
                }
            }
            Array.Resize(ref mass, k);
            return mass;
        }

        public T[] Find(string substring)
        {
            T[] mass = new T[persons.Length];
            int k = 0;
            for (int i = 0; i < persons.Length; i++)
            {
                if (persons[i]?.Name.Contains(substring, StringComparison.OrdinalIgnoreCase) == true)
                {
                    mass[k++] = persons[i];
                }
            }
            Array.Resize(ref mass, k);
            return mass;
        }
    }
}

