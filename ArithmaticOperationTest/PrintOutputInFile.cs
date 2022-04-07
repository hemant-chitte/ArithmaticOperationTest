using System;

namespace ArithmaticOperationTest
{
    /// <summary>
    /// This call is intended to print the total in the file.
    /// Which will return a boolean confirmation if operation successful.
    /// </summary>
    public class PrintOutputInFile : ArithmaticOperationOutputStrategy
    {
        public override bool PrintOutput(int total)
        {
            Console.WriteLine("please enter output file name: ");
           string filePath= Console.ReadLine();
            Logger.Log("Total sum is:" + total.ToString(), LogType.Info);
            return IOFileOperation.WriteFile(filePath, "Total sum is:" + total.ToString());
        }
    }
}
