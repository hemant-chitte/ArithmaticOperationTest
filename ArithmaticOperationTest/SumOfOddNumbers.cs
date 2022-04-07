
namespace ArithmaticOperationTest
{
    /// <summary>
    /// This class is responsible to do the sum of odd numbers.
    /// </summary>
    public class SumOfOddNumbers : ArithmaticOperationStrategy
    {
        public override int SumOfNumbers(int[] numbers)
        {
            int sumOfOdd = 0;

            foreach (var number in numbers)
            {
                if (number % 2 != 0)
                    sumOfOdd += number;
            }

            return sumOfOdd;
        }
    }
}
