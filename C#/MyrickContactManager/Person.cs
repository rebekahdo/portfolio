/*
 * Rebekah Myrick
 * rebekahgmyrick@lewisu.edu
 * 6/6/2023 
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace MyrickContactManager
{
    // Person.cs
    internal class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (value >= 0)
                    age = value;
            }
        }

        // Constructor method
        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        // ToString() method
        public override string ToString()
        {
            return $"{FirstName} {LastName} - Age: {Age}";
        }
    }
}
