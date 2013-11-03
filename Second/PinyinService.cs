using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace Second
{
    public class PinyinService
    {
        private IPinyinRepository pinyinRepository;

        public PinyinService(): this(new PinyinRepository())
        {
        }
        public PinyinService(IPinyinRepository pinyinRepository)
        {
            this.pinyinRepository = pinyinRepository;
        }

        public string GetPinyin(string chineseName)
        {
            List<char> chineseWords = chineseName.ToCharArray().ToList();
            List<string> pinyinWords = chineseWords
                .ConvertAll(new Converter<char, string>(chineseWord => pinyinRepository.GetPinyin(chineseWord.ToString()) ?? "?"))
                .ConvertAll(new Converter<string, string>(ToTitleCase));

            return string.Join("", pinyinWords);
        }

        public string GetPinyinHeader(string chineseName)
        {
            List<char> chineseWords = chineseName.ToCharArray().ToList();
            List<string> pinyinWords = chineseWords
                .ConvertAll(new Converter<char, string>(chineseWord => pinyinRepository.GetPinyin(chineseWord.ToString()) ?? "?"))
                .ConvertAll(new Converter<string, string>(pinyin=>pinyin.First().ToString()))
                .ConvertAll(new Converter<string, string>(ToTitleCase));

            return string.Join("", pinyinWords);
        }

        public void UpdatePinyin(string chineseWord, string pinyin)
        {
            pinyinRepository.UpdatePinyin(chineseWord, pinyin);
        }

        private string ToTitleCase(string input)
        {
            return Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(input);
        }
    }
}
