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
            //CreateFile(path);
            ReadFile(path);
            Console.WriteLine(path);
            Console.ReadLine();
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
                    newFileWords.WriteLine("Carlos test is here again 3");
                }
            }
            catch(IOException eIO)
            {
                Console.WriteLine(eIO.Message);
            }
            catch (Exception eAll)
            {
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
            catch (Exception)
            {

                throw;
            }
        }

        public static string[] GetSingleWord()
        {
            string[] allWordsInFile;
            string answer = "testcarlos";

            allWordsInFile = File.ReadAllLines(path);
            return allWordsInFile;
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
