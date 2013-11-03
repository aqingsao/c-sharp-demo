using System;
using Moq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Second.Tests
{
    [TestFixture]
    public class PinyinServiceTest
    {
        private PinyinService _pinyin;
        private Mock<IPinyinRepository> _mock;

        [SetUp]
        public void SetUp()
        {
            _mock = new Mock<IPinyinRepository>();
            _mock.Setup(pinyinRepository => pinyinRepository.GetPinyin("章")).Returns("zhang");
            _mock.Setup(pinyinRepository => pinyinRepository.GetPinyin("子")).Returns("zi");
            _mock.Setup(pinyinRepository => pinyinRepository.GetPinyin("怡")).Returns("yi");
            _mock.Setup(pinyinRepository => pinyinRepository.GetPinyin("武")).Returns("wu");
            _mock.Setup(pinyinRepository => pinyinRepository.GetPinyin("曌")).Returns((string)null);

            _pinyin = new PinyinService(_mock.Object);
        }

        [Test]
        public void should_return_ZhangZiYi_when_given_章子怡()
        {
            Assert.That(_pinyin.GetPinyin("章子怡"), Is.EqualTo("ZhangZiYi"));
        }

        [Test]
        public void should_return_ZZY_when_given_章子怡()
        {
            Assert.That(_pinyin.GetPinyinHeader("章子怡"), Is.EqualTo("ZZY"));
        }

        [Test()]
        public void should_return_WQuestionMark_when_given_武笊()
        {
            Assert.That(_pinyin.GetPinyinHeader("武曌"), Is.EqualTo("W?"));
        }

        [Test()]
        public void should_return_WuQuestionMark_when_given_武笊()
        {
            Assert.That(_pinyin.GetPinyin("武曌"), Is.EqualTo("Wu?"));
        }

        [Test]
        public void should_update_pinyin_of_朝_to_chao()
        {
            _pinyin.UpdatePinyin("朝", "chao");

            _mock.Verify(pinyinProperty=>pinyinProperty.UpdatePinyin("朝", "chao"), Times.Once());
        }
    }
}
