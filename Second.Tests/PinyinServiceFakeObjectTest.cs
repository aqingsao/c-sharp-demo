using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Second.Tests
{
    [TestFixture]
    public class PinyinServiceFakeObjectTest
    {
        private PinyinService pinyinService;
        private IPinyinRepository pinyinRepository;

        [SetUp]
        public void SetUp()
        {
            pinyinRepository = new FakePinyinRepository(new Dictionary<string, string> {{"章", "zhang"}, {"子", "zi"}, {"怡", "yi"}, {"武", "wu"}});

            pinyinService = new PinyinService(pinyinRepository);
        }

        [Test]
        public void should_return_ZhangZiYi_when_given_章子怡()
        {
            Assert.That(pinyinService.GetPinyin("章子怡"), Is.EqualTo("ZhangZiYi"));
        }

        [Test]
        public void should_return_ZZY_when_given_章子怡()
        {
            Assert.That(pinyinService.GetPinyinHeader("章子怡"), Is.EqualTo("ZZY"));
        }

        [Test()]
        public void should_return_WuQuestionMark_when_given_武曌()
        {
            Assert.That(pinyinService.GetPinyin("武曌"), Is.EqualTo("Wu?"));
        }

        [Test()]
        public void should_return_WQuestionMark_when_given_武曌()
        {
            Assert.That(pinyinService.GetPinyinHeader("武曌"), Is.EqualTo("W?"));
        }

        public class FakePinyinRepository : IPinyinRepository
        {
            private Dictionary<string, string> _dictionary = new Dictionary<string, string>();

            public FakePinyinRepository(Dictionary<string, string> dictionary)
            {
                this._dictionary = dictionary;
            }

            public string GetPinyin(string chineseWord)
            {
                try
                {
                    return _dictionary[chineseWord];

                }
                catch (Exception)
                {

                    return null;
                }
            }

            public void UpdatePinyin(string chineseWord, string pinyin)
            {
                throw new NotImplementedException();
            }
        }
    }
}
