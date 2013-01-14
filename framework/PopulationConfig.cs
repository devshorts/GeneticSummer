using System;

namespace Evolve.Framework
{
    class PopulationConfig
    {
        /// <summary>
        /// Number of individuals
        /// </summary>
        public int PopulationSize { get; set; }

        /// <summary>
        /// Integer representing mutation chance (0-100)
        /// </summary>
        public int MutationChance { get; set; }

        /// <summary>
        /// The top 20%
        /// </summary>
        public int SurvivorCount { get { return Convert.ToInt32(0.2 * PopulationSize); } }

        public IndividualConfig IndividualConfig { get; set; }
    }
}
