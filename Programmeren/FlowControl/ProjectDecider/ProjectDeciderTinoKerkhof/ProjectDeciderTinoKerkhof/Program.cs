using System;

namespace ProjectDeciderTinoKerkhof
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * This program simulates a magic 8-ball.
             * source for awnsers: https://www.taurusandscorpio.net/list-of-magic-8-ball-responses/
             */

            Random eightBall = new Random();
            string eightBallAwnser;


            Console.WriteLine("What is your question, my dear?");
            Console.ReadLine();

            int eightBallSays = eightBall.Next(10);
            switch (eightBallSays)
            {
                case 0:
                    eightBallAwnser = "It is certain";
                    break;
                case 1:
                    eightBallAwnser = "As I see it, yes";
                    break;
                case 2:
                    eightBallAwnser = "Outlook good";
                    break;
                case 3:
                    eightBallAwnser = "Signs point to yes";
                    break;
                case 4:
                    eightBallAwnser = "Better not tell you now";
                    break;
                case 5:
                    eightBallAwnser = "Consentrate and ask again";
                    break;
                case 6:
                    eightBallAwnser = "Don't count on it";
                    break;
                case 7:
                    eightBallAwnser = "Very doubtfull";
                    break;
                case 8:
                    eightBallAwnser = "My sources say no";
                    break;
                case 9:
                    eightBallAwnser = "Outlook is not so good";
                    break;
                default:
                    eightBallAwnser = "Your question was unclear, please ask again";
                    break;
            }

            /*
             * Visual Studios suggested this:
             
            int eightBallSays = eightBall.Next(10);
            string eightBallAwnser = eightBallSays switch
            {
                0 => "It is certain",
                1 => "As I see it, yes",
                2 => "Outlook good",
                3 => "Signs point to yes",
                4 => "Better not tell you now",
                5 => "Consentrate and ask again",
                6 => "Don't count on it",
                7 => "Very doubtfull",
                8 => "My sources say no",
                9 => "Outlook is not so good",
                _ => "Your question was unclear, please ask again",
            };
            
             * It is a lot more concise and thus easier to read. Can I/we use this in the future?
             */

            Console.WriteLine(eightBallAwnser);
            Console.WriteLine("\nPress any key to exit");
            Console.ReadKey();
        }
    }
}
