using System;
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
        public void Setup_FromLineBiggerThanToLine_ThrowsArgumentException()
        {
            var fromLine = 5;
            var toLine = 3;
            Assert.Throws<ArgumentException>(() => _filePartReader.Setup("test.txt", fromLine, toLine));
        }

        [Test]
        public void Setup_FromLineIsSmallerThanOne_ThrowsArgumentException()
        {
            var fromLine = -1;
            var toLine = 3;
            Assert.Throws<ArgumentException>(() => _filePartReader.Setup("test.txt", fromLine, toLine));
        }
    }
}
