using System;

namespace ChangeMakerTinoKerkhof
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * This program asks for an amount of money and gives the minimum 
             * amount of coins needed to make up that amount in change in the EU.
             */
            
            decimal[] changeWorthEU = { 2.0m, 1.0m, 0.5m, 0.2m, 0.1m, 0.05m, 0.02m, 0.01m };
            decimal moneyInHand;
            int change = 0;
            
            Console.WriteLine("Please tell me how much money in Euros you are holding. (use a \",\" as a decimal devider) ");
            moneyInHand = decimal.Parse(Console.ReadLine());

            if (moneyInHand > 0)
            {
                foreach (decimal coinWorth in changeWorthEU)
                {
                    change += (int)(moneyInHand / coinWorth);
                    moneyInHand -= coinWorth * (int)(moneyInHand / coinWorth);
                }
            }

            Console.WriteLine($"Minimum number of coins needed is {change}");
            Console.WriteLine("\npress any key to exit");
            Console.ReadKey();
        }
    }
}
