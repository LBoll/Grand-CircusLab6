using System;

namespace GCLab6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Prompt the user for a word
            Console.WriteLine("Welcome to the Pig Latin Translator!");
            do
            {
                Console.Write("Please enter a line you would love to translate:\n");

                string word = Console.ReadLine().ToLower().Trim(); //trims the extra spaces outside the users phrase.

                string userWord = null; //final translation declared to be filled with words

                if (!string.IsNullOrEmpty(word))  // test for empty input
                {
                    string[] wordsSplit = word.Split(' ');

                    Console.WriteLine("\nTranslating...\n");

                    for (int i = 0; i < wordsSplit.Length; i++)
                    {
                        string userWord2 = wordsSplit[i];

                        //find if it contains numbers or punctuation
                        char[] punctuation = "123456789!@#$%^&*()_+".ToCharArray();

                        bool containsPunctuation = userWord2.LastIndexOfAny(punctuation) >= 0;

                        int firstVowel = FirstVowel(userWord2);

                        if (!containsPunctuation)
                        {
                            if (firstVowel == 0 || firstVowel == -1)
                            {
                                userWord2 += "way ";
                                userWord += userWord2;

                            }
                            else
                            {
                                //swapping leading consonants onto the back
                                userWord2 = userWord2.Substring(firstVowel) + userWord2.ToLower().Substring(0, firstVowel) + "ay ";

                                userWord += userWord2;
                            }
                        }
                        else
                            userWord += userWord2;
                        //writes words with nums & symbols that don't need translating
                    }
                    Console.WriteLine(userWord);
                }
                else
                {
                    Console.WriteLine("You didn't enter a word to translate...");
                }
                Console.WriteLine("\nWould you like to try to translate another word or phrase (Y/N)?");

                // ask if they want to run again
            } while (Console.ReadLine().ToLower()[0] == 'y');

            Console.WriteLine("Thank you for translating!" );
        }
        public static int FirstVowel(string word)
        {
            int vposition = -1;
            for (int i = 0; i < word.Length && vposition < 0; i++)
            {
                char vowel = word[i];

                if (vowel == 'a' || vowel == 'e' || vowel == 'o' || vowel == 'u' || vowel == 'i')
                {
                    vposition = i;
                }
            }
            return vposition;
        }
    }
}