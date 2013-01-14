namespace Evolve.Framework
{
    class EvolveConfig
    {
        /// <summary>
        /// How many decimal points of accuracy we want the solution to be
        /// </summary>
        public int Precision { get; set; }

        public PopulationConfig PopulationConfig { get; set; }
    }
}
