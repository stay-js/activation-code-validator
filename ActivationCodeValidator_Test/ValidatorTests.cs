using ActivationCodeValidator_Lib;

namespace ActivationCodeValidator_Test
{
    public class ValidatorTests
    {
        [TestCase("")]
        [TestCase("  ")]
        [TestCase("  \t\n")]
        public void ValidatorReturnsFalseIfGivenEmptyStringOrOnlyWhitespace(string input)
        {
            Assert.That(Validator.CheckCodeValidity(input), Is.EqualTo(false));
        }

        [TestCase("CAJAVA7")]
        [TestCase("JACA-UU1G-1M0P1")]
        public void ValidatorReturnsFalseIfGivenStringsLengthIsTooShortOrTooLong(string input)
        {
            Assert.That(Validator.CheckCodeValidity(input), Is.EqualTo(false));
        }

        [TestCase("---GGJJCCCC1")]
        [TestCase("JACA-UU1G1M0P1")]
        [TestCase("JACUU1G-M0P1")]
        [TestCase("AAAA-BBBB-C@CC")]
        public void
            ValidatorReturnsFalseIfTheGivenStringIsInvalidOrContainsInvalidCharacters
            (string input)
        {
            Assert.That(Validator.CheckCodeValidity(input), Is.EqualTo(false));
        }

        [TestCase("AAAA-BBBB-XXXX")]
        [TestCase("AAAA-BBBB-CCCC")]
        [TestCase("AAAA-BBBB-CCJJ")]
        public void
            ValidatorReturnsFalseIfTheGivenStringDoesNotContainAtLeast_One_G_And_One_C_AndContainsExactlyOne_J
            (string input)
        {
            Assert.That(Validator.CheckCodeValidity(input), Is.EqualTo(false));
        }

        [Test]
        public void ValidatorReturnsFalseIfTheGivenStringDoesNotContainAtLeastOneNumber()
        {
            Assert.That(Validator.CheckCodeValidity("AAAA-BBBB-CCCC"), Is.EqualTo(false));
        }

        [Test]
        public void ValidatorReturnTrueIfGivenAKnownGoodCode()
        {
            Assert.That(Validator.CheckCodeValidity("KGCW-5321-JUAH"), Is.EqualTo(true));
        }

        [TestCase("KGCW-5321-JUAH", true)]
        [TestCase("AAAA-BBBB-JCG1", true)]
        [TestCase("AAAA-BBBB-CCCC", false)]
        [TestCase("--GGJJCCCC1", false)]
        [TestCase("ggjj-cccc-1234", false)]
        [TestCase("CAJAVALA78G", false)]
        [TestCase("AA-AA-GC-GG-5J-T0", false)]
        [TestCase("CAJAVA78G", false)]
        [TestCase("JACA-UU1G-1M0P1", false)]
        [TestCase("JACA-UU1G1M0P1", false)]
        public void ValidatorReturnsExpectedResultToExampleData(string input, bool expected)
        {
            Assert.That(Validator.CheckCodeValidity(input), Is.EqualTo(expected));
        }
    }
}
