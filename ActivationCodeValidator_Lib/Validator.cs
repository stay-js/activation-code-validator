using System.Text.RegularExpressions;

namespace ActivationCodeValidator_Lib
{
    public static class Validator
    {
        private const int GROUP_LENGTH = 4;
        private const int GROUP_COUNT = 3;
        private static int SeparatorCount => GROUP_COUNT - 1;

        private static int LengthWithoutSeparator => GROUP_COUNT * GROUP_LENGTH;
        private static int LengthWithSeparator => LengthWithoutSeparator + SeparatorCount;
        private static int[] PossibleLengths => [LengthWithSeparator, LengthWithoutSeparator];

        private static Regex BuildRegex(bool withSeparator)
        {
            string group = $"[a-z0-9]{{{GROUP_LENGTH}}}";

            return new Regex($"^{string.Join(withSeparator ? "-" : "",
               Enumerable.Repeat(group, GROUP_COUNT))}$");
        }

        public static bool CheckCodeValidity(string input, out List<string> errors)
        {
            input = input.Trim().ToLower();
            errors = [];

            if (string.IsNullOrWhiteSpace(input))
            {
                errors.Add("Input is empty");
            }

            if (!PossibleLengths.Contains(input.Length))
            {
                errors.Add("Input length is invalid");
            }

            if (input.Length == LengthWithSeparator
                && !BuildRegex(true).IsMatch(input))
            {
                errors.Add("Input is not in formatted correctly");
            }

            if (input.Length == LengthWithoutSeparator
                && !BuildRegex(false).IsMatch(input))
            {
                errors.Add("Input is not in formatted correctly");
            }

            if (!input.Contains('g'))
            {
                errors.Add("Input does not contain the letter \"G\"");
            }

            if (!input.Contains('c'))
            {
                errors.Add("Input does not contain the letter \"C\"");
            }

            if (input.Count(ch => ch == 'j') != 1)
            {
                errors.Add("Input does not contain the letter \"J\", or contains more than one");
            }

            if (!input.Any(ch => int.TryParse($"{ch}", out _)))
            {
                errors.Add("Input does not contain any numbers");
            }

            return errors.Count == 0;
        }

        public static bool CheckCodeValidity(string input) => CheckCodeValidity(input, out _);
    }
}
