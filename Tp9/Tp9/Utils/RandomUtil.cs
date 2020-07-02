using System;
using System.Collections.Generic;
using System.Text;

namespace Tp9.Utils
{
    public class RandomUtil
    {
        public static char GetLetter()
        {
            string chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&";
            Random rand = new Random();
            int num = rand.Next(0, chars.Length - 1);
            return chars[num];
        }

        public static String GetString()
        {
            StringBuilder sb = new StringBuilder();
            Random rand = new Random();

            for (int i = 0; i < rand.Next(3,20); i++)
            {
                sb.Append(GetLetter());
            }

            return sb.ToString();
        }
    }
}
