using System.Linq;

namespace ArithmaticOperationTest
{
    /// <summary>
    /// This class is responsible to do the sum of all numbers.
    /// </summary>
    public class SumOfAllNumbers : ArithmaticOperationStrategy
    {
        public override int SumOfNumbers(int[] numbers)
        {
            return numbers.Sum();
        }
    }
}
