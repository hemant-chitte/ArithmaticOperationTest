namespace ArithmaticOperationTest
{
    public class OutputOperation
    {
        private ArithmaticOperationOutputStrategy outputStrategy;

        /// <summary>
        /// set the output strategy.
        /// </summary>
        /// <param name="arithmaticOperationOutputStrategy"></param>
        public void SetOutputStrategy(ArithmaticOperationOutputStrategy arithmaticOperationOutputStrategy)
        {
            this.outputStrategy = arithmaticOperationOutputStrategy;
        }

        /// <summary>
        /// Execute the operation in the specified output strategy.
        /// </summary>
        /// <param name="total"></param>
        /// <returns></returns>
        public bool DoOperation(int total)
        {
            return outputStrategy.PrintOutput(total);
        }
    }
}
