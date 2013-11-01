using System.Collections.Generic;

namespace Second
{
    public interface IPinyinDAO
    {
        string GetPinyin(string chineseWord);
        void UpdatePinyin(string chineseWord, string pinyin);
    }

    public class PinyinDAO : IPinyinDAO
    {
        private Dictionary<string, string> _dictionary = new Dictionary<string, string>();

        protected int Property
        {
            get; set;
        }
        public PinyinDAO()
        {
            _dictionary.Add("ÕÂ", "zhang");
            _dictionary.Add("×Ó", "zi");
            _dictionary.Add("âù", "yi");
            _dictionary.Add("Îä", "wu");
        }
        public string GetPinyin(string chineseWord)
        {
            try
            {
                return _dictionary[chineseWord];

            }
            catch (System.Exception)
            {
                
                return "?";
            }
        }

        public void UpdatePinyin(string chineseWord, string pinyin)
        {
            _dictionary.Add(chineseWord, pinyin);
        }
    }
}