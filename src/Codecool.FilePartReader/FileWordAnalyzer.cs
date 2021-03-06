﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Codecool.FilePartReader
{
    /// <summary>
    /// Uses a FilePartReader to open a file and analyze different aspects of it
    /// </summary>
    public class FileWordAnalyzer
    {
        private readonly FilePartReader _filePartReader;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileWordAnalyzer"/> class.
        /// </summary>
        /// <param name="filePartReader">File part reader instance.</param>
        public FileWordAnalyzer(FilePartReader filePartReader)
        {
            _filePartReader = filePartReader;
        }

        /// <summary>
        /// Gets the lines configured from FilePartReader and creates a list
        /// of lines out of them, and sorts into natural order
        /// </summary>
        /// <returns>The list of lines ordered in natural order</returns>
        public List<string> GetWordsOrderedAlphabetically()
        {
            List<string> lines = new List<string>();
            string line = _filePartReader.ReadLines();
            var words = line.Split("\r\n");

            foreach (var word in words)
            {
                lines.Add(word);
            }

            lines.Sort();
            return lines;
        }

        /// <summary>
        /// Returns the lines containing the given sub-string
        /// </summary>
        /// <param name="subString">SubString the sub-string we are looking for in the file</param>
        /// <returns>The lines containing the sub-string.OrderBy(x =&gt; x, StringComparer.OrdinalIgnoreCase);</returns>
        public List<string> GetWordsContainingSubstring(string subString)
        {
            string line = _filePartReader.ReadLines();
            List<string> lines = new List<string>();

            var words = line.Split("\r\n");

            foreach (var word in words)
            {
                if (word.Contains(subString))
                {
                    lines.Add(word);
                }
            }

            return lines;
        }

        /// <summary>
        /// Returns the lines (not only words) which are palindrome. Doesn't care
        /// of the capital - non-capital character differences
        /// </summary>
        /// <returns>All the lines which are palindrome as a list</returns>
        public List<string> GetStringsWhichPalindromes()
        {
            string line = _filePartReader.ReadLines();
            List<string> lines = new List<string>();

            var stringLines = line.Split("\r\n");

            foreach (var stringLine in stringLines)
            {
                if (stringLine.SequenceEqual(stringLine.Reverse()))
                {
                    lines.Add(stringLine);
                }
            }

            return lines;
        }
    }
}
