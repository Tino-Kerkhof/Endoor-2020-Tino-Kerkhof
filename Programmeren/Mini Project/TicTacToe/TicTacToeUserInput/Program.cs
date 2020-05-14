using System;

namespace TicTacToeUserInput
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playerTurn = false;
            int[] boardPosition = { -1, 0, 1, 0, 1, 0, 0, 0, 0 };

            Console.WriteLine("Welkom to tic Tac Toe");
            int input = UserInput(boardPosition, playerTurn);

            Console.SetCursorPosition(0, 1);
            Console.WriteLine(input);
            Console.ReadKey();
        }

        static public int UserInput(int[] boardPosition, bool playerTurn)
        {
            int input;
            int posX = 3;
            int posY = 4;
            Console.SetCursorPosition(posX, posY);
            if (playerTurn) { Console.Write("Player 1, where do you want to place your X?"); }
            else { Console.Write("Player 2, where do you want to place your O?"); }

            Console.SetCursorPosition(posX, posY+1);
            Console.Write("Please give a number from 1-9 from the available spots. ");

            bool validInput;
            bool validMove = false;
            do
            {
                do
                {
                    validInput = Int32.TryParse(Console.ReadLine(), out input);

                    if (!validInput)
                    {
                        Console.SetCursorPosition(posX, posY + 2);
                        Console.Write("That is not a valid input. Please give a number from 1-9.");
                        Console.SetCursorPosition(posX + 56, posY + 1);
                        Console.Write("".PadRight(20));
                        Console.SetCursorPosition(posX + 56, posY + 1);
                    }
                } while (!validInput);

                // make input count from 0 (as used by C#)
                input--;
                if ((boardPosition[input] == 1 && playerTurn) || (boardPosition[input] == -1 && !playerTurn))
                {
                    Console.SetCursorPosition(posX, posY + 2);
                    Console.Write("That is not a valid move. You already played there.");
                    Console.SetCursorPosition(posX + 56, posY + 1);
                    Console.Write("".PadRight(20));
                    Console.SetCursorPosition(posX + 56, posY + 1);

                }
                else if ((boardPosition[input] == -1 && playerTurn) || (boardPosition[input] == 1 && !playerTurn))
                {
                    Console.SetCursorPosition(posX, posY + 2);
                    Console.Write("That is not a valid move. Your opponent already played there.");
                    Console.SetCursorPosition(posX + 56, posY + 1);
                    Console.Write("".PadRight(20));
                    Console.SetCursorPosition(posX + 56, posY + 1);
                }
                else { validMove = true; }
            } while (!validMove);

            // cleanup
            string cleanup = "".PadRight(80);
            for (int i = 0; i<=2; i++)
            {
                Console.SetCursorPosition(posX, posY + i);
                Console.Write(cleanup);
            }

            return input;
        }
    }
}
