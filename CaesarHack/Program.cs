using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

class Program
{
    public static string? choosedOption;
    public static string? userWord;
    public static char[]? userWordLetters;
    public static int[]? wordNum;
    public static string[]? correctWords;
    public static char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
    static void Main()
    {

        IntroButtons();

    }
    static void IntroButtons()
    {
        Console.Clear();
        Console.WriteLine("Welcome to Caesar Hack program");
        Console.WriteLine("Choose to start:");
        Console.WriteLine();
        Console.WriteLine("(1) * Hack the encrypted word");
        Console.WriteLine("(2) * Encrypt the word");
        Console.WriteLine("(3) * Quit");
        Console.WriteLine();
        choosedOption = Console.ReadLine();
        
        if (choosedOption == "2")
        {
            Console.Clear();
            Console.WriteLine("<< THIS FUNCTION IS NOT CONMPLETED >>");
            Console.WriteLine();
            Console.WriteLine("<< PRESS ANY KEY TO CONTINUE >>");
            Console.ReadKey();

            IntroButtons();
        }
        else if (choosedOption == "3")
        {
            Environment.Exit(0);
        }
        else // 1, null or others
        {
            Option1();
        }
    }

    static void Option1()
    {
        Console.Clear();
        Console.WriteLine("<< CHOOSED OPTION 1 >>");
        Console.WriteLine();
        Console.WriteLine("Write your encrypted text (! ONLY LATIN CHARACTERS !): ");
        userWord = Console.ReadLine();
        Console.WriteLine();

        if(string.IsNullOrWhiteSpace(userWord))
        {
            Console.WriteLine("Decrypted word: ");
            Console.WriteLine();
            Console.WriteLine("<< PRESS ANY KEY TO CONTINUE >>");
            Console.ReadKey();

            IntroButtons();
        }
        else if (userWord.All(c => (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == ' '))
        {
            userWord = userWord.ToUpper();
            userWordLetters = userWord.ToCharArray();

            wordNum = new int[userWordLetters.Length];
            for (int i = 0; i < userWordLetters.Length; i++)
            {
                char temp = userWordLetters[i];

                if (temp == ' ')
                {
                    wordNum[i] = -1;
                    continue;
                }

                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (temp == alphabet[j])
                    {
                        wordNum[i] = j;
                        break;
                    }
                }
            }
            correctWords = new string[alphabet.Length];

            for (int j = 0; j < alphabet.Length; j++) 
            {
                correctWords[j] = ""; 
                for (int i = 0; i < wordNum.Length; i++) 
                {
                    int safeIndex;
                    if (wordNum[i] == -1)
                    {
                        safeIndex = -1;
                    }
                    else
                    {
                        safeIndex = (wordNum[i] - j + alphabet.Length) % alphabet.Length;
                    }

                    if (safeIndex == -1) 
                    {
                        correctWords[j] += ' ';
                    }
                    else
                    {
                        correctWords[j] += alphabet[safeIndex];
                    }

                }
            }
            Console.Clear();
            for (int m = 0; m < correctWords.Length; m++)
            {
                Console.WriteLine(m + ") " + correctWords[m]);
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("<<  THE TEXT " + userWord + " CONTAINS INVALID CHARACTERS. PLEASE FOLLOW THE PROGRAM RULES! >>");
            Console.WriteLine();
            Console.WriteLine("<< PRESS ANY KEY TO CONTINUE >>");
            Console.ReadKey();

            IntroButtons();
        }
    }
}