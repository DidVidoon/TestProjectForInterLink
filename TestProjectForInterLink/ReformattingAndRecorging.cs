using System;
using System.Collections.Generic;
using System.IO;

namespace TestProjectForInterLink
{
    public static class ReformattingAndRecorging
    {
        public static void ReformattingFile(List<string[]> arrayCharsOfLines, string pathToNewFile)
        {
            using (FileStream ReformatedFile = new FileStream($"{pathToNewFile}" + @"\ReformatedFile.csv", FileMode.Open))
            {
                List<string> dataList = DataInfoToString(arrayCharsOfLines);

                InputAndOutput.WriteLineInFile(dataList, ReformatedFile);

                List<string> nameList = NameListFromFile(arrayCharsOfLines);

                for (int i = 0; i < nameList.Count; i++)
                {
                    List<string> nameAndHoursList = NameAndHoursToString(arrayCharsOfLines, dataList, nameList[i]);

                    InputAndOutput.WriteLineInFile(nameAndHoursList, ReformatedFile);
                }
            }
        }

        public static List<String> NameAndHoursToString(List<string[]> arrayCharsOfLines, List<string> dataList, string name)
        {
            List<string> nameAndHoursList = new List<string> { name };

            for (int j = 0; j < arrayCharsOfLines.Count; j++)
            {
                if (arrayCharsOfLines[j][0] == name)
                {
                    for (int l = 0; l < dataList.Count; l++)
                    {
                        if (arrayCharsOfLines[j][1] == dataList[l])
                        {
                            if (nameAndHoursList.Count == l)
                            {
                                nameAndHoursList.Add(arrayCharsOfLines[j][2]);
                            }
                            else if (nameAndHoursList.Count < l)
                            {
                                int index = l - nameAndHoursList.Count;
                                while (index != 0)
                                {
                                    nameAndHoursList.Add("");
                                    index--;
                                }
                                nameAndHoursList.Add(arrayCharsOfLines[j][2]);
                            }
                            break;
                        }
                    }
                }
            }

            nameAndHoursList.Add("\r\n");

            return nameAndHoursList;
        }

        public static List<String> NameListFromFile(List<string[]> arrayCharsOfLines)
        {
            List<string> nameList = new List<string>();

            for (int i = 1; i < arrayCharsOfLines.Count; i++)
            {
                if (!nameList.Contains(arrayCharsOfLines[i][0]))
                {
                    string curentName = arrayCharsOfLines[i][0];
                    nameList.Add(curentName);
                }
            }

            return nameList;
        }

        public static List<string> DataInfoToString(List<string[]> arrayCharsOfLines)
        {
            List<string> dataList = new List<string>();

            for (int i = 0; i < arrayCharsOfLines.Count; i++)
            {
                if (!dataList.Contains(arrayCharsOfLines[i][1]) && i != 0)
                {
                    dataList.Add(arrayCharsOfLines[i][1]);
                }
                else if (i == 0)
                {
                    dataList.Add("Name / Date");
                }
            }

            dataList.Add("\r\n");

            return dataList;
        }
    }
}
