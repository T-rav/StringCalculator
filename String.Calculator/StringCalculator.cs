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
            return int.Parse(values);
        }
    }
}