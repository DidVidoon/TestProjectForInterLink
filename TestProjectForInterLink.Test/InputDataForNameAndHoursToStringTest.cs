using System;
using System.Collections.Generic;
using System.Text;

namespace TestProjectForInterLink.Test
{
    class InputDataForNameAndHoursToStringTest
    {
        public static IEnumerable<object[]> GetNameAndHoursToString_InputyPathToFile_OutputNameAndHoursInString()
        {
            yield return new object[]
            {
                new List<string>
                {
                    "Archie Klein",
                    "2",
                    "",
                    "4",
                    "",
                    "6.5",
                    "\r\n"
                },


                "Archie Klein"
            };

            yield return new object[]
            {
                new List<string>
                {
                    "Tom",
                    "",
                    "3",
                    "",
                    "5",
                    "\r\n"
                },


                "Tom"
            };
        }
    }
}
