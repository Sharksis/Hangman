using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            bool play;
            Console.WriteLine("Hello");
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("Welcome to the Hangman game\nCategory:Countries");
            do
            {
                bool isWrongWord = true;
                GameState gameState = new GameState();
                CountryCapital countryCapital = new CountryCapital();
                play = gameState.StartExit();
                if (play)
                {
                    countryCapital = countryCapital.SetRandomCountry();
                    gameState.RestartGamestate(countryCapital);

                    do
                    {
                        if (GameState.GetLifePoints() <= 0)
                        {
                            Console.WriteLine("\nNo lifepoints left\nGame over");
                            break;
                        }

                        stopwatch.Start();
                        Console.WriteLine(gameState.guessedChar);
                        Console.Write("\nYou have ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("{0} life points left", GameState.GetLifePoints());
                        Console.ResetColor();
                        if (GameState.GetLifePoints() == 1)
                        {
                            Console.WriteLine("Little advice to help you: Capital City of this Country is {0}",
                                countryCapital.GetCapital());
                        }

                        GuessedLetters.TypeUsedLetters();

                        switch (GameState.ChooseLetterWord())
                        {
                            case 1:
                                Console.WriteLine("\nGuess the letter by pressing it on keyboard");
                                char guessedLetter = Console.ReadKey().KeyChar;
                                isWrongWord = gameState.GuessLetter(guessedLetter);
                                GuessedLetters.AddGuessedLetter(guessedLetter);
                                break;

                            case 2:
                                Console.WriteLine("\nGuess the word by typing it on keyboard");
                                isWrongWord = gameState.GuessWord(Console.ReadLine());
                                break;

                            case 3:
                                gameState.RestartGamestate(countryCapital.SetRandomCountry());
                                GuessedLetters.ClearGuessedLetters();
                                stopwatch.Restart();
                                break;

                            default:
                                Console.WriteLine("Wrong button pressed");
                                break;
                        }

                        if (!isWrongWord)
                        {
                            stopwatch.Stop();
                            Console.WriteLine("\nIt took you {0} ", stopwatch.Elapsed);
                        }
                    } while (isWrongWord);
                }
            } while (play);

            Console.ReadLine();
        }
    }
}