using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassN1V9
{
    class Class1
    {
        public double x1;
        public double y1;
        public double x2;
        public double y2;
        public double k;
        public double b;

        public double Dlina
        {
            get
            {
                return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            }
        }
        public Class1(string a, string b, string c, string d)
        {
            x1 = Convert.ToDouble(a);
            y2 = Convert.ToDouble(b);
            x2 = Convert.ToDouble(c);
            y2 = Convert.ToDouble(d);
        }
        public double YravK
        {
            get
            {
                return k = (y1 - y2) / (x1 - x2);
            }
        }
        public double YravB
        {
            get
            {
                return b = y2 - k * x2;
            }
        }
    }
}
