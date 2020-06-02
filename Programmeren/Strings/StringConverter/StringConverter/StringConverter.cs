using System;

namespace StringConverter
{
    class StringConverter
    {
        static void Main(string[] args)
        {
            string userInput;
            string str;
            do
            {
                Console.WriteLine("Please enter a sentence. or (q)uit?");
                userInput = Console.ReadLine();
                if (!userInput.Equals("q") && !userInput.Equals("Q") && userInput.Length > 0)
                {
                    Console.WriteLine("\nReversed:\n{0}\n", Reverse(userInput));

                    if (IsPalindrome(userInput)) { str = ""; } else { str = "not "; }
                    Console.WriteLine("\"{0}\" is {1}a palindrome.\n", userInput, str);

                    Console.WriteLine("In Pig Latin the sentence would be:\n{0}\n", PigLatinate(userInput));

                    Console.WriteLine("In shorthand the sentence would be:\n{0}\n", ShortHand(userInput));
                }
            } while (!userInput.Equals("q") && !userInput.Equals("Q"));
        }

        //Reverse
        public static string Reverse(string input)
        {
            string output = "";
            for (int i = 0; i < input.Length; i++)
            {
                output += input[input.Length - i - 1];
            }
            return output;
        }

        // Palindrome?
        public static bool IsPalindrome(string input)
        {
            string[] toDelete = { " ", ",", ".", "\'", "\"", "!", "?", "-", ";", ":" };
            foreach (string remove in toDelete)
            {
                input = input.Replace(remove, "");
            }
            input = input.ToLower();
            return input.Equals(Reverse(input));
        }

        public static string PigLatinate(string input)
        {
            string[] toKeep = { ",", ".", "\'", "\"", "!", "?", "-", ";", ":" };
            string[] vowels = { "a", "e", "i", "o", "u" };
            int indexOfFirstVowel = -1;
            int indexOfVowel;
            string keep = "";
            string str;
            string output = "";
            bool upperCase;
            char[] ch;

            // split the sentence in words
            string[] outputArr = input.Split(' ');

            for (int i = 0; i < outputArr.Length; i++)
            {
                str = outputArr[i];

                // check if first letter is uppercase and set to lowercase
                ch = str.ToCharArray();
                upperCase = Char.IsUpper(ch[0]);
                str = str.ToLower();


                // keep symbols at the end of the string
                foreach (string symbol in toKeep)
                {
                    if (str.Substring(str.Length - 1).Equals(symbol))
                    {
                        keep = symbol;
                        str = str.Replace(symbol,"");
                    }                 
                }
                // find first vowel if any
                foreach (string vowel in vowels)
                {
                    if (str.Contains(vowel))
                    {
                        indexOfVowel = str.IndexOf(vowel);
                        if (indexOfFirstVowel == -1 || (indexOfFirstVowel > indexOfVowel && indexOfVowel != -1))
                            { indexOfFirstVowel = indexOfVowel; }
                    }
                }

                //Pig Latinate the words
                if (indexOfFirstVowel == -1) { str += "ay"; }
                else if (indexOfFirstVowel == 0) { str += "yay"; }
                else { str = str.Substring(indexOfFirstVowel) + str.Substring(0, indexOfFirstVowel) + "ay"; }

                //return the symbol at the end of the word
                str += keep;
                // set first letter to upper, if the first letter was uppercase.
                if (upperCase) { str = str.Substring(0,1).ToUpper() + str.Substring(1); }

                // reset workvariables
                indexOfFirstVowel = -1;
                keep = "";

                // remake the sentence
                output += str + " ";
            }

            return output[0..^1];
        }

        public static string ShortHand(string input)
        {
            string[] outputArr = input.Split(' ');
            string[] symbols = { ",", ".", "\'", "\"", "!", "?", "-", ";", ":", };
            string[] toReplace = { "to", "you", "for", "be", "are" };
            string[] replaceWith = { "2", "U", "4", "B", "R" };
            string[] vowels = { "a", "e", "i", "o", "u", "A", "E", "I", "O", "U" };
            string output = "";

            string rep;
            string str;
            bool hasSymbolOn1 = false;

            for (int i = 0; i < outputArr.Length; i++)
            {
                str = outputArr[i];

                // replace with shorthand
                for (int j = 0; j < toReplace.Length; j++)
                {
                    rep = toReplace[j];
                    while (str.IndexOf(rep) != -1)
                    {
                        str = str.Substring(0, str.IndexOf(rep)) + replaceWith[j] +
                            str.Substring(str.IndexOf(rep) + rep.Length, str.Length - str.IndexOf(rep) - rep.Length);
                    }
                }

                // remove Vowels
                if (str.Length > 1)
                {
                    foreach (string symbol in symbols)
                    {
                        if (str.Substring(1,1).Equals(symbol))
                        {
                            hasSymbolOn1 = true;
                        }
                    }

                    if (!hasSymbolOn1)
                    {
                        foreach (string vowel in vowels)
                        {
                            str = str.Replace(vowel, string.Empty);
                        }
                    }
                    // reset work variable
                    hasSymbolOn1 = false;
                }

                // set output
                output += str + " ";

            }

            return output[0..^1];
        }
    }
}
