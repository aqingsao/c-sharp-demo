using NUnit.Framework;

namespace Second.Tests
{
    
    
    [TestFixture()]
    public class PinyinDAOTest
    {
        private PinyinDAO _pinyinDao = new PinyinDAO();

        [Test()]
        public void should_return_zhang_when_given_章()
        {
            Assert.That(_pinyinDao.GetPinyin("章"), Is.EqualTo("zhang"));
        }
        
        [Test()]
        public void should_return_Questionmark_when_given_笊()
        {
            Assert.That(_pinyinDao.GetPinyin("笊"), Is.EqualTo("?"));
        }

        [Test]
        public void should_update_pinyin_of_朝_to_chao()
        {
            _pinyinDao.UpdatePinyin("朝", "chao");
            Assert.That(_pinyinDao.GetPinyin("朝"), Is.EqualTo("chao"));
        }
    }
}
