using System;

namespace WebScraper
{
    public static class StringExtension
    {
        public static double ParseToDoubleLogIfCant(this string stringToParse)
        {
            var parsable = Double.TryParse(stringToParse, out var returnVal);

            if (!parsable)
            {
                MyLog.CantParse(stringToParse);
            }

            return returnVal;
        }
        public static int ParseToIntLogIfCant(this string stringToParse)
        {
            var parsable = Int32.TryParse(stringToParse, out var returnVal);

            if (!parsable)
            {
                MyLog.CantParse(stringToParse);
            }

            return returnVal;
        }
    }
}
