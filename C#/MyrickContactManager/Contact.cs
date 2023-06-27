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
    // Contact.cs
    internal class Contact : Person, Detailed
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone1 { get; set; }
        public string Email { get; set; }
 


        // Constructor method
        public Contact(string firstName, string lastName, int age, string address, string city, string state, string zip, string phone1, string email)
            : base(firstName, lastName, age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Address = address;
            City = city;
            State = state;
            Zip = zip;
            Phone1 = phone1;
            Email = email;

        }

        // ToString() method
        public override string ToString()
        {
            return $"{base.ToString()}\t{State}\t{Email}\t{Phone1}";
        }

        // GetDetailedDescription() method
        public string GetDetailedDescription()
        {
            return $"Name: {FirstName} {LastName}\nPhone: {Phone1}\nEmail: {Email}\nState: {State}\nAge: {Age}\n";
        }
    }
}
