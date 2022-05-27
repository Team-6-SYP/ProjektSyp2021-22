using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Extensions
{
    public static partial class StringExtensions
    {
        public static string AddLastLine(this string source, string line)
        {
            if (source == null)
                return line;

            return source += $"\n{line}";
        }

        public static string AddFirstLine(this string source, string line)
        {
            if (source == null)
                return line;

            return source = $"{line}\n{source}";
        }


    }
}
