namespace Evolve.Framework
{
    interface IIndividual
    {
        IIndividual Mutate();
        IIndividual BreedWith(IIndividual mate);
        double Fitness { get; }
    }
}
