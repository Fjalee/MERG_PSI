using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MERG_PSI
{
    public static class StringExtension
    {
        public static double ParseToDoubleLogIfCant(this string stringToParse)
        {
            double returnVal;
            var parsable = Double.TryParse(stringToParse, out returnVal);

            if (!parsable)
            {
                //fix log
                //MessageBox.Show("error, temp, fix log, cant parse to double " + stringToParse, "Error",
                //MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return returnVal;
        }
        public static int ParseToIntLogIfCant(this string stringToParse)
        {
            int returnVal;
            var parsable = Int32.TryParse(stringToParse, out returnVal);

            if (!parsable)
            {
                //fix log
                //MessageBox.Show("error, temp, fix log, cant parse to int " + stringToParse, "Error",
                //MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return returnVal;
        }

    }
}
