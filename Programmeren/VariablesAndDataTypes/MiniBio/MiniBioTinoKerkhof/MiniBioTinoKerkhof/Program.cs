﻿using System;

namespace MiniBioTinoKerkhof
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * This methode builds a mini bio and gives it back to the user.
             */
            string myName;
            int myAge;
            string mySport;

            Console.WriteLine("Hello, What is your name?");
            myName = Console.ReadLine();
            Console.WriteLine("What is your age?");
            myAge = Int32.Parse(Console.ReadLine());
            Console.WriteLine("What is your favourate sport?");
            mySport = Console.ReadLine();

            Console.WriteLine($"{myName} is {myAge} years old and loves {mySport}");
            Console.ReadKey();
        }
    }
}
