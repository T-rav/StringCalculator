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
            var tokens = GetTokens(values);
            var integers = ConvertStringNumbersToIntegers(tokens);
            return integers.Sum();
        }

        private static IEnumerable<int> ConvertStringNumbersToIntegers(string[] tokens)
        {
            return tokens.Select(int.Parse);
        }

        private static string[] GetTokens(string values)
        {
            var tokens = values.Split(',');
            return tokens;
        }
    }
}