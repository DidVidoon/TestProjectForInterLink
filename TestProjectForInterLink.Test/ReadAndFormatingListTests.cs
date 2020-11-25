using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TestProjectForInterLink;

namespace TestProjectForInterLink.Test
{
    [TestClass]
    public class ReadAndFormatingListTests
    {
        [TestMethod]
        public void InputFileInArrayCharsOfLines_InputyPathToFile_OutputListArrayOfString()
        {
            string pathToFile = @"..\..\..\TestFile.csv";
            List<string[]> expected = new List<string[]>
            {
                new string[] { "Employee Name", "Date", "Work Hours"},
                new string[] { "Archie Klein", "Jun 29 2020", "2"},
                new string[] { "Tom", "Jun 30 2020", "3"},
                new string[] { "Archie Klein", "Jul 01 2020", "4"},
                new string[] { "Tom", "Jul 02 2020", "5"},
                new string[] { "Archie Klein", "Jul 03 2020", "6.5"},
            };


            List<string[]> actual = ReadAndReformatting.InputFileInArrayCharsOfLines(pathToFile);

            for (int i = 0; i < expected.Count; i++)
            {
                for (int j = 0; j < expected[i].Length; j++)
                {
                    Assert.AreEqual(expected[i][j], actual[i][j]);
                }
            }
        }
    }
}
