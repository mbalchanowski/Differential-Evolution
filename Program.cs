using DifferentialEvolution.DE;
using System;

namespace DifferentialEvolution
{
    class Program
    {
        static void Main(string[] args)
        {
            Parameters parameters = new Parameters
            {
                Dimensions = 2,
                FitnessFunction = TestFunctions.RastriginFunction,
                Domain = TestFunctions.RastriginDomain,
                F = 0.5,
                CR = 0.9,
                AgentsCount = 20,
                Iterations = 100
            };

            Solver solver = new Solver(parameters);
            solver.RunDE();

            Console.ReadLine();
        }
    }
}
