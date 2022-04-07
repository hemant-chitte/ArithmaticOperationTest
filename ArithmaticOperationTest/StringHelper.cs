using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmaticOperationTest
{
    public static class StringHelper
    {
        /// <summary>
        /// Get string array from the comma separated string.
        /// </summary>
        /// <param name="originalFileContent"></param>
        /// <returns>string array</returns>
        public static string[] GetStringArray(this string originalFileContent)
        {
            return originalFileContent.Split(',');
        }

        /// <summary>
        /// Get the numeric values out of the alpha numeric array.
        /// </summary>
        /// <param name="stringArray"></param>
        /// <returns>integer array</returns>
        public static int[] GetNumbers(this string[] stringArray)
        {
            List<int> integerList = new List<int>();
            foreach (string value in stringArray)
            {
                string stringValue = value.Trim();

                if (!string.IsNullOrEmpty(stringValue))
                {
                    int parsedInteger;

                    if (int.TryParse(stringValue, out parsedInteger))
                    {
                        integerList.Add(parsedInteger);
                    }
                    else
                    {
                        Logger.Log(stringValue + " is not a number.",LogType.Error);
                        Console.WriteLine(stringValue + " is not a number.");
                    }
                }
            }

            return integerList.ToArray();
        }
    }
}
