// Rebekah Myrick
// Paint.cs
// Purpose of program: Record the width, length, and height of the room in inches. Record the number of windows and number of doors. Outputs the surface area of a room in square feet.
using System;
namespace edu.lewisu.cs.cpsc230
{
    internal class Paint
    {
        static double calculateWallArea(double length, double width, double height, double windowArea, double doorArea)
        {
            return ((2 * height) * (length + width) / 144) - (doorArea + windowArea);
        }
        static void Main(String[] args)
        {
            Console.Write("Enter number of rooms to paint: ");
            int rooms;
            rooms = Convert.ToInt32(Console.ReadLine());

            double totalArea = 0;   


            for(int i=0; i < rooms; i++)
            {
                Console.Write("Enter length of room in inches: ");
                double length;
                length = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter width of room in inches: ");
                double width;
                width = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter height of room in inches: ");
                double height;
                height = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter number of doors: ");
                double doors;
                doors = Convert.ToDouble(Console.ReadLine());
                double doorArea = doors * 21;
                Console.Write("Enter number of windows: ");
                double windows;
                windows = Convert.ToDouble(Console.ReadLine());
                double windowArea = windows * 15;

                double wallArea = calculateWallArea(length, width, height, windowArea, doorArea);
                Console.WriteLine("The surface area of this room is {0:F2}", wallArea + " square feet");
                totalArea += wallArea;
            }

            Console.WriteLine("The total surface area to paint is {0:F2}",  totalArea + " square feet");

        }
    }
}
