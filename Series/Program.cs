using System;

namespace Series
{
    class Program
    {
        static void Main(string[] args)
        {
            Series series = new Series(n => 1/n);
            ArithmeticProgression ap = new ArithmeticProgression(1, 1, 1000);
            GeometricProgression gp = new GeometricProgression(2, 0.5);
            try
            {
                Console.WriteLine(series.SeriesAdd(gp, 1000));
            }
            catch (SeriesDivergenceException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            Console.WriteLine(series);
        }
    }
}
