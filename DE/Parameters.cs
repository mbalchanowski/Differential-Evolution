using System;

namespace DifferentialEvolution.DE
{
    public class Parameters
    {
        /// <summary>
        /// Paramater called "Amplification Factor" or "Differential Weight" (0...2) 
        /// </summary>
        public double F { get; set; }

        /// <summary>
        /// Crossover Probability (0...1)
        /// </summary>
        public double CR { get; set; }

        /// <summary>
        /// Number of agents
        /// </summary>
        public int AgentsCount { get; set; }

        /// <summary>
        /// Number of iterations to perform
        /// </summary>
        public int Iterations { get; set; }

        /// <summary>
        /// Number of variables
        /// </summary>
        public int Dimensions { get; set; }

        /// <summary>
        /// Domain of a function
        /// </summary>
        public Tuple<double, double> Domain { get; set; }

        /// <summary>
        /// Function to optimalize
        /// </summary>
        public FitnessFunction FitnessFunction { get ; set; }

        /// <summary>
        /// Default parameters
        /// </summary>
        public Parameters()
        {
            F = 0.5;
            CR = 0.9;
            AgentsCount = 20;
            Iterations = 100;
        }

        public void Show()
        {
            Console.WriteLine("F: " + F);
            Console.WriteLine("CR: " + CR);
            Console.WriteLine("Population Count: " + AgentsCount);
            Console.WriteLine("Iterations: " + Iterations);
            Console.WriteLine("Dimensions: " + Dimensions);
        }
    }
}
