using System;
using Evolve.Individuals;

namespace Evolve.Framework
{
    class IndividualFactory
    {
        private static Lazy<IndividualFactory> _instance = new Lazy<IndividualFactory>();
        public static IndividualFactory Instance
        {
            get { return _instance.Value; }
        }

        public IIndividual CreateIndividual(EvolveConfig config)
        {
            return new Individual(config);
        }
    }
}
