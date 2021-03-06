using System.Collections.Generic;

namespace Second
{
    public interface IPinyinRepository
    {
        string GetPinyin(string chineseWord);
        void UpdatePinyin(string chineseWord, string pinyin);
    }

    public class PinyinRepository : IPinyinRepository
    {
        private Dictionary<string, string> _dictionary = new Dictionary<string, string>();

        protected int Property
        {
            get; set;
        }
        public PinyinRepository()
        {
            _dictionary.Add("��", "zhang");
            _dictionary.Add("��", "zi");
            _dictionary.Add("��", "yi");
            _dictionary.Add("��", "wu");
        }
        public string GetPinyin(string chineseWord)
        {
            try
            {
                return _dictionary[chineseWord];

            }
            catch (System.Exception)
            {
                
                return null;
            }
        }

        public void UpdatePinyin(string chineseWord, string pinyin)
        {
            _dictionary.Add(chineseWord, pinyin);
        }
    }
}