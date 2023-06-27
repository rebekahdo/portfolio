/*
 *  Rebekah Myrick
 *  rebekahgmyrick@lewisu.edu
 *  5/19/23
 */
using System;
using System.Collections.Generic;
using System.IO;

namespace PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {

            //banner output
            string banner = "Password Generator";
            int bannerWidth = 80;
            string centeredBanner = banner.PadLeft((banner.Length + bannerWidth) / 2).PadRight(bannerWidth);

            Console.WriteLine("********************************************************************************");
            Console.WriteLine(centeredBanner);
            Console.WriteLine("********************************************************************************");
            Console.WriteLine();
            Console.WriteLine("This program enables you to run three different programs I've written. Each");
            Console.WriteLine("program illustrates some basic skill or skills we have learned in class in C#.");
            Console.WriteLine("Choose which program you want to run from the main menu, and enter 4 to exit.");
            Console.WriteLine();

            //get user input
            Console.Write("Enter the name of the word file: ");
            string path = Console.ReadLine();
            string[] words = File.ReadAllLines(path);

            //display the available words
            Console.WriteLine();
            Console.WriteLine("Here are the words that were read:");
            Console.WriteLine();

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine();

            //ask for number of passwords
            Console.Write("How many random passwords do you want? ");
            int number = int.Parse(Console.ReadLine());

            //output passwords
            Console.WriteLine();
            Console.WriteLine("Generated Passwords:");
            Console.WriteLine();

            Random random = new Random();

            for (int i = 0; i < number; i++)
            {
                string password = GeneratePassword(words, random);
                Console.WriteLine(password);
            }

            Console.WriteLine();
            Console.WriteLine("********************************************************************************");
    }

        static string GeneratePassword(string[] words, Random random)
        {
            string[] word1 = words[random.Next(words.Length)].Split(' ');
            string[] word2 = words[random.Next(words.Length)].Split(' ');
            string[] word3 = words[random.Next(words.Length)].Split(' ');

            string password = $"{word1[0]}{word2[0]}{word3[0]}";

            //replace s characters with $ characters
            password = password.Replace('s', '$');

            //replace i characters with ! characters
            password = password.Replace('i', '!');

            //capitalize the second word
            password += Capitalize(word2[1]);

            return password;
        }

        static string Capitalize(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return word;
            }

            char[] letters = word.ToCharArray();
            letters[0] = char.ToUpper(letters[0]);
            return new string(letters);
        }
    }
}
