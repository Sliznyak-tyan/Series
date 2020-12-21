using System;
using System.Collections.Generic;
using System.Text;

namespace Series
{
    class GeometricProgression : Series
    {
        private double q;
        public GeometricProgression(double b1, double q)
        {
            expFunc = n => b1 * Math.Pow(q, n - 1);
            func = expFunc.Compile();
            this.q = q;
        }


        public override bool Convergence()
        {
            if (Math.Abs(q) >= 1)
                return false;

            return true;
        }
    }
}
