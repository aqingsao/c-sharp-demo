using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace Second
{
    public class Pinyin
    {
        private IPinyinDAO _pinyinDao;

        public Pinyin(IPinyinDAO pinyinDao)
        {
            _pinyinDao = pinyinDao;
        }

        public string GetPinyin(string chineseName)
        {
            List<char> chineseWords = chineseName.ToCharArray().ToList();
            List<string> pinyinWords = chineseWords
                .ConvertAll(new Converter<char, string>(chineseWord =>
                {
                    return ToTitleCase(_pinyinDao.GetPinyin(chineseWord.ToString()));
                }));

            return string.Join("", pinyinWords);
        }

        private string ToTitleCase(string input)
        {
            return Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(input);
        }

        public void UpdatePinyin(string chineseWord, string pinyin)
        {
            _pinyinDao.UpdatePinyin(chineseWord, pinyin);
        }
    }
}
