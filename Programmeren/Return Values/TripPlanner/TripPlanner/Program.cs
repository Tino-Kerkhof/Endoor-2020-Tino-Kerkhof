/*This program plans a trip with the user.
 */
using System;

namespace TripPlanner
{
    class Program
    {
        static void Main(string[] args)
        {
            Greeting();
            TravelTimeAndBudget();
            TimeDifference();
            RegionArea();

            Console.WriteLine("\nPress any key to exit");
            Console.ReadKey();
        }

        // This method greets the user and asks where they are going.
        private static void Greeting()
        {
            Console.Write("Welcome to Trip Planner.\n" +
                "What is your full Name? ");
            string userName = Console.ReadLine();
            Console.Write($"Hello, {userName}!\n" +
                $"What is your travel Destination? ");
            string userDestination = Console.ReadLine();
            Console.Write($"{userDestination} sounds great this time of year!\n" +
                $"*********\n");
        }

        private static void TravelTimeAndBudget()
        {
            bool validInput;

            decimal travelDays;
            do 
            {
                Console.Write("How many days is your trip? ");
                validInput = Decimal.TryParse(Console.ReadLine(), out travelDays);
            } while (!validInput);

            decimal spendingMoney;
            do
            {
                Console.Write("How much are you going to spend, in USD, on the trip? ");
                validInput = Decimal.TryParse(Console.ReadLine(), out spendingMoney);
            } while (!validInput);

            Console.Write("What is the letter curency symbol for you destination? ");
            string destinationCurency = Console.ReadLine();

            decimal curencyExchange;
            do
            {
                Console.Write($"How many {destinationCurency} are there in 1 USD? ");
                validInput = Decimal.TryParse(Console.ReadLine(), out curencyExchange);
            } while (!validInput);

            decimal daylySpending = spendingMoney / travelDays;
            decimal destinationSpendingMoney = curencyExchange * spendingMoney;
            decimal daylyDestinationSpendingMoney = (curencyExchange * spendingMoney) / travelDays;

            Console.Write($"If you are traveling for {travelDays} that is the same as {travelDays * 24} hours or " +
                $"{travelDays * 24 * 60} minutes.\n" +
                $"If you are going to spend {spendingMoney:C} that means dayly you can spend " +
                $"up to {daylySpending:C} in USD.\n" +
                $"Your total Budget in {destinationCurency} is {destinationSpendingMoney:N2} " +
                $"which per day is {daylyDestinationSpendingMoney:N2}.\n" +
                $"*********\n");
        }

        private static void TimeDifference()
        {
            bool validInput;
            int deltaTime;
            do
            {
                Console.Write("What is the time difference in hours, between your home and your\n" +
                    "destination, with your home being 0. ");
                validInput = Int32.TryParse(Console.ReadLine(), out deltaTime);
            } while (!validInput);

            int midnightTime = (24 + deltaTime) % 24;
            int noonTime = (36 + deltaTime) % 24;
            Console.Write($"That means when it's midnight at home it will be {midnightTime}:00 in your \n" +
                $"traveldestination and when it's noon at home it will be {noonTime}:00.\n" +
                $"********\n");
        }

        private static void RegionArea()
        {
            bool validInput;
            decimal areaSI;
            decimal kilometersToMiles = 0.62138818119679m;
            decimal areaSItoImp = kilometersToMiles * kilometersToMiles;

            do
            {
                Console.Write("What is the area of your destination's country/region in square\n" +
                    "kilometers? ");
                validInput = Decimal.TryParse(Console.ReadLine(), out areaSI);
            } while (!validInput);

            decimal areaImp = areaSI * areaSItoImp;
            Console.Write($"That is {areaImp:N1} square miles.\n" +
                $"*******\n");
        }
    }
}
