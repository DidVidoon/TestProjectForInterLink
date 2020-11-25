using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestProjectForInterLink.Test
{
    [TestClass]
    public class UnitTests
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


            List<string[]> actual = ReadFile.InputFileInArrayCharsOfLines(pathToFile);

            for (int i = 0; i < expected.Count; i++)
            {
                for (int j = 0; j < expected[i].Length; j++)
                {
                    Assert.AreEqual(expected[i][j], actual[i][j]);
                }
            }
        }

        [TestMethod]
        public void DataInfoToString_InputListStringFromFile_OutputDataList()
        {
            List<string[]> stringListFromFile = new List<string[]>
            {
                new string[] { "Employee Name", "Date", "Work Hours"},
                new string[] { "Archie Klein", "Jun 29 2020", "2"},
                new string[] { "Tom", "Jun 30 2020", "3"},
                new string[] { "Archie Klein", "Jul 01 2020", "4"},
                new string[] { "Tom", "Jul 02 2020", "5"},
                new string[] { "Archie Klein", "Jul 03 2020", "6.5"},
            };
            List<string> expected = new List<string> { "Name / Date", "Jun 29 2020", "Jun 30 2020", "Jul 01 2020", "Jul 02 2020", "Jul 03 2020", "\r\n" };

            List<string> actual = ReformattingAndRecorging.DataInfoToString(stringListFromFile);

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(InputDataForNameAndHoursToStringTest.GetNameAndHoursToString_InputyPathToFile_OutputNameAndHoursInString), typeof(InputDataForNameAndHoursToStringTest), DynamicDataSourceType.Method)]
        public void NameAndHoursToString_InputyListStringAndNameFromFile_OutputNameAndHoursInString(List<string> expected, string name)
        {
            string pathToFile = @"..\..\..\TestFile.csv";
            List<string[]> arrayCharsOfLines = ReadFile.InputFileInArrayCharsOfLines(pathToFile);
            List<string> dataList = ReformattingAndRecorging.DataInfoToString(arrayCharsOfLines);

            List<string> actual = ReformattingAndRecorging.NameAndHoursToString(arrayCharsOfLines, dataList, name);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void NameListFromFile_InputListStringFromFile_OutputNameList()
        {
            List<string[]> stringListFromFile = new List<string[]>
            {
                new string[] { "Employee Name", "Date", "Work Hours"},
                new string[] { "Archie Klein", "Jun 29 2020", "2"},
                new string[] { "Tom", "Jun 30 2020", "3"},
                new string[] { "Archie Klein", "Jul 01 2020", "4"},
                new string[] { "Tom", "Jul 02 2020", "5"},
                new string[] { "Archie Klein", "Jul 03 2020", "6.5"},
            };
            List<string> expected = new List<string> { "Archie Klein", "Tom" };

            List<string> actual = ReformattingAndRecorging.NameListFromFile(stringListFromFile);

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }
    }
}
