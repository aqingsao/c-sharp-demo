using System;
using NUnit.Framework;

namespace First.Tests
{
    [TestFixture]
    public class StringParserTest
    {
        private StringParser stringParser;

        public StringParserTest()
        {
            stringParser = new StringParser();
        }

        [Test]
        public void should_return_0_when_given_null()
        {
            Assert.AreEqual(0, stringParser.ParseAndSum(null));
        }

        [Test]
        public void should_return_0_when_given_empty()
        {
            Assert.AreEqual(0, stringParser.ParseAndSum(""));
        }

        [Test]
        public void should_return_1_when_given_1()
        {
            Assert.AreEqual(1, stringParser.ParseAndSum("1"));
        }

        [Test]
        public void should_return_3_when_given_1_2()
        {
            Assert.AreEqual(3, stringParser.ParseAndSum("1,2"));
        }

        [Test, ExpectedException(typeof(FormatException), ExpectedMessage = "Invalid input")]
        public void should_throw_exception_when_given_a()
        {
            Assert.AreEqual(3, stringParser.ParseAndSum("a"));
        }
    }
}
