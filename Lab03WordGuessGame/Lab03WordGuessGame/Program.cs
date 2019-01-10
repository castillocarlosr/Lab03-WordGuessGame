using System;
using System.IO;

namespace Lab03WordGuessGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            //This bring up the word file to where the program.cs is.
            string path = "../../../wordFile.txt";
            CreateFile(path);
        }

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
