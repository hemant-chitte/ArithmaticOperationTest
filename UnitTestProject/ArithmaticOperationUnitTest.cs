using ArithmaticOperationTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace UnitTestProject
{
    [TestClass]
    public class ArithmaticOperationUnitTest
    {
        [DataTestMethod]
        [DataRow(@"D:\Hemant\sample.txt", true)]
        [DataRow(@"D:\Hemant\sample1.txt", false)]
        public void CheckIfFileExist(string filePath, bool result)
        {
            bool fileExist = false;
            if (File.Exists(filePath)!=false)
                fileExist = true;
            
            Assert.AreEqual(result, fileExist);
        }

        [DataTestMethod]
        [DataRow(@"D:\Hemant\sample.txt", true)]
        [DataRow(@"D:\Hemant\sample1.txt", false)]
        public void CheckFileHasContent(string filePath, bool result)
        {
            string fileContent=IOFileOperation.ReadFile(filePath);

            if (result)
                Assert.IsNotNull(fileContent);
            else
                Assert.IsNull(fileContent);
        }

        [DataTestMethod]
        [DataRow("s,3,5,4,7,65,d,g,23,45,k")]
        public void CheckFileHasCommaSeparatedValues(string fileContent)
        {
            string[] stringArray = fileContent.GetStringArray();
            Assert.AreEqual(stringArray.Length, 11);
        }

        [DataTestMethod]
        [DataRow("s,,3,5,4,7,65,d,g,23,45,k")]
        public void CheckFileHasNumbers(string fileContent)
        {
            int[] numberArray = fileContent.GetStringArray().GetNumbers();
            Assert.AreEqual(numberArray.Length, 7);
        }

        [DataTestMethod]
        [DataRow("s,,3,5,4,7,6,d,g,23,45,p")]
        public void CheckSumOfAllNumbers(string fileContent)
        {
            ArithmaticOperation operation = new ArithmaticOperation();
            int[] numberArray = fileContent.GetStringArray().GetNumbers();
            operation.SetArithmaticOperationStrategy(new SumOfAllNumbers());
            int total = operation.DoOperation(numberArray);
            Assert.AreEqual(total,93);
        }

        [DataTestMethod]
        [DataRow("s,3,5,4,7,6,d,g,23,45,p")]
        public void CheckSumOddNumbers(string fileContent)
        {
            ArithmaticOperation operation = new ArithmaticOperation();
            int[] numberArray = fileContent.GetStringArray().GetNumbers();
            operation.SetArithmaticOperationStrategy(new SumOfOddNumbers());
            int total = operation.DoOperation(numberArray);
            Assert.AreEqual(total, 83);
        }

        [DataTestMethod]
        [DataRow("s,,3,5,4,7,6,d,g,23,45,p")]
        public void CheckSumEvenNumbers(string fileContent)
        {
            ArithmaticOperation operation = new ArithmaticOperation();
            int[] numberArray = fileContent.GetStringArray().GetNumbers();
            operation.SetArithmaticOperationStrategy(new SumOfEvenNumbers());
            int total = operation.DoOperation(numberArray);
            Assert.AreEqual(total, 10);
        }

        [DataTestMethod]
        [DataRow("s,3,5, 4, 7 ,6,d ,g,23,45, p")]
        public void CheckSpaceInNumbers(string fileContent)
        {
            ArithmaticOperation operation = new ArithmaticOperation();
            int[] numberArray = fileContent.GetStringArray().GetNumbers();
            operation.SetArithmaticOperationStrategy(new SumOfEvenNumbers());
            int total = operation.DoOperation(numberArray);
            Assert.AreEqual(total, 10);
        }

        [DataTestMethod]
        [DataRow("s,,3,5,0, 4, 7 ,6,d ,g,23,45, p")]
        public void CheckZeroInNumbers(string fileContent)
        {
            ArithmaticOperation operation = new ArithmaticOperation();
            int[] numberArray = fileContent.GetStringArray().GetNumbers();
            operation.SetArithmaticOperationStrategy(new SumOfEvenNumbers());
            int total = operation.DoOperation(numberArray);
            Assert.AreEqual(total, 10);
        }

        [DataTestMethod]
        [DataRow("s,d ,g,r,t,dfs, p")]
        public void CheckNoNumbers(string fileContent)
        {
            ArithmaticOperation operation = new ArithmaticOperation();
            int[] numberArray = fileContent.GetStringArray().GetNumbers();
            operation.SetArithmaticOperationStrategy(new SumOfEvenNumbers());
            int total = operation.DoOperation(numberArray);
            Assert.AreEqual(total, 0);
        }
    }
}
