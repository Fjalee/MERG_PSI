using System;
using System.Collections.Generic;
using System.Text;

namespace MERG_BackEnd
{
    public class Tools
    {
        public Tuple<bool, int> ConvertToInt(string text)
        {
            var succes = int.TryParse(text, out var number);
            if (succes)
            {
                return new Tuple<bool, int>(succes, number);
            }
            return new Tuple<bool, int>(succes, 0);
        }
    }
}
