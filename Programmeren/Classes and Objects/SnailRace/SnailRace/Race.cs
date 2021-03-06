﻿using System;
using System.Linq;
using System.Threading;

namespace SnailRace
{
    class Race
    {
        static void Main()
        {
            decimal dt = 10.0m; // sec
            decimal finish = 330.0m; // mm
            string snailName;
            decimal snailMinSpeed;
            decimal snailMaxSpeed;
            decimal snailMove;
            int numberOfSnails;
            bool validInput;

            do
            {
                do
                {
                    Console.Write("How many Snails do you wish to enter (1-3)? ");
                    validInput = Int32.TryParse(Console.ReadLine(), out numberOfSnails);
                } while (!validInput);
            } while (!(numberOfSnails > 0 && numberOfSnails <= 3));

            // snails enter the race.
            Snail[] Snails = new Snail[numberOfSnails + 1];
            
            for (int i = 0; i < numberOfSnails; i++)
            {
                Console.Clear();
                Console.WriteLine($"Snail number {i + 1}:");
                do
                {
                    Console.Write("What is your snail called? ");
                    snailName = Console.ReadLine();
                } while (snailName.Length < 1);

                do
                {
                    Console.Write("How fast does your snail move minimally in mm/s? (0,0 - 2,0) ");
                    validInput = Decimal.TryParse(Console.ReadLine(), out snailMinSpeed);
                } while (!validInput);

                do
                {
                    Console.Write("How fast does your snail move maximally in mm/s? (min - 2,5) ");
                    validInput = Decimal.TryParse(Console.ReadLine(), out snailMaxSpeed);
                } while (!validInput);

                Snails[i] = new Snail(snailName, snailMinSpeed, snailMaxSpeed);
            }

            Console.WriteLine("The computer also adds a snail.");
            Console.ReadKey();
            Snails[numberOfSnails] = new Snail();

            // meet the contestants
            decimal[] distanceTraveled = new decimal[Snails.Length];
            Console.Clear();
            Console.WriteLine("Meet the contestants!!!");
            for (int i = 0; i < Snails.Length; i++)
            {
                Snails[i].ShowSnailStats();
                distanceTraveled[i] = 0.0m;
            }
            for (int i = 0; i < Snails.Length; i++)
            {
                Console.WriteLine($"a|          |          |          |          |          |          |      {Snails[i].GetName()}");
            }
            Console.ReadKey();

            // race
            Console.Write("Ready! "); Thread.Sleep(500); Console.WriteLine("Go! ");

            do
            {
                Thread.Sleep(Convert.ToInt32(Math.Floor(1000 * dt)));
                Console.SetCursorPosition(0, Snails.Length * 2 + 1);
                for (int i = 0; i < Snails.Length; i++)
                {
                    //move
                    snailMove = Snails[i].Move() * dt;
                    distanceTraveled[i] += snailMove;
                    //Display results
                    Console.WriteLine(($"{Snails[i].GetName()} traveled {snailMove:N1} mm is now at " +
                        $"{distanceTraveled[i]:N0} mm!").PadRight(Console.BufferWidth));
                }

                for (int i = 0; i < Snails.Length; i++)
                {
                    Console.SetCursorPosition(0, Snails.Length + i + 1);
                    Console.Write(" |          |          |          |          |          |          |");
                    Console.SetCursorPosition(Convert.ToInt32(Math.Floor((distanceTraveled[i] / finish) * 66)), Snails.Length + i + 1);
                    Console.Write("a");
                }

                } while (distanceTraveled.Max() < finish);

            Console.SetCursorPosition(0, Snails.Length * 3 + 1);
            int winner = Array.IndexOf(distanceTraveled, distanceTraveled.Max());
            Console.WriteLine($"The Winner is {Snails[winner].GetName()}!!!");

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }

    public class Snail
    {
        string name;
        decimal minSpeed; // in mm/s
        decimal maxSpeed; // in mm/s

        // constructs a snail
        public Snail(string name, decimal minSpeed, decimal maxSpeed)
        {
            decimal maxMinSpeed = 2.0m;
            decimal maxMaxSpeed = 2.5m;

            this.name = name;

            if (minSpeed > 0.0m && minSpeed <= maxMinSpeed) { this.minSpeed = minSpeed; }
            else
            {
                Random r = new Random();
                this.minSpeed = (Convert.ToDecimal(r.Next(1,101)) * maxMinSpeed) / 100m;
            }

            if (maxSpeed > this.minSpeed && maxSpeed <= maxMaxSpeed) { this.maxSpeed = maxSpeed; }
            else
            {
                Random r = new Random();
                this.maxSpeed = ((Convert.ToDecimal(r.Next(1, 101)) * (maxMinSpeed-this.minSpeed)) / 100m) + this.minSpeed;
            }
        }

        //constructs a random snail.
        public Snail() : this("", 0.0m, 0.0m) 
        {
            string[] names = { "Dave", "John", "Jane", "Clair", "Billy", "Bob", "Sandra", "Alice" };
            Random r = new Random();
            this.name = names[r.Next(name.Length)];
        }
        public Snail(string name) : this(name, 0.0m, 0.0m) { }

        // return snail's properties
        public string GetName() { return this.name; }
        public decimal GetMinSpeed() { return this.minSpeed; }
        public decimal GetMaxSpeed() { return this.maxSpeed; }

        // shows the snail's stats
        public void ShowSnailStats()
        {
            Console.WriteLine($"Name: {this.name}, minimum speed: {this.minSpeed:N2} mm/s, maximum speed: {this.maxSpeed:N2} mm/s.");
        }

        // returns a speed per second during the last increment
        public decimal Move()
        {
            Random r = new Random();
            return (Convert.ToDecimal(r.Next(1, 1001)) * (this.maxSpeed - this.minSpeed) / 1000.0m) + this.minSpeed;
        }
    }
}
