using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TinTucCTSV.Data.Utility
{
    public static class Utility
    {
        public static string RemoveHtmlTagsUsingRegex(this string htmlString)
        {
            var result = Regex.Replace(htmlString, "&lt;.*?&gt;", string.Empty);
            return result;
        }
    }
}
