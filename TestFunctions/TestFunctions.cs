using DifferentialEvolution.DE;
using System;

namespace DifferentialEvolution
{
    public class TestFunctions
    {
        public static Tuple<double, double> RastriginDomain = new Tuple<double, double>(-5.12, 5.12);

        /// <summary>
        /// Rastrigin function 
        /// </summary>
        public static double RastriginFunction(Individual individual, int dimensions)
        {
            double sum = 0;

            foreach (double x in individual.Elements)
            {
                sum += Math.Pow(x, 2) - 10 * Math.Cos(2 * Math.PI * x);
            }
            return 10 * dimensions + sum;
        }
    }
}
