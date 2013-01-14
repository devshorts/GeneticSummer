using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolve
{
    internal class Maters
    {
        private static Random random = new Random();

        private readonly IEnumerable<Individual> _individuals;

        private EvolveConfig Config { get; set; }

        public List<Individual> HighestFitness { get; private set; }
        public List<Individual> Fathers { get; private set; }
        public List<Individual> Mothers { get; private set; }

        public Maters(IEnumerable<Individual> individuals, EvolveConfig config)
        {
            _individuals = individuals;
            Config = config;

            SetFathersAndMothers();
        }

        private Boolean SelectByChance(double chance)
        {
            return random.NextDouble() < chance;
        }

        private List<Individual> BestPerformers()
        {
            var sorted = _individuals.OrderBy(i => i.Fitness).ToList();

            return sorted.Take(Config.PopulationConfig.SurvivorCount).ToList();
        }

        private List<Individual> Random(IEnumerable<Individual> excludes)
        {
            return _individuals.Except(excludes).Where(_ => SelectByChance(0.1)).ToList();
        }

        private void SetFathersAndMothers()
        {
            HighestFitness = BestPerformers();

            var allParents = HighestFitness.Concat(Random(HighestFitness)).Select(ind =>
            {
                if (SelectByChance(Config.PopulationConfig.MutationChance / 100.0))
                {
                    return ind.Mutate();
                }
                return ind;

            }).ToList();

            var half = allParents.Count() / 2;

            Fathers = allParents.Take(half).ToList();

            Mothers = allParents.Skip(half).Take(half).ToList();
        }
    }

}
