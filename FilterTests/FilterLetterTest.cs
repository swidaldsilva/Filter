using NUnit.Framework;
using Filter;
using System.IO;
using System.Collections.Generic;
using Filter.Filters;

namespace FilterTests
{
    [TestFixture]
    public class FilterLetterTest
    {
        private FilterCriteria filterCriteria;
        private string path;
        private List<string> words;

        [SetUp]
        public void Setup()
        {
            string Folderpath = (Directory.GetParent(Directory.GetCurrentDirectory()).Parent).Parent.FullName;
            path = Path.Combine(Folderpath, "Input.txt");
            words = Program.ReadInput(path);
            filterCriteria = new FilterCriteria('t', 3, false);
        }

        [Test]
        public void Test_Filter_Letter_Apply()
        {
            // Arrange & Act
            var fl = new FilterLetter(filterCriteria, words);
            var result = fl.Apply();

            // Assert
            Assert.AreEqual(13, result.Count);
        }

 
    }
}