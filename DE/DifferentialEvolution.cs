using DifferentialEvolution.Helpers;
using System;
using System.Collections.Generic;

namespace DifferentialEvolution.DE
{
    public class DifferentialEvolution
    {
        #region Properties
        public Population Population { get; set; }
        private FitnessFunction FitnessFunction { get; set; }
        #endregion

        #region Events
        public event EventHandler OnGenerationComplete;
        public event EventHandler OnRunComplete;
        #endregion

        public DifferentialEvolution(Population population, FitnessFunction fitnessFunctionDelegate)
        {
            Population = population;
            FitnessFunction = fitnessFunctionDelegate;
        }

        public void Run(int maxEvaluations, double CR, double F)
        {
            Population.Evaluate(FitnessFunction);

            while (maxEvaluations > 0)
            {
                List<Individual> newGeneration = new List<Individual>();

                foreach (var orginal in Population.Solutions)
                {
                    // generate unique random numbers
                    List<int> randomValues = RandomGenerator.GenerateRandom(3, 0, Population.Solutions.Count);
                    int a = randomValues[0];
                    int b = randomValues[1];
                    int c = randomValues[2];

                    // choose random individuals (agents) from population
                    Individual individual1 = Population.Solutions[a];
                    Individual individual2 = Population.Solutions[b];
                    Individual individual3 = Population.Solutions[c];
                    
                    int i = 0;
                    int R = RandomGenerator.Instance.Random.Next(Population.Solutions.Count);
                    Individual candidate = new Individual();
                    foreach (var orginalElement in orginal.Elements)
                    {
                        double ri = RandomGenerator.Instance.Random.NextDouble();
                        if (ri < CR || i == R)
                        {
                            // simple mutation
                            double newElement = individual1.Elements[i] + F * (individual2.Elements[i] - individual3.Elements[i]);
                            candidate.Elements.Add(newElement);
                        }
                        else
                        {
                            candidate.Elements.Add(orginalElement);
                        }

                        i++;
                    }

                    if (candidate.Evaluate(FitnessFunction) < orginal.Evaluate(FitnessFunction))
                        newGeneration.Add(candidate);
                    else
                        newGeneration.Add(orginal);
                }

                // switch populations
                Population.Solutions = newGeneration;
                maxEvaluations--;

                OnGenerationComplete.Invoke(Population, new EventArgs());
            }

            OnRunComplete.Invoke(Population, new EventArgs());
        }
    }
}
