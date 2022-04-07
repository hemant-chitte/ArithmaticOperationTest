using System;

namespace ArithmaticOperationTest
{
    /// <summary>
    /// This call is intended to print the total in the console.
    /// Which will return a boolean confirmation if operation successful.
    /// </summary>
    public class PrintOutputInConsole : ArithmaticOperationOutputStrategy
    {
        public override bool PrintOutput(int total)
        {
            Console.WriteLine("Total sum is:{0}", total);
            Logger.Log("Total sum is: " + total, LogType.Info);
            return true;
        }
    }
}
