using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateMatcher.Services.Extentions
{
    public static class IntegerExtentions
    {
        public static bool GreaterThan(this int value1, int value2)
        {
            return value1 > value2;
        }

        public static bool LessThan(this int value1, int value2)
        {
            return value1 < value2;
        }
    }
}
