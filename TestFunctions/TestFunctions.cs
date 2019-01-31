using DifferentialEvolution.DE;
using System;

namespace DifferentialEvolution
{
    public class TestFunctions
    {
        public static Tuple<double, double> SphereDomain = new Tuple<double, double>(-5.12, 5.12);
        public static Tuple<double, double> RastriginDomain = new Tuple<double, double>(-5.12, 5.12);
        public static Tuple<double, double> MichalewiczDomain = new Tuple<double, double>(0, Math.PI);
        public static Tuple<double, double> SchwefelDomain = new Tuple<double, double>(-500, 500);
        public static Tuple<double, double> AckleyDomain = new Tuple<double, double>(-32.768, 32.768);
        public static Tuple<double, double> GriewankDomain = new Tuple<double, double>(-600, 600);

        /// <summary>
        /// min is at f(0,0) = 0
        /// </summary>
        public static double SphereFunction(Individual individual, int dimensions)
        {
            double sum = 0;

            foreach (double x in individual.Elements)
            {
                sum += Math.Pow(x, 2);
            }
            return sum;
        }

        /// <summary>
        /// min is at f(0,0) = 0
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

        /// <summary>
        /// min is at  f(2.20, 1.57) = -1.8013
        /// </summary>
        public static double MichalewiczFunction(Individual individual, int dimensions)
        {
            double outcome = 0;
            double sum = 0;
            double m = 10;

            for (int i = 0; i < dimensions; i++)
            {
                sum += Math.Sin(individual.Elements[i])
                    *
                    Math.Pow(
                            Math.Sin(((i + 1) * Math.Pow(individual.Elements[i], 2))
                                    / Math.PI)
                            , 2 * m);
            }

            outcome = -1 * sum;

            return outcome;
        }

        /// <summary>
        /// min is at f(420.9687,420.9687) = 0
        /// </summary>
        public static double SchwefelFunction(Individual individual, int dimensions)
        {
            double outcome = 0;
            double sum = 0;
            outcome = 418.9829 * dimensions;

            for (int i = 0; i < dimensions; i++)
            {
                sum += individual.Elements[i] * (Math.Sin(Math.Sqrt(Math.Abs(individual.Elements[i]))));
            }

            outcome -= sum;
            return outcome;
        }

        /// <summary>
        /// min is at f(X) = 0 at X = (0,...,0)
        /// </summary>
        public static double AckleyFunction(Individual individual, int dimensions)
        {
            double a = 20;
            double b = 0.2;
            double c = 2 * Math.PI;

            double firstSum = 0;
            double secondSum = 0;

            for (int i = 0; i < dimensions; i++)
            {
                firstSum += Math.Pow(individual.Elements[i], 2);
            }

            for (int i = 0; i < dimensions; i++)
            {
                secondSum += Math.Cos(c * individual.Elements[i]);
            }

            double firstPart = Math.Exp(-b * Math.Sqrt((1 / dimensions) * firstSum));
            double secondPart = Math.Exp((1 / dimensions) * secondSum);

            return -a * firstPart - secondPart + a + Math.Exp(1);
        }

        /// <summary>
        /// min is at f(X) = 0 at X = (0,...,0)
        /// </summary>
        public static double GriewankFunction(Individual individual, int dimensions)
        {
            double firstSum = 0;
            double prod = 1;

            for (int i = 0; i < dimensions; i++)
            {
                firstSum += (Math.Pow(individual.Elements[i], 2) / 4000.0);
            }

            for (int i = 0; i < dimensions; i++)
            {
                prod *= Math.Cos(individual.Elements[i] / Math.Sqrt(i + 1));
            }

            return (firstSum - prod) + 1;
        }
    }
}
