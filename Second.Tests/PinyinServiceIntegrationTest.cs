using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Second.Tests
{
    [TestFixture]
    public class PinyinServiceIntegrationTest
    {
        private PinyinService pinyinService = new PinyinService();

        [Test]
        public void should_return_ZhangZiYi_when_given_章子怡()
        {
            string actual = pinyinService.GetPinyin("章子怡");
            Assert.That(actual, Is.EqualTo("ZhangZiYi"));
        }

        [Test]
        public void should_return_ZZY_when_given_章子怡()
        {
            string actual = pinyinService.GetPinyinHeader("章子怡");
            Assert.That(actual, Is.EqualTo("ZZY"));
        }

        [Test]
        public void should_return_WuQuestionMark_when_given_武曌()
        {
            string actual = pinyinService.GetPinyin("武曌");
            Assert.That(actual, Is.EqualTo("Wu?"));
        }

        [Test]
        public void should_return_WQuestoinMark_when_given_武曌()
        {
            string actual = pinyinService.GetPinyinHeader("武曌");
            Assert.That(actual, Is.EqualTo("W?"));
        }
    }
}
