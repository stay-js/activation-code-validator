using ActivationCodeValidator_lib;

namespace ActivationCodeValidator_test
{
    public class ValidatorTests
    {
        [Test]
        public void ValidatorReturnsFalseIfGivenEmptyString()
        {
            Assert.That(Validator.CheckCodeValidity(""), Is.EqualTo(false));
        }

        [TestCase("CAJAVA7")]
        [TestCase("JACA-UU1G-1M0P1")]
        public void ValidatorReturnsFalseIfGivenStringsLengthIsNotCorrect(string input)
        {
            Assert.That(Validator.CheckCodeValidity(input), Is.EqualTo(false));
        }

        [TestCase("--GGJJCCCC1")]
        [TestCase("JACA-UU1G-1M0P1")]
        [TestCase("JACA-UU1G1M0P1")]
        public void ValidatorReturnsFalseIfTheGivenStringIsNotInTheCorrectFormat(string input)
        {
            Assert.That(Validator.CheckCodeValidity(input), Is.EqualTo(false));
        }

        [Test]
        public void ValidatorReturnsFalseIfTheGivenStringDoesNotContainAtLeast_One_G_And_One_C_AndContainsExactlyOne_J()
        {
            Assert.That(Validator.CheckCodeValidity("AAAA-BBBB-CCCC"), Is.EqualTo(false));
        }

        [Test]
        public void ValidatorReturnsFalseIfGivesStringDoesNotContainAtLeastOneNumber()
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
        public void ValidatorReturnExpectedResultToExampleData(string input, bool expected)
        {
            Assert.That(Validator.CheckCodeValidity(input), Is.EqualTo(expected));
        }
    }
}
