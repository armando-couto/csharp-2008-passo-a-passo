#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace StructsAndEnums
{
    class Program
    {
        static void Entrance()
        {
            Month first = Month.December;
            Console.WriteLine(first);
            first++;
            Console.WriteLine(first);

            Date defaultDate = new Date();
            Console.WriteLine(defaultDate);

            Date halloween = new Date(2008, Month.October, 31);
            Console.WriteLine(halloween);
        }

        static void Main()
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
