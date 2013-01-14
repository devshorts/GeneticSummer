using System;

namespace Evolve.Framework 
{
    class Evolver
    {
        public EvolveConfig Config { get; set; }

        public Population Evolve()
        {
            var population = new Population(Config);

            while(ShouldEvolve(population))
            {
                population = Evolve(population);
            }

            return population;
        }

        private bool ShouldEvolve(Population population)
        {
            var grade = population.Grade();

            Console.WriteLine(grade);

            return Math.Round(grade, Config.Precision) != Math.Round(0.0, Config.Precision);
        }

        private Population Evolve(Population current)
        {
            return new Population(current.NextGeneration(), Config);
        }
    }
}
