using System;
using System.IO;

namespace Lab03WordGuessGame
{
    public class Program
    {
        public static string path = "../../../wordFile.txt";

        static void Main(string[] args)
        {
            //Carlos C. 01-11-2019
            //This moves up the word file to where the program.cs file is at so it's easy to find.
            //string path = "../../../wordFile.txt";
            CreateFile(path);
            WordGame(path);
        }

        public static void WordGame(string pathInside)
        {
            Console.WriteLine("Welcome to the wonderful Guessing Word Game!");;
            Console.WriteLine("1) Start Game");
            Console.WriteLine("2) Word List");
            Console.WriteLine("3) Add Word");
            Console.WriteLine("4) Delete Word");
            Console.WriteLine("5) Exit");

            string inputSelection = Console.ReadLine();
            switch (inputSelection)
            {
                case 1:
                    StartGame();
                    break;
                case 2:
                    WordList();
                    break;
                case 3:
                    AddWord();
                    break;
                case 4:
                    DeleteWord();
                    break;

                default:
                    Console.WriteLine("That is not a valid choice.  Please select 1,2,3 or 4.");
                    WordGame();
                    break;
                    //return null;
            }
        }

        /// <summary>
        /// Example made today in class
        /// create reates a  file txt in folder
        /// </summary>
        /// <param name="pathInside">file path</param>
        /// <return>void</return>
        public static void CreateFile(string pathInside)
        {
            try
            {
                using(StreamWriter newFileWords = new StreamWriter(pathInside))
                {
                    //newFileWords.WriteLine("Carlos test is here again 3");
                    string[] starterWords = new string[] { "cat", "code", "computer", "mouse", "pizza", "dog" };
                    for (int i = 0; i < starterWords.Length; i++)
                    {
                        newFileWords.Write(i);
                    }
                }
            }
            catch(IOException eIO)
            {
                Console.WriteLine(eIO.Message);
            }
            catch (Exception eAll)
            {
                Console.WriteLine("General error");
                Console.WriteLine(eAll.Message);
                throw;
            }
        }

        public static void ReadFile(string pathInisde)
        {
            try
            {
                string[] linesInFile = File.ReadAllLines(pathInisde);
                for (int i = 0; i < linesInFile.Length; i++)
                {
                    Console.WriteLine(linesInFile[i]);
                }
                for (int j = 0; j < linesInFile.Length; j++)
                {
                    Console.WriteLine(linesInFile);
                }
            }
            catch (Exception errorRead)
            {
                Console.WriteLine(errorRead.Message);
                throw;
            }
        }

        public static string[] AddSingleWord(string pathInside, string theWord)
        {
            try
            {
                using (StreamWriter newWord = File.AppendText(path))
                {
                    newWord.WriteLine(theWord);
                    Console.WriteLine($"{theWord} :has been added.");
                }
            }
            catch (Exception)
            {

                throw;
            }

            //string[] allWordsInFile;
            //string answer = "testcarlos";

            //allWordsInFile = File.ReadAllLines(path);
            //return allWordsInFile;
        }

        public void AppendFile(string pathInside)
        {
            try
            {
                using (StreamWriter newFileWords = File.AppendText(pathInside))
                {
                    newFileWords.WriteLine("New line added to Carlos");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        /*
        public void DeleteFile(string pathInside)
        {
            try
            {
                File.Delete(pathInside);
            }
            catch (Exception)
            {

                throw;
            }
        }
        */

        public void SplitsFile()
        {
            //Something ....
        }
    }
}
