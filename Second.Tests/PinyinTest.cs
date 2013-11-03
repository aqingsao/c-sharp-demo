using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Second.Tests
{
    [TestFixture]
    public class PinyinTest
    {
        private Pinyin _pinyin;
        private Mock<IPinyinDAO> _mock;

        [SetUp]
        public void SetUp()
        {
            _mock = new Mock<IPinyinDAO>();
            _mock.Setup(pinyinProperty => pinyinProperty.GetPinyin("章")).Returns("zhang");
            _mock.Setup(pinyinProperty => pinyinProperty.GetPinyin("子")).Returns("zi");
            _mock.Setup(pinyinProperty => pinyinProperty.GetPinyin("怡")).Returns("yi");
            _mock.Setup(pinyinProperty => pinyinProperty.GetPinyin("武")).Returns("wu");
            _mock.Setup(pinyinProperty => pinyinProperty.GetPinyin("笊")).Returns("?");

            _pinyin = new Pinyin(_mock.Object);
        }

        [Test]
        public void should_return_Zhang_when_given_章()
        {
            Assert.That(_pinyin.GetPinyin("章"), Is.EqualTo("Zhang"));
        }

        [Test]
        public void should_return_Zi_when_given_子()
        {
            Assert.That(_pinyin.GetPinyin("子"), Is.EqualTo("Zi"));
        }

        [Test]
        public void should_return_ZhangZiYi_when_given_章子怡()
        {
            Assert.That(_pinyin.GetPinyin("章子怡"), Is.EqualTo("ZhangZiYi"));
        }

        [Test()]
        public void should_return_WuQuestionMark_when_given_武笊()
        {
            Assert.That(_pinyin.GetPinyin("武笊"), Is.EqualTo("Wu?"));
        }

        [Test]
        [NUnit.Framework.ExpectedException(typeof(Exception))]
        public void should_update_pinyin_of_朝_to_chao()
        {
            _mock.Setup(pinyinProperty => pinyinProperty.UpdatePinyin("朝", "chao")).Throws(new Exception());
            _pinyin.UpdatePinyin("朝", "chao");

            _mock.Verify(pinyinProperty=>pinyinProperty.UpdatePinyin("朝", "chao"));
        }
    }
}
