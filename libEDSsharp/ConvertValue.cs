using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace libEDSsharp
{
    public static class StringExtensions
    {
        public static bool IsNumeric(this string input)
        {
            int number;
            return int.TryParse(input, out number);
        }
    }
    public static class ConvertValue
    {
        public static int getbase(string defaultvalue)
        {

            if (defaultvalue == null || defaultvalue == "")
                return 10;

            int nobase = 10;

            String pat = @"^0[xX][0-9a-fA-F]+";

            Regex r = new Regex(pat, RegexOptions.IgnoreCase);
            Match m = r.Match(defaultvalue);
            if (m.Success)
            {
                nobase = 16;
            }

            pat = @"^0[0-9]+";
            r = new Regex(pat, RegexOptions.IgnoreCase);
            m = r.Match(defaultvalue);
            if (m.Success)
            {
                nobase = 8;
            }


            return nobase;
        }
        public static byte ConvertToByte(string defaultvalue)
        {
            if (defaultvalue == null || defaultvalue == "")
                return 0;

            return (Convert.ToByte(defaultvalue, getbase(defaultvalue)));
        }

        public static UInt16 ConvertToUInt16(byte[] bytes)
        {

            UInt16 value = 0;

            value = (UInt16)((bytes[0] << 8) | bytes[1]);

            return value;

        }

        public static UInt16 ConvertToUInt16(string defaultvalue)
        {
            if (defaultvalue == null || defaultvalue == "")
                return 0;

            return (Convert.ToUInt16(defaultvalue, getbase(defaultvalue)));
        }

        public static UInt32 ConvertToUInt32(string defaultvalue)
        {
            if (defaultvalue == null || defaultvalue == "")
                return 0;

            return (Convert.ToUInt32(defaultvalue, getbase(defaultvalue)));
        }
    }
}
