using System;
using System.IO;

namespace Lab03WordGuessGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Carlos C. 01-04-2019
            //This moves up the word file to where the program.cs file is at so it's easy to find.
            string path = "../../../wordFile.txt";
            CreateFile(path);
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
                    newFileWords.WriteLine("Carlos test is here again");
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

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
