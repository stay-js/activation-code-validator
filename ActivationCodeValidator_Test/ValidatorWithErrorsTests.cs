using ActivationCodeValidator_Lib;

namespace ActivationCodeValidator_Test
{
    public class ValidatorWithErrorsTests
    {
        [TestCase("")]
        [TestCase("  ")]
        [TestCase("  \t\n")]
        public void
            ErrorListContainsInputIsEmptyErrorIfGivenEmptyStringOrOnlyWhitespace(string input)
        {
            Validator.CheckCodeValidity(input, out var errors);
            Assert.That(errors, Does.Contain("Input is empty"));
        }

        [TestCase("CAJAVA7")]
        [TestCase("JACA-UU1G-1M0P1")]
        public void
            ErrorListContainsInputLengthErrorIfGivenStringsLengthIsTooShortOrTooLong(string input)
        {
            Validator.CheckCodeValidity(input, out var errors);
            Assert.That(errors, Does.Contain("Input length is invalid"));
        }

        [TestCase("---GGJJCCCC1")]
        [TestCase("JACA-UU1G1M0P1")]
        [TestCase("JACUU1G-M0P1")]
        [TestCase("AAAA-BBBB-C@CC")]
        public void
            ErrorListContainsFormatErrorIfTheGivenStringIsInvalidOrContainsInvalidCharacters
            (string input)
        {
            Validator.CheckCodeValidity(input, out var errors);
            Assert.That(errors,
                Does.Contain("Input is not formatted correctly or contains invalid characters"));
        }

        [Test]
        public void ErrorListContainsLetterGErrorIfTheGivenStringDoesNotContainTheLetterG()
        {
            Validator.CheckCodeValidity("AAAA-BBBB-CCCC", out var errors);
            Assert.That(errors, Does.Contain("Input does not contain the letter \"G\""));
        }

        [Test]
        public void ErrorListContainsLetterCErrorIfTheGivenStringDoesNotContainTheLetterC()
        {
            Validator.CheckCodeValidity("AAAA-BBBB-XXXX", out var errors);
            Assert.That(errors, Does.Contain("Input does not contain the letter \"C\""));
        }

        [TestCase("AAAA-BBBB-CCCC")]
        [TestCase("AAAA-BBBB-CCJJ")]
        public void
            ErrorListContainsLetterJErrorIfTheGivenStringDoesNotContainTheLetterJOrContainsMultiple
            (string input)
        {
            Validator.CheckCodeValidity(input, out var errors);
            Assert.That(errors,
                Does.Contain("Input does not contain the letter \"J\", or contains more than one"));
        }

        [Test]
        public void ErrorListContainsNumberErrorIfTheGivenStringDoesNotContainAtLeastOneNumber()
        {
            Validator.CheckCodeValidity("AAAA-BBBB-CCCC", out var errors);
            Assert.That(errors, Does.Contain("Input does not contain any numbers"));
        }

        [Test]
        public void ErrorListIsEmptyIfGivenAKnownGoodCode()
        {
            Validator.CheckCodeValidity("KGCW-5321-JUAH", out var errors);
            Assert.That(errors, Is.Empty);
        }
    }
}
