using System;
using System.Collections.Generic;
using System.IO;

namespace TestProjectForInterLink
{
    public static class ReadAndReformatting
    {
        public static List<string[]> InputFileInArrayCharsOfLines(string pathToFile)
        {
            using StreamReader inputFile = new StreamReader(pathToFile, System.Text.Encoding.Default);
            string arrayOfString;
            List<string[]> arrayCharsOfLines = new List<string[]>();

            while (!inputFile.EndOfStream)
            {
                arrayOfString = inputFile.ReadLine();
                string[] charsOfLine = arrayOfString.Split(',', StringSplitOptions.RemoveEmptyEntries);
                arrayCharsOfLines.Add(charsOfLine);
            }

            return arrayCharsOfLines;
        }
    }
}
