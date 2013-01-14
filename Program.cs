using System;
using System.Linq;
using Evolve.Common;
using Evolve.Framework;
using Evolve.Individuals;

namespace Evolve
{
    class Program
    {
        static void Main(string[] args)
        {
            var evolverConfig = GetEvolutionConfig();

            var indiviualConfig = new IndividualConfig
                                  {
                                      MutationAmount = 2,
                                      IndividualSize = 10,
                                      Max = 20,
                                      Min = 0,
                                      Target = 10.9
                                  };


            var evolver = new Evolver
                          {
                              Config = evolverConfig
                          };

            IndividualFactory.Instance.RegisterNew(() => new Individual(evolverConfig, indiviualConfig));

            var finalPopulation = evolver.Evolve();

            PrintEndPopulationStats(finalPopulation, evolverConfig, indiviualConfig);
        }

        private static void PrintEndPopulationStats(Population finalPopulation, EvolveConfig config, IndividualConfig individualConfig)
        {
            Console.WriteLine("Final population fitness {0}", finalPopulation.Grade());
            Console.WriteLine("Accepted values:");
            finalPopulation.Individuals.Where(i => Math.Round((i as Individual).Sum, config.Precision) == Math.Round(individualConfig.Target, config.Precision))
                                       .GroupBy(i => i.ToString())
                                       .ForEach(i => Console.WriteLine("{0} indiviuals {1} sum to {2}", i.Count(), i.First(), (i.First() as Individual).Sum));
        }

        private static EvolveConfig GetEvolutionConfig()
        {
            return new EvolveConfig
                   {
                       PopulationConfig = new PopulationConfig
                                          {
                                              MutationChance = 0.1,
                                              PopulationSize = 10000
                                          },
                       Precision = 1
                   };

        }
    }
}
