using System;
using System.Collections.Generic;
using System.Text;

namespace Series
{
    class ArithmeticProgression : Series
    {
        private double d;
        public ArithmeticProgression(double a1, double d, int n)
        {
            expFunc = n => (a1 + (n - 1) * d);
            func = expFunc.Compile();
            this.d = d;
        }



        public override bool Convergence()
        {
            if (d != 0)
                return false;
            return true;
        }
    }
}
