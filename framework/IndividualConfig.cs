namespace Evolve.Framework
{
    class IndividualConfig
    {
        /// <summary>
        /// Number of elements individual should have
        /// </summary>
        public int IndividualSize { get; set; }

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
        /// When a mutation happens, how many times we should mutate a value
        /// </summary>
        public int MutationAmount { get; set; }

    }
}
