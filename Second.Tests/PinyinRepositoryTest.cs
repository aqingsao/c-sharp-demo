using System;
using NUnit.Framework;

namespace Second.Tests
{
    
    
    [TestFixture()]
    public class PinyinRepositoryTest
    {
        private PinyinRepository pinyinRepository = new PinyinRepository();

        [Test()]
        public void should_return_zhang_when_given_章()
        {
            Assert.That(pinyinRepository.GetPinyin("章"), Is.EqualTo("zhang"));
        }
        
        [Test()]
        public void should_return_null_when_given_笊()
        {
            Assert.That(pinyinRepository.GetPinyin("笊"), Is.Null);
        }

        [Test]
        public void should_update_pinyin_of_朝_to_chao()
        {
            pinyinRepository.UpdatePinyin("朝", "chao");
            Assert.That(pinyinRepository.GetPinyin("朝"), Is.EqualTo("chao"));
        }
    }
}
