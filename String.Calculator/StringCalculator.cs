using System;
using System.Collections.Generic;
using System.Linq;

namespace String.Calculator
{
    public class StringCalculator
    {
        public int Add(string values)
        {
            if (string.IsNullOrEmpty(values))
            {
                return 0;
            }
            var delimiters = new[] {',', '\n'};
            if (values.StartsWith("//"))
            {
                delimiters = AddCustomDelimiter(values, delimiters);
                values = values.Substring(4);
            }
            var numbers = ConvertNumbers(values, delimiters);
            ThrowExceptionIfNegatives(numbers);
            return numbers.Sum();
        }

        private IEnumerable<int> ConvertNumbers(string values, char[] delimiters)
        {
            var tokens = GetTokens(values, delimiters);
            var integers = ConvertStringNumbersToIntegers(tokens);
            return integers;
        }

        private static void ThrowExceptionIfNegatives(IEnumerable<int> integers)
        {
            var negatives = integers.Where(x => x < 0);
            if (negatives.Any())
            {
                var negativesString = string.Join(",", negatives);
                throw new Exception($"negatives not allowed: {negativesString}");
            }
        }

        private char[] AddCustomDelimiter(string values, char[] delimiters)
        {
            var newSize = delimiters.Length + 1;
            Array.Resize(ref delimiters, newSize);
            delimiters[newSize - 1] = (char) values[2];
            return delimiters;
        }

        private IEnumerable<int> ConvertStringNumbersToIntegers(string[] tokens)
        {
            return tokens.Select(int.Parse);
        }

        private string[] GetTokens(string values, char[] delimiters)
        {
            var tokens = values.Split(delimiters);
            return tokens;
        }
    }
}