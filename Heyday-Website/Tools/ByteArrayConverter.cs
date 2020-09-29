using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heyday_Website.Tools
{
    public class ByteArrayConverter
    {
        public static string ToString(byte[] b)
        {
            return System.Text.Encoding.Default.GetString(b);
        }

        public static byte[] ToByteArray(string s)
        {
            return System.Text.Encoding.Default.GetBytes(s);
        }
    }
}
