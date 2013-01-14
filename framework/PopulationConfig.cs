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
        /// Double representing mutation chance (0.0-1.0)
        /// </summary>
        public double MutationChance { get; set; }

        /// <summary>
        /// The top 20%
        /// </summary>
        public int SurvivorCount { get { return Convert.ToInt32(0.2 * PopulationSize); } }
    }
}
