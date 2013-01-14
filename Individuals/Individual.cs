using System;
using System.Collections.Generic;
using System.Linq;
using Evolve.Framework;

namespace Evolve.Individuals
{
    class Individual : IIndividual
    {
        private static readonly Random Random = new Random();

        private readonly EvolveConfig GlobalConfig;
        private readonly IndividualConfig IndividualConfig;

        private List<double> Current { get; set; }

        public double Fitness
        {
            get
            {
                return Math.Abs(IndividualConfig.Target - Sum);
            }
        }

        public double Sum
        {
            get
            {
                return Current.Aggregate(0.0, (acc, item) => acc + item);
            }
        }

        public Individual(EvolveConfig globalConfig, IndividualConfig individualConfig)
        {
            GlobalConfig = globalConfig;

            IndividualConfig = individualConfig;

            Current = Enumerable.Range(0, IndividualConfig.IndividualSize)
                                .Select(_ => GetValue()).ToList();
        }

        private double GetValue()
        {
            return Math.Round(Random.NextDouble() * (IndividualConfig.Max - IndividualConfig.Min) + IndividualConfig.Min, GlobalConfig.Precision);
        }

        public Individual(IEnumerable<double> values, EvolveConfig globalConfig, IndividualConfig individualConfig)
        {
            GlobalConfig = globalConfig;

            IndividualConfig = individualConfig;

            Current = values.ToList();
        }

        public IIndividual Mutate()
        {
            List<double> mutations = Current;

            for (int i = 0; i < IndividualConfig.MutationAmount; i++)
            {
                var position = Random.Next(0, mutations.Count());

                var length = mutations.Count();

                var start = mutations.Take(position);
                var end = mutations.Skip(position + 1).Take(length - position - 1);
                mutations = start.Concat(new[] {GetValue()}).Concat(end).ToList();
            }

            return CreateIndividual(mutations);
        }

        public IIndividual BreedWith(IIndividual mate)
        {
            if (mate == this)
            {
                return null;
            }

            var newGenome = Current.Zip((mate as Individual).Current, (father, mother) => Random.Next(0, 100) > 50 ? father : mother);

            return CreateIndividual(newGenome);
        }

        public override string ToString()
        {
            var s = "[" + Current.Aggregate("", (acc, item) => acc + item + ", ");

            return s.Trim(new[] {' ', ','}) + "]";
        }

        private IIndividual CreateIndividual(IEnumerable<double> genome)
        {
            return new Individual(genome, GlobalConfig, IndividualConfig);
        } 
    }
}
