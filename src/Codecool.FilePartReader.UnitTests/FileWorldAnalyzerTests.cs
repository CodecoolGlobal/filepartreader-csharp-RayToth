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
            var subString = "ol";
            var wordsWithSubstring = _fileWorldAnalyzer.GetWordsContainingSubstring(subString);
            var expectedOutPut = new List<string>()
            {
                "Codecool",
                "lol"
            };

            Assert.AreEqual(expectedOutPut, wordsWithSubstring);
        }

        [Test]
        public void GetWordsContainingSubstring_GivenSubstringWordIsNotFound_ReturnsEmptyList()
        {
            var subString = "honolulu";
            var wordsWithSubstring = _fileWorldAnalyzer.GetWordsContainingSubstring(subString);

            Assert.IsEmpty(wordsWithSubstring);
        }
    }
}
