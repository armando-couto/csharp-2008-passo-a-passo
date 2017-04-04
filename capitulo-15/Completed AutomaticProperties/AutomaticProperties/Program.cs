using System;
using System.Collections.Generic;
using System.Text;

namespace AutomaticProperties
{
    class Program
    {
        static void Entrance()
        {
            Polygon square = new Polygon();
            Polygon triangle = new Polygon { NumSides = 3 };
            Polygon pentagon = new Polygon { SideLength = 15.5, NumSides = 5 };

            Console.WriteLine("Square: number of side is {0}, length of each side is {1}", square.NumSides, square.SideLength);
            Console.WriteLine("Triangle: number of side is {0}, length of each side is {1}", triangle.NumSides, triangle.SideLength);
            Console.WriteLine("Pentagon: number of side is {0}, length of each side is {1}", pentagon.NumSides, pentagon.SideLength);
        }

        static void Main(string[] args)
        {
            try
            {
                Entrance();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
