using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Repository
    {
        private Student[] students = new Student[11];
        private int nextId = 1;

        public int Add(Student student)
        {
            for(int i = 0; i < students.Length; i++)
            {
                if(students[i] == null)
                {
                    student.id = nextId;
                   
                    students[i] = student;
                    return nextId++;
                }
            }
            return 0;
        }

        public bool EditAll(Student student)
        {
            for (int i = 0; i < students.Length; i++)
            {
                if (student.id == students[i]?.id)
                {
                    students[i].NewAll(student);
                    return true;
                }
            }
            return false;
        }

        public Student GetId(int id)
        {
            for (int i = 0; i < students.Length; i++)
            {
                if (id == students[i]?.id)
                {
                    return students[i];
                }
            }
            return null;
        }
        
        public bool Delete(int id)
        {
            for (int i = 0; i < students.Length; i++)
            {
                if(id == students[i]?.id)
                {
                    students[i] = null;
                    return true;
                }
            }
            return false;
        }

        public Student[] Find(string substring)
        {
            Student[] mass = new Student[students.Length];
            int k = 0;
            for (int i = 0; i < students.Length; i++)
            {
                if(students[i]?.name.Contains(substring, StringComparison.OrdinalIgnoreCase) == true ||
                    students[i]?.surname.Contains(substring, StringComparison.OrdinalIgnoreCase) == true)
                {
                    mass[k++] = students[i];
                }
            }
            Array.Resize(ref mass, k);
            return mass;
        }

        public Student[] List() 
        {
            Student[] mass = new Student[students.Length];
            int k = 0;
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i] != null)
                {
                    mass[k++] = students[i];
                }
            }
            Array.Resize(ref mass, k);
            return mass;
        }
    }
}
