using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace Series
{
    class Series
    {
        protected Expression<Func<double, double>> expFunc;
        protected Func<double, double> func;
        private const double eps = 0.000001f;

        public Series(Expression<Func<double, double>> outerFunc)
        {
            expFunc = outerFunc;
            func = expFunc.Compile();
        }



        protected Series()
        {

        }

        public double NSum(int n)
        {
            double sum = 0;
            for (int i = 1; i <= n; i++)
                sum += func(i);
            return sum;
        }

        public virtual bool Convergence()
        {
            const int n = 1000000;
            double sN = func(1);
            double sN1 = func(2);
            int i = 3;
            while (Math.Abs(sN1 - sN) > eps && i < n)
            {
                sN = sN1;
                sN1 += func(i);
                i++;
            }
            if (Math.Abs(sN1 - sN) > eps)
                return false;
            
            return true;
        }


        public double SeriesAdd(Series row, int n)
        {
            if(Convergence() && row.Convergence())
            {
                double sum = 0;
                for(int i = 1; i <= n; i++)
                    sum += (func(i) + row.func(i));
                return sum;
            }
            else
                throw new SeriesDivergenceException("One or two series are divergence");
            
        }



        public double SeriesSub(Series row, int n)
        {
            if (Convergence() && row.Convergence())
            {
                double sub = 0;
                for (int i = 1; i <= n; i++)
                    sub += (func(i) - row.func(i));

                return sub;
            }
            else
                throw new SeriesDivergenceException("One or two series are divergence");
        }



        public double SeriesMult(Series row, int n)
        {
            if (Convergence() && row.Convergence())
            {
                double product = 0;
                for (int i = 1; i <= n; i++)
                    product += (func(i) * row.func(i));

                return product;
            }
            else
                throw new SeriesDivergenceException("One or two series are divergence");
        }



        public double MultByConstant(double k, int n)
        {
                double product = 0;
                for (int i = 1; i <= n; i++)
                    product += k*func(i);

                return product;
        }



        public override string ToString()
        {
            return expFunc.ToString().Split('>')[1].Trim(' ', '(', ')');
        }
    }
}
