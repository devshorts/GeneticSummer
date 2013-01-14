using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolve
{
    class PopulationConfig
    {
        /// <summary>
        /// When a mutation happens, how many times we should mutate a value
        /// </summary>
        public int MutationAmount { get; set; }
        /// <summary>
        /// Number of individuals
        /// </summary>
        public int PopulationSize { get; set; }

        /// <summary>
        /// Number of elements individual should have
        /// </summary>
        public int IndividualSize { get; set; }

        /// <summary>
        /// Integer representing mutation chance (0-100)
        /// </summary>
        public int MutationChance { get; set; }

        /// <summary>
        /// Min value individual can contain
        /// </summary>
        public int Min { get; set; }

        /// <summary>
        /// Max value individual can contain
        /// </summary>
        public int Max { get; set; }

        /// <summary>
        /// Target value
        /// </summary>
        public double Target { get; set; }


        /// <summary>
        /// The top 20%
        /// </summary>
        public int SurvivorCount { get { return Convert.ToInt32(0.2 * PopulationSize); } }
    }
}
