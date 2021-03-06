﻿using System;
using System.Collections.Generic;
using System.IO;
using Codecool.FilePartReader;
using NUnit.Framework;

namespace Codecool.FilePartReader.UnitTests
{
    [TestFixture]
    public class FilePartReaderTest
    {
        private FilePartReader _filePartReader;

        [SetUp]
        public void Setup()
        {
            _filePartReader = new FilePartReader();
        }

        [Test]
        public void Constructor_Default_FilePathHasDefaultValue()
        {
            var defaultPath = string.Empty;
            Assert.AreEqual(defaultPath, _filePartReader.FilePath);
        }

        [Test]
        public void Constructor_FileNotFound_ThrowsErrorMessage()
        {
            var filePath = "random.txt";
            var fromLine = 1;
            var toLine = 3;
            var expectedMessage = "File not found.";

            
            var ex = Assert.Throws<FileNotFoundException>(() => _filePartReader.Setup(filePath, fromLine, toLine));

            Assert.AreEqual(expectedMessage, ex.Message);

        }

        [Test]
        public void Setup_FromLineBiggerThanToLine_ThrowsErrorMessage()
        {
            var filePath = "test.txt";
            var fromLine = 5;
            var toLine = 3;
            var expectedMessage = "The given starting line is invalid.";

            var ex = Assert.Throws<ArgumentException>(() => _filePartReader.Setup(filePath, fromLine, toLine));

            Assert.AreEqual(expectedMessage, ex.Message);
        }

        [Test]
        public void Setup_FromLineIsSmallerThanOne_ThrowsErrorMessage()
        {
            var filePath = "test.txt";
            var fromLine = -1;
            var toLine = 3;
            var expectedMessage = "The given starting line is invalid.";

            var ex = Assert.Throws<ArgumentException>(() => _filePartReader.Setup(filePath, fromLine, toLine));

            Assert.AreEqual(expectedMessage, ex.Message);
        }

        [Test]
        public void Read_GivenLessLinesThanTheFileHas_ReturnsAllContentAsString()
        {
            string expectedContent = "asdasdasd\r\nkajak\r\nCodecool\r\nlol\r\ntest\r\nkerek";

            _filePartReader.Setup("test.txt", 1, 3);
            string fileContent = _filePartReader.Read();

            Assert.AreEqual(expectedContent, fileContent);

        }

        [Test]
        public void ReadLines_GivenFromLineAndToLine_ReturnsTheLinesInBetween()
        {
            string expected = "kajak\r\nCodecool";

            _filePartReader.Setup("test.txt", 2, 3);
            string lines = _filePartReader.ReadLines();

            Assert.AreEqual(expected, lines);

        }
    }
}
