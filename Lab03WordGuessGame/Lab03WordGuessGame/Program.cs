using System;
using System.IO;

namespace Lab03WordGuessGame
{
    public class Program
    {
        public static string path = "../../../wordlist.txt";

        static void Main(string[] args)
        {
            //Carlos C. 01-11-2019
            //This moves up the word file to where the program.cs file is at so it's easy to find.
            //string path = "../../../wordFile.txt";
            CreateFile(path);
            WordGame();
        }

        /// <summary>
        /// This is the starting display of the screen.
        /// </summary>
        /// <return>void</return>
        public static void WordGame()
        {
            Console.WriteLine("Welcome to the wonderful Guessing Word Game!");
            Console.WriteLine("");
            Console.WriteLine("Place make your selection");
            Console.WriteLine("1) Start Game");
            Console.WriteLine("2) Admin");
            Console.WriteLine("3) Exit");
        
            string inputSelection = Console.ReadLine();
            switch (inputSelection)
            {
                case "1":
                    StartGame();
                    break;
                case "2":
                    Administration();
                    break;
                case "3":
                    Console.WriteLine("Bye bye");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("That is not a valid choice.  Please select 1, 2, or 3");
                    Console.ReadLine();
                    Console.Clear();
                    WordGame();
                    break;
            }
        }

        /// <summary>
        /// This is where the gussing word game plays.
        /// </summary>
        /// <return>void</return>
        public static void StartGame()
        {
            try
            {
                Console.Clear();
                Random rand = new Random();

                int guesses = 0;
                string[] wordList = WordsFromFile(path);
                int index = rand.Next(wordList.Length);
                string word = wordList[index];
                string incorrectLetters = "";
                string correctLetter = "";
                string hiddenWord = "_";
                for (int i = 0; i < word.Length; i++)
                {
                    Console.Write("_ ");
                }

                while (guesses >= 0)
                {
                    hiddenWord = "";
                    Start:
                    Console.WriteLine($"  You have made {guesses} wrong guesses.");
                    Console.WriteLine($"Letters you've guessed: {incorrectLetters}");
                    string userInput = Console.ReadLine();
                    if(userInput.Length > 1 || userInput.Length < 1)
                    {
                        //Console.Clear();
                        Console.Write("Please choose only ONE letter:  ");
                        goto Start;
                    }
                    else
                    {
                        char input = Convert.ToChar(userInput);
                        if (word.Contains(input))
                        {
                            for (int i = 0; i < word.Length; i++)
                            {
                                if (input == word[i])//sucess.  Letter found.
                                {
                                    correctLetter += input;
                                    hiddenWord += input.ToString();
                                    Console.Write(input + " ");
                                }
                                else if (correctLetter.Contains(word[i]))
                                {
                                    hiddenWord += word[i];
                                    Console.Write(word[i] + " ");
                                }
                                else
                                {
                                    hiddenWord += "_";
                                    Console.Write("_ ");
                                }
                            }
                        }
                        else
                        {
                            for (int j = 0; j < word.Length; j++)
                            {
                                if (correctLetter.Contains(word[j]))
                                {
                                    hiddenWord += word[j];
                                    Console.Write(word[j] + " ");
                                }
                                else
                                {
                                    Console.Write("_ ");
                                }
                            }
                            hiddenWord += "_";
                            incorrectLetters += input;
                            guesses++;
                        }
                        if (!hiddenWord.Contains("_"))
                        {
                            break;
                        }
                    }  
                }
                Console.WriteLine("\n");
                Console.WriteLine("Good job on solving the WORD!");
                Console.ReadLine();
                Console.Clear();
                WordGame();
            }
            catch (Exception error)
            {
                Console.WriteLine("Not a good place to have an exception.  This is where the game is.");
                Console.WriteLine(error.Message);
            }
        }

        /// <summary>
        /// This is where to view, add and delete the words.  Basically I have 2 Menu sceeens.
        /// </summary>
        public static void Administration()
        {
            Console.Clear();
            Console.WriteLine("Please choose an option: ");
            Console.WriteLine("1) View all words");
            Console.WriteLine("2) Add a word");
            Console.WriteLine("3) Delete a word");
            Console.WriteLine("4) Back to main menu");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    ViewAllWords();
                    break;
                case "2":
                    AddWord();
                    break;
                case "3":
                    DeleteWord();
                    break;
                case "4":
                    WordGame();
                    break;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("That is not a valid choice.  Please select 1, 2, 3, or 4");
                    Console.ReadLine();
                    Console.Clear();
                    Administration();
                    break;
            }
        }

        public static void ViewAllWords()
        {
            string[] words = WordsFromFile(path);
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
            Console.ReadLine();
            Administration();
        }

        public static void AddWord()
        {
            Console.WriteLine("Which word would you like to add?");
            string input = Console.ReadLine();
            AddNewWord(path, input);
            Console.WriteLine("Word successfully added.");
            Console.ReadLine();
            Administration();
        }

        public static void DeleteWord()
        {
            Console.WriteLine("Which word would you like to delete?");
            string input = Console.ReadLine();
            DeleteWord(path, input);
            Console.WriteLine("Word successfully deleted.");
            Console.ReadLine();
            Administration();
        }

        /// <summary>
        /// This is the starter list of words for the game.
        /// </summary>
        /// <param name="path">path to the file txt</param>
        /// <return>void</return>
        public static bool CreateFile(string path)
        {
            try
            {
                using (StreamWriter newFileWord = new StreamWriter(path))
                {
                    try
                    {
                        newFileWord.WriteLine("cat");
                        newFileWord.WriteLine("dog");
                        newFileWord.WriteLine("code");
                        newFileWord.WriteLine("pizza");
                        newFileWord.WriteLine("puzzle");
                        newFileWord.WriteLine("thunder");
                        newFileWord.WriteLine("computer");
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine($"Something happened with the starter word list. {error}");
                        throw;
                    }
                    finally
                    {
                        newFileWord.Close();
                    }
                }
            }
            catch (Exception error)
            {
                Console.WriteLine($"Something happened creating starter words. {error}");
                throw;
            }
            return true;
        }

        /// <summary>
        /// This reads all the file words
        /// </summary>
        /// <param name="path">file word txt</param>
        /// <returns>string in array</returns>
        public static string[] WordsFromFile(string path)
        {
            try
            {
                string[] words = File.ReadAllLines(path);
                return words;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public static bool AddNewWord(string path, string newWord)
        {
            try
            {
                using (StreamWriter sreamWord = File.AppendText(path))
                {
                    sreamWord.WriteLine(newWord);
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public static void DeleteWord(string path, string remove)
        {
            string[] currentWords = WordsFromFile(path);
            string[] newWords = new string[currentWords.Length - 1];
            int count = 0;
            for (int i = 0; i < currentWords.Length; i++)
            {
                if (remove != currentWords[i])
                {
                    newWords[count] = currentWords[i];
                    count++;
                }
            }
            try
            {
                File.WriteAllText(path, "");
                using (StreamWriter streamWords = File.AppendText(path))
                {
                    for (int i = 0; i < newWords.Length; i++)
                    {
                        streamWords.WriteLine(newWords[i]);
                    }
                }
            }
            catch (Exception error)
            {
                Console.WriteLine($"Oh no.  The Delete option broke.  {error}");
            }
        }
    }
}