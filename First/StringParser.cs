﻿using System;

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
                try
                {
                    total += Int32.Parse(strings[i]);
                }
                catch (Exception)
                {
                    throw new Exception("Please input a valid string");
                }
            }
            return total;
        }
    }
}