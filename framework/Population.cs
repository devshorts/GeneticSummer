using System.Collections.Generic;
using System.Linq;
using Evolve.Common;

namespace Evolve.Framework
{
    class Population
    {
        public IEnumerable<IIndividual> Individuals { get; private set; }

        private EvolveConfig Config { get; set; }
        
        public Population(EvolveConfig config)
        {
            Config = config;

            Individuals = Enumerable.Range(0, config.PopulationConfig.PopulationSize)
                                    .Select(_ => IndividualFactory.Instance.CreateIndividual(Config)).ToList();
        }

        public Population(IEnumerable<IIndividual> individuals, EvolveConfig config)
        {
            Individuals = individuals;

            Config = config;
        }

        public double Grade()
        {
            return Individuals.Aggregate(0.0, (acc, individual) => acc + individual.Fitness) / Individuals.Count();
        }

        public IEnumerable<IIndividual> NextGeneration()
        {
            var maters = new Maters(Individuals, Config);

            var nextIndividuals = new List<IIndividual>(Config.PopulationConfig.PopulationSize);

            while (nextIndividuals.Count() < Config.PopulationConfig.PopulationSize)
            {
                var requiredParents = Config.PopulationConfig.PopulationSize - nextIndividuals.Count();

                var children = Breed(maters.Fathers.Shuffle()
                                                   .Take(requiredParents), maters.Mothers.Shuffle().Take(requiredParents));
                
                nextIndividuals.AddRange(children);
            }

            nextIndividuals = nextIndividuals.Take(Config.PopulationConfig.PopulationSize).ToList();

            return nextIndividuals;
        }

        private List<IIndividual> Breed(IEnumerable<IIndividual> fathers, IEnumerable<IIndividual> mothers)
        {
            return fathers.Zip(mothers, (father, mother) => father.BreedWith(mother))
                          .Where(child => child != null)
                          .ToList();
        }
    }
}
