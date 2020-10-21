using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MERG_PSI
{
    public static class StringExtension
    {
        public static double parseToDoubleLogIfCant(this string stringToParse)
        {
            double returnVal;
            var parsable = Double.TryParse(stringToParse, out returnVal);

            if (!parsable)
            {
                //fix log
            }

            return returnVal;
        }
        public static int parseToIntLogIfCant(this string stringToParse)
        {
            int returnVal;
            var parsable = Int32.TryParse(stringToParse, out returnVal);

            if (!parsable)
            {
                //fix log
            }

            return returnVal;
        }

    }
}
