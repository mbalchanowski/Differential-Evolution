using System.Collections.Generic;
using System.Linq;

namespace DifferentialEvolution.DE
{
    public class Population
    {
        public List<Individual> Solutions { get; set; }
        public double AverageFitness { get { return Solutions.Average(x => x.Fitness); } }
        public double MaximumFitness { get { return Solutions.Max(x => x.Fitness); } }
        public double MinimumFitness { get { return Solutions.Min(x => x.Fitness); } }
        public double TotalSumFitness { get { return Solutions.Sum(x => x.Fitness); } }

        public Population(List<Individual> individuals)
        {
            Solutions = individuals;
        }

        public Individual GetBest()
        {
            return Solutions.OrderBy(x => x.Fitness).FirstOrDefault();
        }

        public void Evaluate(FitnessFunction fitnessFunctionDelegate)
        {
            foreach (var item in Solutions)
            {
                item.Evaluate(fitnessFunctionDelegate);
            }
        }
    }
}
