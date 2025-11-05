using ActivationCodeValidator_lib;

namespace ActivationCodeValidator_test
{
    public class ValidatorWithErrorsTests
    {
        [Test]
        public void ErrorListContainsInputIsEmptyErrorIfGivenEmptyString()
        {
            Validator.CheckCodeValidity("", out List<string> errors);
            Assert.That(errors.Contains("Input is empty"), Is.True);
        }
        
        [Test]
        public void ErrorListContainsInputLengthErrorIfTheGivenStringIsInvalid()
        {
            Validator.CheckCodeValidity("AAAA", out List<string> errors);
            Assert.That(errors.Contains("Input length is invalid"), Is.True);
        }

        [Test]
        public void ErrorListContainsFormatErrorWhenTheGivenStringIsInvalid()
        {
            Validator.CheckCodeValidity("AAAA--AAAAAAAA", out List<string> errors);
            Assert.That(errors.Contains("Input is not in formatted correctly"), Is.True);
        }
        
        [Test]
        public void ErrorListContainsLetterGErrorIfTheGivenStringDoesNotContainTheLetterG()
        {
            Validator.CheckCodeValidity("AAAA-AAAA-AAAA", out List<string> errors);
            Assert.That(errors.Contains("Input does not contain the letter \"G\""),
                Is.True);
        }
        
        [Test]
        public void ErrorListContainsLetterCErrorIfTheGivenStringDoesNotContainTheLetterC()
        {
            Validator.CheckCodeValidity("AAAA-AAAA-AAAA", out List<string> errors);
            Assert.That(errors.Contains("Input does not contain the letter \"C\""),
                Is.True);
        }
        
        [TestCase("AAAA-AAAA-AAAA")]
        [TestCase("AAAA-AAAA-AAJJ")]
        public void 
            ErrorListContainsLetterJErrorIfTheGivenStringDoesNotContainTheLetterJOrContainsMultiple
            (string input)
        {
            Validator.CheckCodeValidity(input, out List<string> errors);
            Assert.That(errors
                    .Contains("Input does not contain the letter \"J\", or contains more than one"),
                Is.True);
        }

        [Test]
        public void ErrorListContainsNumberErrorIfTheGivenStringDoesNotContainTheNumber()
        {
            Validator.CheckCodeValidity("AAAA-AAAA-AAAA", out List<string> errors);
            Assert.That(errors.Contains("Input does not contain any numbers"), Is.True);
        }
        
        [Test]
        public void ErrorListIsEmptyIfGivenAKnownGoodCode()
        {
            Validator.CheckCodeValidity("KGCW-5321-JUAH", out List<string> errors);
            Assert.That(errors.Count, Is.EqualTo(0));
        }
    }
}
