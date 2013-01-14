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
            var config = new EvolveConfig
            {
                PopulationConfig = new PopulationConfig
                {
                    MutationChance = 1,
                    PopulationSize = 100,
                    IndividualConfig = new IndividualConfig
                    {
                        MutationAmount = 2,
                        IndividualSize = 5,
                        Max = 20,
                        Min = 0,
                        Target = 10.9
                    }
                },
                Precision = 1
            };

            var evolver = new Evolver
            {
                Config = config
            };

            var finalPopulation = evolver.Evolve();

            Console.WriteLine("Final population fitness {0}", finalPopulation.Grade());
            Console.WriteLine("Accepted values:");
            finalPopulation.Individuals.Where(i=> Math.Round((i as Individual).Sum, config.Precision) == Math.Round(config.PopulationConfig.IndividualConfig.Target, config.Precision))
                                       .GroupBy(i => i.ToString())
                                       .ForEach(i=> Console.WriteLine("{0} indiviuals {1} sum to {2}", i.Count(), i.First(), (i.First() as Individual).Sum));
        }
    }
}
