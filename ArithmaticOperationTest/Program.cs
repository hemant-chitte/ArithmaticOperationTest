using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmaticOperationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string toBeContinue = "n";
            const string yesOption = "y";
            string inputFilePath = "";
            int inputSwitch = 0;

            do
            {
                Logger.Log("Application started...",LogType.Info);

                #region File processing logic

                Console.WriteLine("Please enter file name to read:");
              
                inputFilePath = Console.ReadLine();

                Console.WriteLine("Please enter 1 for sum of all numbers");
                Console.WriteLine("Please enter 2 for sum of even numbers");
                Console.WriteLine("Please enter 3 for sum of odd numbers");
                Console.WriteLine("please enter one of the above option:");

                int.TryParse(Console.ReadLine(), out inputSwitch);

                string fileContent = IOFileOperation.ReadFile(inputFilePath);

                if (string.IsNullOrEmpty(fileContent))
                {
                    Console.WriteLine("File doen't have right content to read");
                    toBeContinue = yesOption;
                    continue;
                }

                Logger.Log("File operation completed", LogType.Info);
                #endregion

                #region Actual arithmatic operation

                int[] numberArray = fileContent.GetStringArray().GetNumbers();
                ArithmaticOperation operation = new ArithmaticOperation();

                if (!SetInputStrategy(operation, inputSwitch))
                {
                    toBeContinue = yesOption;
                    continue;
                }

                int total = operation.DoOperation(numberArray);

                Logger.Log("Arithmatic operation completed", LogType.Info);

                #endregion

                #region output operation

                int outputSwitch = 0;
                OutputOperation outputOperation = new OutputOperation();

                Console.WriteLine("Please enter 1 for print output in console");
                Console.WriteLine("Please enter 2 for print output in file");
                Console.WriteLine("Please enter 3 for print output in email");
                Console.WriteLine("please enter one of the above option for output the result:");

                int.TryParse(Console.ReadLine(), out outputSwitch);

                if (!SetOutputStrategy(outputOperation, outputSwitch))
                {
                    toBeContinue = yesOption;
                    continue;
                }

                if (outputOperation.DoOperation(total))
                {
                    Console.WriteLine("you have successfully completed the operation");
                }

                Logger.Log("Print output operation completed", LogType.Info);

                #endregion

                Console.WriteLine("Do you want to perform another operation again?");
                toBeContinue = Console.ReadLine();

            } while (string.Equals(toBeContinue, yesOption, StringComparison.OrdinalIgnoreCase));

            Logger.Log("Application ended...", LogType.Info);
        }

        /// <summary>
        /// Method responsible to set input strategy.
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="inputSwitch"></param>
        /// <returns></returns>
        private static bool SetInputStrategy(ArithmaticOperation operation, int inputSwitch)
        {
            bool isStrategySet = true;

            switch (inputSwitch)
            {
                case 1:
                    operation.SetArithmaticOperationStrategy(new SumOfAllNumbers());
                    break;
                case 2:
                    operation.SetArithmaticOperationStrategy(new SumOfEvenNumbers());
                    break;
                case 3:
                    operation.SetArithmaticOperationStrategy(new SumOfOddNumbers());
                    break;
                default:
                    Console.WriteLine("you have not entered valid option");
                    isStrategySet = false;
                    break;
            }

            return isStrategySet;
        }

        /// <summary>
        /// Method responsible to set output strategy.
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="inputSwitch"></param>
        /// <returns></returns>
        private static bool SetOutputStrategy(OutputOperation operation, int inputSwitch)
        {
            bool isStrategySet = true;

            switch (inputSwitch)
            {
                case 1:
                    operation.SetOutputStrategy(new PrintOutputInConsole());
                    break;
                case 2:
                    operation.SetOutputStrategy(new PrintOutputInFile());
                    break;
                case 3:
                    operation.SetOutputStrategy(new PrintOutputInMail());
                    break;
                default:
                    Console.WriteLine("you have not entered valid option");
                    isStrategySet = false;
                    break;
            }

            return isStrategySet;
        }
    }
}
