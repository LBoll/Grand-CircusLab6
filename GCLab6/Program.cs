using System;

namespace GCLab6
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Welcome to the Pig Latin Translator!");
                Console.Write("Please enter a line you would love to translate:\n"); //Prompts user for a word.

                string word = Console.ReadLine().ToLower().Trim(); //trims the extra spaces outside the users line.
                string userWord = null;
                if (!string.IsNullOrEmpty(word))  //if the user inputs nothing, it will ask to redo it.
                {
                    string[] split = word.Split(' ');
                    for (int i = 0; i < split.Length; i++)
                    {
                        string userWord2 = split[i];

                        char[] punctuation = "+_()*&^%$#@!-0987654321".ToCharArray();

                        bool Punctuation = userWord2.LastIndexOfAny(punctuation) >= 0;

                        int firstVowel = FirstVowel(userWord2);

                        if (!Punctuation)
                        {
                            if (firstVowel == 0 || firstVowel == -1)
                            {
                                userWord2 += "way ";
                                //keeps the vowels in the front, just adds way to the end.
                                userWord += userWord2;
                            }
                            else
                            {
                                userWord2 = userWord2.Substring(firstVowel) + userWord2.Substring(0, firstVowel) + "ay ";
                                //moves any consonants in the front to the back, then adds ay.
                                userWord += userWord2;
                            }
                        }
                        else
                            userWord += userWord2;
                    }
                    Console.WriteLine(userWord);
                }
                else
                {
                    Console.WriteLine("Please enter a valid line to translate!");
                }
                Console.WriteLine("Would you like to try to translate another word or phrase (y/n)?");

                // ask if they want to run again
            } while (Console.ReadLine()[0] == 'y');
            Console.WriteLine("Thank you for translating!" );
        }
        public static int FirstVowel(string words)
        {
            int vposition = -1;
            for (int i = 0; i < words.Length && vposition < 0; i++)
            {
                char vowel = words[i];

                if (vowel == 'a' || vowel == 'e' || vowel == 'i' || vowel == 'o' || vowel == 'u')
                {
                    vposition = i;
                } 
            }
            return vposition;
        }
    }
}