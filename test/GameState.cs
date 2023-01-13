using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Text;


namespace test
{
    class GameState
    {
        private static int _lifePoints;
        private char[] password;
        public char[] guessedChar;

        public static int GetLifePoints()
        {
            return _lifePoints;
        }

        public static int SetLifePoints(int i)
        {
            _lifePoints = i;
            return _lifePoints;
        }

        public int WrongWordGuess()
        {
            return _lifePoints -= 2;
        }

        public int WrongLetterGuess()
        {
            return _lifePoints -= 1;
        }

        public static int ChooseLetterWord()
        {
            GuessMessage();
            int letterOrWord = 4;
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            char key = keyInfo.KeyChar;
            if (key == 'l')
            {
                letterOrWord = 1;
                Console.WriteLine("\nYou chose to guess by letters");
            }
            else if (key == 'w')
            {
                letterOrWord = 2;
                Console.WriteLine("\nYou chose to guess whole word");
            }
            else if (key == 'n')
            {
                letterOrWord = 3;
            }

            Console.Clear();
            return letterOrWord;
        }

        public void RestartGamestate(CountryCapital countryCapital)
        {
            Console.WriteLine("New game has been started\nEach letter is displayed as _");
            SetLifePoints(5);
            GuessedLetters.ClearGuessedLetters();

            password = countryCapital.GetRandomCountry();
            guessedChar = new char[password.Length];
            for (int i = 0; i < guessedChar.Length; i++)
            {
                guessedChar[i] = '_';
            }
        }

        public bool GuessLetter(char guessedLetter)
        {
            bool isWrongLetter = GuessedLetters.CheckGuessedLetters(guessedLetter);
            bool isWrongWord = true;
            if (isWrongLetter)
            {
                for (int i = 0; i < password.Length; i++)
                {
                    char lowercase = char.ToLower(guessedLetter);
                    if (lowercase == char.ToLower(password[i]))
                    {
                        guessedChar[i] = guessedLetter;
                        isWrongLetter = false;
                    }
                }

                if (isWrongLetter)
                {
                    WrongLetterGuess();
                }

                string compare = new string(guessedChar).ToLower();
                isWrongWord = CheckIfWin(compare);
                if (isWrongWord)
                {
                    Console.Clear();
                }
            }

            return isWrongWord;
        }

        public bool GuessWord(string guessedWord)
        {
            bool isWrongWord = CheckIfWin(guessedWord);
            if (isWrongWord)
            {
                WrongWordGuess();
                Console.Clear();
            }

            return isWrongWord;
        }

        public bool CheckIfWin(string compare)
        {
            bool isWrongWord = true;
            string compare2 = new string(password).ToLower();
            if (compare == compare2)
            {
                isWrongWord = false;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Congratulations\nyou guessed right");
                Console.ResetColor();
                Console.WriteLine();
                
            }

            return isWrongWord;
        }

        public bool StartExit()
        {
            Console.WriteLine("Press e to exit or any other button to start game");
            bool start = true;
            char s = Console.ReadKey().KeyChar;
            if (s == 'e' || s == 'E')
            {
                start = false;
            }

            Console.Clear();
            return start;
        }

        public static void GuessMessage()
        {
            Console.WriteLine("\nChoose to guess:");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("word");
            Console.ResetColor();
            Console.Write(" by pressing ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("w");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("letter");
            Console.ResetColor();
            Console.Write(" by pressing ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("l");
            Console.ResetColor();
            Console.Write("or to play ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("new game");
            Console.ResetColor();
            Console.Write(" br pressing ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("n");
            Console.ResetColor();
            Console.Write("for bad ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("letter");
            Console.ResetColor();
            Console.Write(" guess you lose ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1 life point");
            Console.ResetColor();
            Console.Write("for bad ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("word");
            Console.ResetColor();
            Console.Write(" guess you lose ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("2 life point");
            Console.ResetColor();
        }
    }
}