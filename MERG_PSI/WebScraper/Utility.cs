using System.Collections.Generic;
using System.Linq;

namespace WebScraper
{
    public static class Utility
    {
        public static void LogIfCountIncorrect(IEnumerable<string> iEn, string valName, string link)
        {
            if (iEn.Count() != 1 && iEn.Count() != 0)
            {
                MyLog.IEnCountInvalid(link, iEn.Count(), valName);
            }
        }
    }
}
