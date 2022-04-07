using System;

namespace ArithmaticOperationTest
{
    /// <summary>
    /// This call is intended to print the total in email and send
    /// Which will return a boolean confirmation if operation successful.
    /// </summary>a
    public class PrintOutputInMail : ArithmaticOperationOutputStrategy
    {
        public override bool PrintOutput(int total)
        {
            //TODO : mail operation
            Logger.Log("Mail send with total sum of number: " + total, LogType.Info);
            Console.WriteLine("Mail send with total sum of number {0} ", total);
            return true;
        }
    }
}
