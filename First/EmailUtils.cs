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
}