
namespace ArithmaticOperationTest
{
    /// <summary>
    /// This class is responsible to do the sum of even numbers.
    /// </summary>
    public class SumOfEvenNumbers : ArithmaticOperationStrategy
    {
        public override int SumOfNumbers(int[] numbers)
        {
            int sumOfEven = 0;

            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                    sumOfEven += number;
            }

            return sumOfEven;
        }
    }
}
