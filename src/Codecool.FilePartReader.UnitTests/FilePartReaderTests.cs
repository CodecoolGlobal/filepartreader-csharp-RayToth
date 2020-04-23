using System;
using System.Collections.Generic;
using System.IO;
using Codecool.FilePartReader;
using NUnit.Framework;

namespace Codecool.FilePartReader.UnitTests
{
    /// <summary>
    /// When testing a class you should test only that specific class(unit), not the others
    /// the class may depending on
    /// </summary>
    [TestFixture]
    public class FilePartReaderTest
    {
        private FilePartReader _filePartReader;

        [SetUp]
        public void Setup()
        {
            _filePartReader = new FilePartReader();
            _filePartReader.Setup("test.txt", 1, 5);
            //_filePartReader.Setup();
        }

        [Test]
        public void Constructor_Default_FilePathHasDefaultValue()
        {
            // Arrange
            var defaultPath = string.Empty;
            // Act
            _filePartReader.Setup("", 1, 5);
            // Assert
            Assert.AreEqual(defaultPath, _filePartReader.FilePath);
        }

        [Test]
        public void GetStringsWhichPalindromes_ContainsPalindromes_ReturnPalindromesAsList()
        {
            // Arrange
            var defaultPath = string.Empty;
            var analyzer = new FileWordAnalyzer(_filePartReader);
            var expected = new List<string>()
            {
                "kajak",
                "lol",
                "kerek"
            };

            // Act
            var palindromes = analyzer.GetStringsWhichPalindromes();

            // Assert
            CollectionAssert.AreEqual(expected, palindromes);
        }

        [Test]
        public void Setup_FromLineBiggerThanToLine_HasNoReturn()
        {
            Assert.Throws<ArgumentException>(() => _filePartReader.Setup("test.txt", 5, 3));
        }

        [Test]
        public void Setup_FromLineIsSmallerThanOne_HasNoReturn()
        {
            Assert.Throws<ArgumentException>(() => _filePartReader.Setup("test.txt", -1, 3));
        }

        [Test]
        public void GetWordsOrderedAplhabetically_UseMethod_ReturnsListWithOrderedWords()
        {
            var analyzer = new FileWordAnalyzer(_filePartReader);

            var orderedWordsList = analyzer.GetWordsOrderedAlphabetically();
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