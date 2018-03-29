using System;
using NUnit.Framework;
using String.Calculator;

namespace StringCalculatorKata
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [Test]
        public void Add_WhenEmptyString_ShouldReturnZero()
        {
            //---------------Arrange-------------------
            var input = string.Empty;
            var expected = 0;
            var calculator = new StringCalculator();
            //---------------Act----------------------
            var result = calculator.Add(input);
            //---------------Assert-----------------------
            Assert.AreEqual(expected, result);
        }

        [TestCase("1", 1)]
        [TestCase("2", 2)]
        [TestCase("11", 11)]
        public void Add_WhenSingleNumberString_ShouldReturnIntegerOfNumber(string input, int expected)
        {
            //---------------Arrange-------------------
            var calculator = new StringCalculator();
            //---------------Act----------------------
            var result = calculator.Add(input);
            //---------------Assert-----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Add_WhenCommaDelimitedString_ShouldReturnSum()
        {
            //---------------Arrange-------------------
            var input = "5,5,9";
            var expected = 19;
            var calculator = new StringCalculator();
            //---------------Act----------------------
            var result = calculator.Add(input);
            //---------------Assert-----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Add_WhenNewlineDelimited_ShouldReturnSum()
        {
            //---------------Arrange-------------------
            var input = "3\n1\n5";
            var expected = 9;
            var calculator = new StringCalculator();
            //---------------Act----------------------
            var result = calculator.Add(input);
            //---------------Assert-----------------------
            Assert.AreEqual(expected, result);
        }

        [TestCase("//;\n8;7;6",21)]
        [TestCase("//^\n8^7\n5,2", 22)]
        public void Add_WhenCustomDelimiter_ShouldReturnSum(string input, int expected)
        {
            //---------------Arrange-------------------
            var calculator = new StringCalculator();
            //---------------Act----------------------
            var result = calculator.Add(input);
            //---------------Assert-----------------------
            Assert.AreEqual(expected, result);
        }

        [TestCase("10,5,-1", "negatives not allowed: -1")]
        [TestCase("10,5,-1,6,-3,-9", "negatives not allowed: -1,-3,-9")]
        public void Add_WhenNegativeNumbers_ShouldThrowExceptionListingNegatives(string input, string expected)
        {
            //---------------Arrange-------------------
            var calculator = new StringCalculator();
            //---------------Act----------------------
            var result = Assert.Throws<Exception>(() => calculator.Add(input));
            //---------------Assert-----------------------
            Assert.AreEqual(expected, result.Message);
        }

        [Test]
        public void Add_WhenNumbersLargerThan1000_ShouldReturnSumOfNumbersLessThan1000()
        {
            //---------------Arrange-------------------
            var input = "3,5,1001";
            var expected = 8;
            var calculator = new StringCalculator();
            //---------------Act----------------------
            var result = calculator.Add(input);
            //---------------Assert-----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Add_WhenNumbersLessThanOrEqualTo1000_ShouldReturnSum()
        {
            //---------------Arrange-------------------
            var input = "3,2,1000,9";
            var expected = 1014;
            var calculator = new StringCalculator();
            //---------------Act----------------------
            var result = calculator.Add(input);
            //---------------Assert-----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Add_WhenCustomMulitpleCharDelimiter_ShouldReturnSum()
        {
            //---------------Arrange-------------------
            var input = "//[**]\n5**4**9";
            var expected = 18;
            var calculator = new StringCalculator();
            //---------------Act----------------------
            var result = calculator.Add(input);
            //---------------Assert-----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Add_WhenManyCustomMulitpleCharDelimiters_ShouldReturnSum()
        {
            //---------------Arrange-------------------
            var input = "//[%*][&!][(##)]\n3%*6&!11(##)22";
            var expected = 42;
            var calculator = new StringCalculator();
            //---------------Act----------------------
            var result = calculator.Add(input);
            //---------------Assert-----------------------
            Assert.AreEqual(expected, result);
        }

    }
}
