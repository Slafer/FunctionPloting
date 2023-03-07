using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace progaexam
{
    class Calculation
    {
        private Func<double, double> f;
        
        public Calculation(Func<double,double> func)
        {
            this.f = func;
        }
        public double FindRoot(double a, double b, double ep)
        {
            double c;
            while (Math.Abs(b - a) > ep)
            {
                c = b;
                b = b - (b - a) * f(b) / (f(b) - f(a));
                a = c;
            }
            return b;
        }
    }
}
