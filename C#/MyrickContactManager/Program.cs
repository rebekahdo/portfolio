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
    // Program.cs
    public class Program
    {
        static List<Contact> contacts = new List<Contact>();

        //Main method
        static void Main(string[] args)
        {
            // Banner output
            PrintWelcome();

            //ask for user input
            Console.Write("Enter the name of the contacts file: ");
            string fileName = Console.ReadLine();

            //check if file exists
            if (!File.Exists(fileName))
            {
                //output if file doesn't exist
                Console.WriteLine("File not found. Program will exit.");
                return;
            }
            //read file
            ReadContactsFromFile(fileName);
            //output how many contacts were read
            Console.WriteLine($"{contacts.Count} contacts were read from the file.");
            //exit program boolean if file exists
            bool exitProgram = false;

            while (!exitProgram)
            {
                //print menu method
                PrintMenu();
                //get user input
                Console.Write("Enter the number of your choice: ");
                string choice = Console.ReadLine();
                //output correct method based on choice
                switch (choice)
                {
                    case "1":
                        ListContactsWithLastName();
                        break;
                    case "2":
                        ListContactsInState();
                        break;
                    case "3":
                        ListContactsInAgeRange();
                        break;
                    case "4":
                        SaveContactsToFile();
                        break;
                    case "5":
                        exitProgram = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }
        //banner output method
        static void PrintWelcome()
        {
            //banner center text
            string banner = "Contact Manager";
            int bannerWidth = 80;
            string centeredBanner = banner.PadLeft((banner.Length + bannerWidth) / 2).PadRight(bannerWidth);
            Console.WriteLine("********************************************************************************");
            Console.WriteLine(centeredBanner);
            Console.WriteLine("********************************************************************************");
            Console.WriteLine();
        }
        //menu output
        static void PrintMenu()
        {
            Console.WriteLine(" ");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. List contacts with a particular last name.");
            Console.WriteLine("2. List contacts from a state.");
            Console.WriteLine("3. List contacts in an age range.");
            Console.WriteLine("4. Save contacts to a file.");
            Console.WriteLine("5. Quit");
        }
        //read contacts method
        static void ReadContactsFromFile(string fileName)
        {
            //set up contacts in array
            string[] lines = File.ReadAllLines(fileName);

            for (int i = 1; i < lines.Length; i++)
            {
                //split contacts at line break
                string[] data = lines[i].Split('\t');

                //assign data 
                string firstName = data[0];
                string lastName = data[1];
                int age = int.Parse(data[2]);
                string address = data[3];
                string city = data[4];
                string state = data[5];
                string zip = data[6];
                string phone1 = data[7];
                string email = data[8];

                //create object with data
                Contact contact = new Contact(firstName, lastName, age, address, city, state, zip, phone1, email);
                contacts.Add(contact);
            }
        }
        // ListContactsWithLastName() method
        static void ListContactsWithLastName()
        {
            //get user input
            Console.Write("Enter last name to find: ");
            string lastName = Console.ReadLine();
            //check if contact is found
            bool found = false;
            //find contact
            foreach (Contact contact in contacts)
            {
                //with last name
                if (contact.LastName == lastName)
                {
                    //output description
                    Console.WriteLine(contact.GetDetailedDescription());
                    //output found true
                    found = true;
                }
            }
            //if not found
            if (!found)
            {
                //output
                Console.WriteLine("No Contacts Found");
            }
        }
        // ListContactsInState() method
        static void ListContactsInState()
        {
            //get user input
            Console.Write("Enter state: ");
            string state = Console.ReadLine();
            bool found = false;

            foreach (Contact contact in contacts)
            {
                if (contact.State == state)
                {
                    Console.WriteLine(contact.GetDetailedDescription());
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("No Contacts Found");
            }
        }
        // ListContactsInAgeRange() method
        static void ListContactsInAgeRange()
        {
            //get user input in range
            Console.Write("Enter minimum age: ");
            int minAge = int.Parse(Console.ReadLine());

            Console.Write("Enter maximum age: ");
            int maxAge = int.Parse(Console.ReadLine());
            //check if found using boolean
            bool found = false;

            foreach (Contact contact in contacts)
            {
                if (contact.Age >= minAge && contact.Age <= maxAge)
                {
                    Console.WriteLine(contact.GetDetailedDescription());
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("No Contacts Found");
            }
        }
        // SaveContactsToFile() method
        static void SaveContactsToFile()
        {
            Console.Write("Enter the name of the file to save contacts: ");
            string fileName = Console.ReadLine();

            ContactWriter contactWriter = new ContactWriter();
            contactWriter.WriteContactsToFile(fileName, contacts);

            Console.WriteLine("Contacts were saved successfully.");
        }
    }
}