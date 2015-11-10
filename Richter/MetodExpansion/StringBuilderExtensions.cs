using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodExpansion
{
    public static class StringBuilderExtensions
    {
        public static Int32 IndexOf(this StringBuilder sb, Char value)
        {
            for (Int32 i = 0; i < sb.Length; i++)
            
                if (sb[i] == value)
                    return i;
            return -1;
        }
    }
}
