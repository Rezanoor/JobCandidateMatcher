using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateMatcher.Services.Extentions
{
    public static class StringExtensions
    {
        public static bool ContainsIgnoreCase(this String string1, String string2)
        {
            return string1.ToLower().Trim().Contains(string2.ToLower().Trim());
        }
    }
}
