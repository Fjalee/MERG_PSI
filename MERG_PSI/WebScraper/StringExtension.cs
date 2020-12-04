using System;
using System.Globalization;

namespace WebScraper
{
    public static class StringExtension
    {
        public static double ParseToDoubleLogIfCant(this string stringToParse, ILog logger)
        {
            var parsable = Double.TryParse(stringToParse, out var returnVal);

            if (!parsable)
            {
                logger.CantParse(stringToParse);
            }

            return returnVal;
        }
        public static double ParseToDoubleLogIfCant(this string stringToParse, NumberStyles ns, IFormatProvider ifp, ILog logger)
        {
            var parsable = Double.TryParse(stringToParse, ns, ifp, out var returnVal);

            if (!parsable)
            {
                logger.CantParse(stringToParse);
            }

            return returnVal;
        }
        public static int ParseToIntLogIfCant(this string stringToParse, ILog logger)
        {
            var parsable = Int32.TryParse(stringToParse, out var returnVal);

            if (!parsable)
            {
                logger.CantParse(stringToParse);
            }

            return returnVal;
        }
    }
}
