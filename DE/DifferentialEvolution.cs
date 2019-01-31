using DifferentialEvolution.Helpers;
using System;
using System.Collections.Generic;

namespace DifferentialEvolution.DE
{
    public class DifferentialEvolution
    {
        #region Properties
        public Population Population { get; set; }
        public Parameters Parameters { get; set; }
        #endregion

        #region Events
        public event EventHandler OnGenerationComplete;
        public event EventHandler OnRunComplete;
        #endregion

        public DifferentialEvolution(Population population, Parameters parameters)
        {
            Population = population;
            Parameters = parameters;
        }

        public void Run(int maxEvaluations, double CR, double F)
        {
            Population.Evaluate(Parameters.FitnessFunction);

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

                            if (CheckIfWithinDomain(newElement, Parameters))
                            {
                                candidate.Elements.Add(newElement);
                            }
                            else
                            {
                                candidate.Elements.Add(orginalElement);
                            }
                        }
                        else
                        {
                            candidate.Elements.Add(orginalElement);
                        }

                        i++;
                    }

                    if (candidate.Evaluate(Parameters.FitnessFunction) < orginal.Evaluate(Parameters.FitnessFunction))
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

        private bool CheckIfWithinDomain(double newElement, Parameters parameters)
        {
            return newElement > Parameters.Domain.Item1 && newElement < Parameters.Domain.Item2;
        }
    }
}
