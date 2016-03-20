using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Utils
    {
        public static void SwapValues(ref double x, ref double y)
        {
            double temp = x;
            x = y;
            y = temp;
        }
    }
}
