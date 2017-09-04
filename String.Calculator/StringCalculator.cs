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
            var delimiters = FetchDelimiters(values);
            var numbers = ConvertNumbers(values, delimiters);
            return SumNumbers(numbers);
        }

        private int SumNumbers(IEnumerable<int> numbers)
        {
            var filteredNumbers = FilterLargeNumbers(numbers);
            return filteredNumbers.Sum();
        }

        private string AdjustValuesString(string values)
        {
            var result = values;
            if (HasCustomDelimiter(values))
            {
                var indexOfNewline = values.IndexOf('\n');
                result = values.Substring(indexOfNewline+1);
            }
            return result;
        }

        private string[] FetchDelimiters(string values)
        {
            var delimiters = new[] {",", "\n"};
            if (HasCustomDelimiter(values))
            {
                delimiters = AddCustomDelimiter(values, delimiters);
            }
            return delimiters;
        }

        private bool HasCustomDelimiter(string values)
        {
            return values.StartsWith("//");
        }

        private IEnumerable<int> FilterLargeNumbers(IEnumerable<int> numbers)
        {
            return numbers.Where(x=>x <= 1000);
        }

        private IEnumerable<int> ConvertNumbers(string values, string[] delimiters)
        {
            var input = AdjustValuesString(values);
            var tokens = GetTokens(input, delimiters);
            var integers = ConvertStringNumbersToIntegers(tokens);
            ThrowExceptionIfNegatives(integers);
            return integers;
        }

        private void ThrowExceptionIfNegatives(IEnumerable<int> integers)
        {
            var negatives = integers.Where(x => x < 0);
            if (negatives.Any())
            {
                var negativesString = string.Join(",", negatives);
                throw new Exception($"negatives not allowed: {negativesString}");
            }
        }

        private string[] AddCustomDelimiter(string values, string[] delimiters)
        {
            var newSize = delimiters.Length + 1;
            Array.Resize(ref delimiters, newSize);

            var delimiterPortionOfString = values.Split(']')[0];

            if (delimiterPortionOfString.StartsWith("//["))
            {
                delimiterPortionOfString = delimiterPortionOfString.Substring(3);
                delimiters[newSize - 1] = delimiterPortionOfString;
            }
            else
            {
                delimiters[newSize - 1] = values[2].ToString();
            }

            return delimiters;
        }

        private IEnumerable<int> ConvertStringNumbersToIntegers(string[] tokens)
        {
            return tokens.Select(int.Parse);
        }

        private string[] GetTokens(string values, string[] delimiters)
        {
            var tokens = values.Split(delimiters, StringSplitOptions.None);
            return tokens;
        }
    }
}