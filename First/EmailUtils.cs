using System;
using System.Text.RegularExpressions;

namespace First
{
    public class EmailUtils
    {
        private static readonly string _regExp = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";

        public static Boolean isValid(string email)
        {
            if (email == null)
            {
                return false;
            }

            return Regex.IsMatch(email, _regExp);
        }
    }

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