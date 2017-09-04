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
    }
}
