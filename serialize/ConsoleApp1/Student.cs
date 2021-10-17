using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Student
    {
        //public int id;
        //public string name;
        //public string surname;
        //private string gender;
        //private int age;
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string gender { get; set; }
        public int age { get; set; }

        public Student() 
        { }

        public Student(int id, string name, string surname, string gender, int age)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.gender = gender;
            this.age = age;
        }
        public void NewAll(Student student)
        {
            name = student.name;
            age = student.age;
            surname = student.surname;
            gender = student.gender;
        }


        public override string ToString()
        {
            return $"{id} {name} {surname} {gender} {age}";
        }
    }
}
