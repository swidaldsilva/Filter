using NUnit.Framework;
using Filter;
using System.IO;
using System.Collections.Generic;
using Filter.Filters;

namespace FilterTests
{
    [TestFixture]
    public class FilterVowelInMiddleTest
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
            filterCriteria = new FilterCriteria('t', 3, true);
        }

        [Test]
        public void Test_Filter_Vowel_In_Middle_Apply()
        {
            // Arrange & Act
            var fl = new FilterVowelInMiddle(filterCriteria, words);
            var result = fl.Apply();

            // Assert
            Assert.AreEqual(8, result.Count);
        }

 
    }
}