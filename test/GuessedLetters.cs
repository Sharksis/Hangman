using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace test
{
    public static class GuessedLetters
    {
        private static List<char> _guessedLetters = new List<char>();

        public static List<char> GetGuessedLetters()
        {
            return _guessedLetters;
        }

        public static void TypeUsedLetters()
        {
            Console.Write("\nYou already used those letters:");
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (char t in _guessedLetters)
            {
                Console.Write(" {0}", t);
            }

            Console.ResetColor();
        }

        public static void AddGuessedLetter(char l)
        {
            _guessedLetters.Add(l);
        }

        public static void ClearGuessedLetters()
        {
            _guessedLetters.Clear();
        }

        public static int GetGuessedLettersCount()
        {
            return _guessedLetters.Count;
        }

        public static bool CheckGuessedLetters(char guessedLetter)
        {
            bool usedLetter = true;
            foreach (char ch in GetGuessedLetters())
            {
                if (guessedLetter == ch)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nOops, you already used that letter");
                    Console.ResetColor();
                    usedLetter = false;
                }
            }

            return usedLetter;
        }
    }
}