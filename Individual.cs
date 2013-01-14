using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolve
{
    class Individual
    {
        private static readonly Random Random = new Random();

        private readonly EvolveConfig Config;

        private List<double> Current { get; set; }

        public double Fitness
        {
            get
            {
                return Math.Abs(Config.PopulationConfig.Target - Sum);
            }
        }

        public double Sum
        {
            get
            {
                return Current.Aggregate(0.0, (acc, item) => acc + item);
            }
        }

        public Individual(EvolveConfig config)
        {
            Config = config;

            Current = Enumerable.Range(0, config.PopulationConfig.IndividualSize)
                                .Select(_ => GetValue()).ToList();
        }

        private double GetValue()
        {
            return Math.Round(Random.NextDouble() * (Config.PopulationConfig.Max - Config.PopulationConfig.Min) + Config.PopulationConfig.Min, Config.Precision);
        }

        public Individual(IEnumerable<double> values, EvolveConfig config)
        {
            Config = config;

            Current = values.ToList();
        }

        public Individual Mutate()
        {
            List<double> mutations = Current;

            for (int i = 0; i < 2; i++)
            {
                var position = Random.Next(0, mutations.Count());

                var length = mutations.Count();

                var start = mutations.Take(position);
                var end = mutations.Skip(position + 1).Take(length - position - 1);
                mutations = start.Concat(new[] {GetValue()}).Concat(end).ToList();
            }

            return new Individual(mutations, Config);
        }

        public Individual BreedWith(Individual mate)
        {
            if (mate == this)
            {
                return null;
            }

            var newGenome = Current.Zip(mate.Current, (father, mother) => Random.Next(0, 100) > 50 ? father : mother);

            return new Individual(newGenome, Config);
        }

        public override string ToString()
        {
            var s = "[" + Current.Aggregate("", (acc, item) => acc + item + ", ");

            return s.Trim(new[] {' ', ','}) + "]";
        }
    }
}
