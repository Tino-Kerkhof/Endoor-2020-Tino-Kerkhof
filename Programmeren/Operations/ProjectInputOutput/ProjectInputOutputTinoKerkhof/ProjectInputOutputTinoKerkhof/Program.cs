﻿using System;

namespace ProjectInputOutputTinoKerkhof
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * This program asks the user to give the amount of money he/she has 
             * and tells him/her how many chocolatebars he can buy.
             */
            decimal myMoney;
            decimal chocolatePrice = 1.50m;
            decimal numberOfChocolates;

            Console.Write("How much money do you have? (use \",\" as a decimal devider) ");
            myMoney = decimal.Parse(Console.ReadLine());

            numberOfChocolates = Math.Floor(myMoney / chocolatePrice);

            Console.WriteLine($"The Price of chocalate bars are {chocolatePrice:C}.");
            Console.WriteLine($"You can buy {numberOfChocolates} chocolate bars.");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
