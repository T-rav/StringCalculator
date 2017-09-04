﻿using NUnit.Framework;
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
        public void Add_WhenTwoNumbersWithCommaDelimiter_ShouldReturnSum()
        {
            //---------------Arrange-------------------
            var input = "2,5";
            var expected = 7;
            var calculator = new StringCalculator();
            //---------------Act----------------------
            var result = calculator.Add(input);
            //---------------Assert-----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Add_WhenManyNumbersWithCommaDelimiter_ShouldReturnSum()
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
    }
}
