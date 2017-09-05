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

        private char[] FetchDelimiters(string values)
        {
            var delimiters = new[] {',', '\n'};
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

        private IEnumerable<int> ConvertNumbers(string values, char[] delimiters)
        {
            var input = AdjustValuesString(values);
            var tokens = GetNumberTokens(input, delimiters);
            var integers = ConvertStringNumbersToIntegers(tokens);
            ThrowExceptionIfNegatives(integers);
            return integers;
        }

        private string AdjustValuesString(string values)
        {
            var result = values;
            if (HasCustomDelimiter(values))
            {
                var indexOfNewline = values.IndexOf('\n');
                result = values.Substring(indexOfNewline + 1);
            }
            return result;
        }

        private string[] GetNumberTokens(string values, char[] delimiters)
        {
            var tokens = values.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            return tokens;
        }

        private IEnumerable<int> ConvertStringNumbersToIntegers(string[] tokens)
        {
            return tokens.Select(int.Parse);
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

        private char[] AddCustomDelimiter(string values, char[] delimiters)
        {
            var start = values.IndexOf("//");
            var end = values.IndexOf("\n");
            var tokens = values.Substring(start, (end - start)).ToCharArray();

            return AppendCustomDelimiters(delimiters, tokens);
        }

        private char[] AppendCustomDelimiters(char[] delimiters, char[] tokens)
        {
            var originalDelimitersLength = delimiters.Length;
            var newSize = originalDelimitersLength + tokens.Length;
            Array.Resize(ref delimiters, newSize);
            Array.Copy(tokens, 0, delimiters, originalDelimitersLength, tokens.Length);
            return delimiters;
        }
    }
}