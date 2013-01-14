using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolve
{
    class Evolver
    {
        public EvolveConfig Config { get; set; }

        public Population Evolve()
        {
            var population = new Population(Config);

            while (ShouldEvolve(population))
            {
                population = Evolve(population);
                //Console.WriteLine("Fitness {0}", population.Grade());
            }

            return population;
        }

        private bool ShouldEvolve(Population population)
        {
            return Math.Round(population.Grade(), Config.Precision) != Math.Round(0.0, Config.Precision);
        }

        private Population Evolve(Population current)
        {
            return new Population(current.NextGeneration(), Config);
        }
    }
}
