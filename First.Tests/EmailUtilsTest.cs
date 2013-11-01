using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace First.Tests
{
    [TestFixture]
    public class EmailUtilsTest
    {
        [Test]
        public void should_return_true_when_given_a_at_b_dot_com()
        {
            Assert.IsTrue(EmailUtils.isValid("b@b.com"));
        }

        [Test]
        public void should_return_false_when_given_a_dot_com()
        {
            Assert.IsFalse(EmailUtils.isValid("a.com"));
        }

        [Test]
        public void should_return_false_when_given_at_b_dot_com()
        {
            Assert.IsFalse(EmailUtils.isValid("@b.com"));
        }

        [Test]
        public void should_return_false_when_given_a_at_at_b_dot_com()
        {
            Assert.IsFalse(EmailUtils.isValid("a@@b.com"));
        }

        [Test]
        public void should_return_false_when_given_null()
        {
            Assert.IsFalse(EmailUtils.isValid(null));
        }
    }
}
