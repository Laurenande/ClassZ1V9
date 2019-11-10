using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassN1V9
{
    class Class2 :Class1
    {
        private string color;
        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        public Class2(string x1, string y1, string x2, string y2, string co) : base(x1,y1,x2,y2)
        {
            color = co;
        }

    }
}
