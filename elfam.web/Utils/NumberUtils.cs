using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace elfam.web.Utils
{
    public class NumberUtils
    {
        public static string Convert(ulong i)
        {
            ulong p;
            ulong reminder;
            uint bas = 26;
            List<ulong> rems = new List<ulong>();
            while (true)
            {
                p = i / bas;
                reminder = i % bas;
                i = p;
                rems.Add(reminder);
                if (p == 0) break;
            }

            StringBuilder sb = new StringBuilder();
            foreach (ulong rem in rems)
            {
                sb.Append(ConvertTo36((byte) rem));
            }
            return sb.ToString();
        }

        private static string ConvertTo36(byte b)
        {
            switch (b)
            {
                case 0: return "q";
                case 1: return "a";
                case 2: return "z";
                case 3: return "x";
                case 4: return "s";
                case 5: return "w";
                case 6: return "e";
                case 7: return "d";
                case 8: return "c";
                case 9: return "v";
                case 10: return "f";
                case 11: return "r";
                case 12: return "g";
                case 13: return "b";
                case 14: return "n";
                case 15: return "h";
                case 16: return "y";
                case 17: return "u";
                case 18: return "j";
                case 19: return "m";
                case 20: return "k";
                case 21: return "i";
                case 22: return "o";
                case 23: return "l";
                case 24: return "p";
                case 25: return "t";



            }
            throw new ArgumentException();
        }
    }
}
