using System;

namespace ProjectSunDay
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i<=105; i++)
            {
                if (i % 3 == 0)
                    Console.Write("Sun");
                if (i % 5 == 0)
                    Console.Write("Day");
                if (i % 7 == 0)
                    Console.Write("Today");

                if (i % 3 == 0 || i % 5 == 0 || i % 7 == 0)
                    Console.WriteLine("!");
                else
                    Console.WriteLine(i);
            }
            Console.WriteLine("\nPress any key to exit");
            Console.ReadKey();

            /* This works, because there is a clear order to the shouted names.
             * If there wasn't the flow statements would be:
             * 
             * if (i % 3 == 0 && i % 5 == 0 && i % 7 == 0) 
             *     Console.WriteLine("SunDayToday!");
             * else if (i % 3 == 0 && i % 5 == 0) 
             *     Console.WriteLine("SunDay!");
             * else if (i % 3 == 0 && i % 7 == 0) 
             *     Console.WriteLine("SunToday!");
             * else if (i % 5 == 0 && i % 7 == 0) 
             *     Console.WriteLine("DayToday!");
             * else if (i % 3 == 0) 
             *     Console.WriteLine("Sun!");
             * else if (i % 5 == 0) 
             *     Console.WriteLine("Day!");
             * else if (i % 7 == 0) 
             *     Console.WriteLine("Today!");
             * else 
             *     Console.WriteLine(i);
             * 
             * 
             */
        }
    }
}
