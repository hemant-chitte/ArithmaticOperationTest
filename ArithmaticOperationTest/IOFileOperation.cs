using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmaticOperationTest
{
    public static class IOFileOperation
    {
        /// <summary>
        /// Read the conent from the file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>file content</returns>
        public static string ReadFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath) != false)
                {
                    string fileContent = File.ReadAllText(filePath);
                    return fileContent;
                }
                else
                {
                    Logger.Log($"File not found: { filePath }", LogType.Error);
                    Console.WriteLine($"file not found: { filePath }");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.Log("Read operation failed due to " + ex.Message, LogType.Error);
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        /// <summary>
        /// Write the content in the file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="content"></param>
        /// <returns>send success or failure</returns>
        public static bool WriteFile(string filePath, string content)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(filePath))
                {
                    writer.WriteLine(content);
                }

                string fileContent = ReadFile(filePath);

                if (!string.IsNullOrEmpty(fileContent))
                    return true;
            }
            catch (IOException ex)
            {
                Logger.Log("Write operation failed due to " + ex.Message, LogType.Error);
                Console.WriteLine(ex.Message);
            }

            return false;
        }
    }
}
