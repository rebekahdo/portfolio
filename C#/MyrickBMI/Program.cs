/*
 *  Rebekah Myrick
 *  rebekahgmyrick@lewisu.edu
 *  5/19/23
 */
using System;
namespace MyrickBMI
{
    class Program
    {
        static void Main(string[] args)
        {
            //banner output
            Console.WriteLine(" ");
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("                                BMI Calculator");
            Console.WriteLine("********************************************************************************");
            Console.WriteLine(" ");

            //get user input
            Console.Write("Enter height in inches: ");
            double heightC;
            heightC = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter mass in pounds: ");
            double weightC;
            weightC = Convert.ToDouble(Console.ReadLine());

            //convert from inches to meters
            double heightA = heightC * 0.0254;
            //convert from lbs to kilograms
            double weightA = weightC * 0.453592;
            //calculate bmi
            double bmi = weightA / (heightA * heightA);

            //output bmi
            Console.WriteLine("Your BMI is {0:F2}", bmi);

            //output condition using table
            if (bmi < 18.5)
            {
                Console.WriteLine("You are underweight.");
            }
            else if (bmi >= 18.5 & bmi <= 24.9)
            {
                Console.WriteLine("You are normal weight.");
            }
            else if (bmi >= 25.0 & bmi <= 29.9)
            {
                Console.WriteLine("You are overweight.");
            }
            else
            {
                Console.WriteLine("You are obese.");
            }
            //banner output
            Console.WriteLine(" ");
            Console.WriteLine("********************************************************************************");
            Console.WriteLine(" ");
        }
    }
}