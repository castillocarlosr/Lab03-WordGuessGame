using System;
using Xunit;
using static Lab03WordGuessGame.Program;

namespace Lab03WordGuessGameTDD
{
    public class UnitTest1
    {
        [Fact]
        public void FileUpdate()
        {
            path = "../../../test.txt";
            Assert.True(AddNewWord(path, "test"));
        }

        [Fact]
        public void ViewAllWords()
        {
            path = "../../../test.txt";
            Assert.Equal("test", WordsFromFile(path));
        }

        [Fact]
        public void checkWord()
        {
            AddNewWord(path, "zoo");
            string[] test = CreateFile(path);
            string word = test[test.Length - 1];
            Assert.True(CreateFile, "zoo");
        }
    }
}
