using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] boardPosition = 
                {  1, -1, -1,
                   1, 1, -1,
                   0, 0, 0 };
            bool playerTurn = false;
            int userInput = 8;
            bool winFlag;

            boardPosition = playMove(playerTurn, userInput, boardPosition);
            winFlag = ThreeInARow(boardPosition);

            for (int i = 0; i<=2; i++)
            {
                Console.Write(boardPosition[i]);
            }
            Console.WriteLine();
            for (int i = 3; i <= 5; i++)
            {
                Console.Write(boardPosition[i]);
            }
            Console.WriteLine();
            for (int i = 6; i <= 8; i++)
            {
                Console.Write(boardPosition[i]);
            }
            Console.WriteLine();

            Console.WriteLine($"winFlag = {winFlag}");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        /* playMove method plaatst een -1 of een 1 in de array die het bord representeed aan de computer.
         * een 1 als X aan de beurt is en een -1 als O aan de beurt is.
         */
        private static int[] playMove(bool playerTurn, int userInput, int[] boardPosition)
        {
            if (playerTurn)
                boardPosition[userInput] = 1;
            else
                boardPosition[userInput] = -1;
            return boardPosition;
        }
        
        /* ThreeInARow method kijkt of er drie op een rij is gemaakt door de rijen, kolommen en diagonalen bij elkaar op te tellen.
         * Als er -3 of 3 uit komt, betekent dit dat drie dezelfde symbolen op een rij staan en er iemand gewonnen heeft.
         */
        private static bool ThreeInARow(int[] boardPosition)
        {
            for (int i = 0; i <= 2; i++)
            {
                if (//horizontal
                    boardPosition[0 + (i * 3)] + boardPosition[1 + (i * 3)] + boardPosition[2 + (i * 3)] == -3 ||
                    boardPosition[0 + (i * 3)] + boardPosition[1 + (i * 3)] + boardPosition[2 + (i * 3)] == 3 ||
                    // vertical
                    boardPosition[0 + i] + boardPosition[3 + i] + boardPosition[6 + i] == -3 ||
                    boardPosition[0 + i] + boardPosition[3 + i] + boardPosition[6 + i] == 3)
                {
                    return true;
                }
            }
            //diagonal
            if (boardPosition[0] + boardPosition[4] + boardPosition[8] == -3 ||
                boardPosition[0] + boardPosition[4] + boardPosition[8] == 3 ||
                boardPosition[2] + boardPosition[4] + boardPosition[6] == -3 ||
                boardPosition[2] + boardPosition[4] + boardPosition[6] == -3)
            {
                return true; 
            }

            return false;
        }
    }
}
