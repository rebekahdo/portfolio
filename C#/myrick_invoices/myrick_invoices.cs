/*
    Rebekah Myrick
    rebekahgmyrick@lewisu.edu
    5/14/23
*/
using System;

namespace Invoices
{
    class Program
    {
        static void Main(string[] args)
        {
            //define tax rates
            const double IL = 0.0875;
            const double WI = 0.0825;
            const double IN = 0.085;
            //output of Title tile with instructions
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("                                Invoice Printer");
            Console.WriteLine("********************************************************************************");
            Console.WriteLine();
            Console.WriteLine("This program will help you print a list of invoices for your company. You will");
            Console.WriteLine("enter them one at a time by specifying the customer's name, their type, the");
            Console.WriteLine("amount of the purchase, and the state in which they are located. This program");
            Console.WriteLine("will then calculate the amount the customer owes and print a summary. You can");
            Console.WriteLine("then enter another if you wish.");
            Console.WriteLine();

            int invoice = 1;
            bool repeat = true;

            //boolean loop for repeated input
            while (repeat)
            {
                //output invoice #
                Console.WriteLine($"*** Invoice #{invoice} ***");

                //ask for name input
                Console.Write("Please enter the customer's name: ");
                string name = Console.ReadLine();

                //ask for customer type
                Console.Write("Please enter the type of customer (R for retail or C for corporate): ");
                string type = Console.ReadLine();

                //ask for state
                Console.Write("Please enter the customer's state (IL, IN, or WI): ");
                string state = Console.ReadLine();

                //if state is IL/IN/WI from input
                if (state != "IL" && state != "IN" && state != "WI")
                {
                    //use IL tax rate if state is not recongnized
                    Console.WriteLine("I'm sorry, that is not a recognized state. We will use Illinois's sales tax rate instead.");
                    state = "IL";
                }

                //ask for amount
                Console.WriteLine("Please enter the amount of the purchase: ");
                string amount = Console.ReadLine();
                double purchase;

                if (!double.TryParse(amount, out purchase))
                {
                    Console.WriteLine("Invalid purchase amount. We will assume the purchase amount is $0.00.");
                    purchase = 0.0;
                }

                //define discount and tax
                double discount = 0;

                //if-else to define discount
                if (type == "R")
                {
                    //if else for retail to set discount based on amount of purchase
                    if (purchase >= 500)
                        discount = purchase * 0.2;
                    else if (purchase >= 250 && purchase < 500)
                        discount = purchase * 0.1;

                }
                //if else for corporate to set discount based on amount of purchase
                else if (type == "C")
                {
                    if (purchase >= 1000)
                        discount = purchase * 0.3;
                    else if (purchase >= 500 && purchase < 1000)
                        discount = purchase * 0.2;
                }
                else
                {
                    //error message and setting type to R
                    Console.WriteLine("I'm sorry, that is not a valid customer type. We will assume the customer is Retail.");
                    if (purchase >= 500)
                        discount = purchase * 0.2;
                    else if (purchase >= 250 && purchase < 500)
                        discount = purchase * 0.1;
                }

                //define tax rate
                double tax;
                switch (state)
                {
                    case "IL":
                        tax = IL;
                        break;
                    case "WI":
                        tax = WI;
                        break;
                    case "IN":
                        tax = IN;
                        break;
                    default:
                        Console.WriteLine("That is not a recognized state. We will use Illinois's sales tax rate.");
                        tax = IL;
                        break;
                }

                //setting taxes and price
                double taxes = purchase * tax;
                double price = purchase - discount + taxes;

                //output of the invoice 
                Console.WriteLine();
                Console.WriteLine($"Here is the invoice for customer {name} from {state}:");
                Console.WriteLine($"Cost of items purchased\t\t${amount:F2}");
                Console.WriteLine($"Discount applied\t\t${discount:F2}");
                Console.WriteLine($"Taxes applied\t\t\t${taxes:F2}");
                Console.WriteLine($"Final cost\t\t\t${price:F2}");
                Console.WriteLine();

                //ask user for next customer
                Console.Write("Do you have another customer (y or n)? ");
                string kb = Console.ReadLine();
                repeat = (kb.ToLower() == "y");

                //repeat
                invoice++;
            }

            //end of program output
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("                       Thank you for using this program.");
            Console.WriteLine("********************************************************************************");
        }
    }
}