
namespace ArithmaticOperationTest
{
    public class ArithmaticOperation
    {
        private ArithmaticOperationStrategy inputStrategy;

        /// <summary>
        /// Set input strategy.
        /// </summary>
        /// <param name="arithmaticOperationStrategy"></param>
        public void SetArithmaticOperationStrategy(ArithmaticOperationStrategy arithmaticOperationStrategy)
        {
            inputStrategy = arithmaticOperationStrategy;
        }

        /// <summary>
        /// Execute the operation in the specified input strategy.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public int DoOperation(int[] numbers)
        {
            return inputStrategy.SumOfNumbers(numbers);
        }
    }
}
