using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Codecool.FilePartReader.UnitTests
{
    [TestFixture]
    public class FileWorldAnalyzerTests
    {
        FilePartReader _filePartReader;
        FileWordAnalyzer _fileWorldAnalyzer;
        [SetUp]
        public void SetUp()
        {
            _filePartReader = new FilePartReader();
            _filePartReader.Setup("test.txt", 1, 5);
            _fileWorldAnalyzer = new FileWordAnalyzer(_filePartReader);
        }

        [Test]
        public void GetStringsWhichPalindromes_ContainsPalindromes_ReturnPalindromesAsList()
        {
            var defaultPath = string.Empty;
            var expected = new List<string>()
            {
                "kajak",
                "lol",
                "kerek"
            };

            var palindromes = _fileWorldAnalyzer.GetStringsWhichPalindromes();

            CollectionAssert.AreEqual(expected, palindromes);
        }

        [Test]
        public void GetWordsOrderedAplhabetically_UseMethod_ReturnsListWithOrderedWords()
        {
            var orderedWordsList = _fileWorldAnalyzer.GetWordsOrderedAlphabetically();
            var expectedWordsList = new List<string>()
            {
                "asdasdasd",
                "Codecool",
                "kajak",
                "kerek",
                "lol",
                "test"
            };

            Assert.AreEqual(expectedWordsList, orderedWordsList);
        }

        [Test]
        public void GetWordsContainingSubstring_GivenSubstring_ReturnsListWithWordsContainingSubstring()
        {
            var analyzer = new FileWordAnalyzer(_filePartReader);

            var subString = "ol";
            var wordsWithSubstring = analyzer.GetWordsContainingSubstring(subString);
            var expectedOutPut = new List<string>()
            {
                "Codecool",
                "lol"
            };

            Assert.AreEqual(expectedOutPut, wordsWithSubstring);
        }
    }
}
