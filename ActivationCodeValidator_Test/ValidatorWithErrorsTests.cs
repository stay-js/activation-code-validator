using ActivationCodeValidator_Lib;

namespace ActivationCodeValidator_Test
{
    public class ValidatorWithErrorsTests
    {
        [Test]
        public void ErrorListContainsInputIsEmptyErrorIfGivenEmptyString()
        {
            Validator.CheckCodeValidity("", out var errors);
            Assert.That(errors, Does.Contain("Input is empty"));
        }

        [Test]
        public void ErrorListContainsInputLengthErrorIfTheGivenStringIsInvalid()
        {
            Validator.CheckCodeValidity("AAAA", out var errors);
            Assert.That(errors, Does.Contain("Input length is invalid"));
        }

        [Test]
        public void ErrorListContainsFormatErrorWhenTheGivenStringIsInvalid()
        {
            Validator.CheckCodeValidity("AAAA--AAAAAAAA", out var errors);
            Assert.That(errors, Does.Contain("Input is not in formatted correctly"));
        }

        [Test]
        public void ErrorListContainsLetterGErrorIfTheGivenStringDoesNotContainTheLetterG()
        {
            Validator.CheckCodeValidity("AAAA-AAAA-AAAA", out var errors);
            Assert.That(errors, Does.Contain("Input does not contain the letter \"G\""));
        }

        [Test]
        public void ErrorListContainsLetterCErrorIfTheGivenStringDoesNotContainTheLetterC()
        {
            Validator.CheckCodeValidity("AAAA-AAAA-AAAA", out var errors);
            Assert.That(errors, Does.Contain("Input does not contain the letter \"C\""));
        }

        [TestCase("AAAA-AAAA-AAAA")]
        [TestCase("AAAA-AAAA-AAJJ")]
        public void
            ErrorListContainsLetterJErrorIfTheGivenStringDoesNotContainTheLetterJOrContainsMultiple
            (string input)
        {
            Validator.CheckCodeValidity(input, out var errors);
            Assert.That(errors,
                Does.Contain("Input does not contain the letter \"J\", or contains more than one"));
        }

        [Test]
        public void ErrorListContainsNumberErrorIfTheGivenStringDoesNotContainTheNumber()
        {
            Validator.CheckCodeValidity("AAAA-AAAA-AAAA", out var errors);
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
