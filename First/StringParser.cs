using System;

namespace First
{
    public class StringParser
    {
        public int ParseAndSum(string str)
        {
            if (String.IsNullOrEmpty(str))
            {
                return 0;
            }

            int total = 0;
            string[] strings = str.Split(',');
            for (int i = 0; i < strings.Length; i++)
            {
                total += Int32.Parse(strings[i]);
            }
            return total;
        }
    }
}