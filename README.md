GeneticSummer
=============

Given some population dynamics finds a set of doubles that sum to the target value using a genetic algorithm. Based on a genetic algorithm walkthrough blog post by [lethain.com](http://lethain.com/genetic-algorithms-cool-name-damn-simple/).

Sample Application:

```csharp
static void Main(string[] args)
{
    var evolverConfig = GetEvolutionConfig();

    var indiviualConfig = new IndividualConfig
                            {
                                MutationAmount = 2,
                                IndividualSize = 10,
                                Max = 20,
                                Min = 0,
                                Target = 10.9
                            };


    var evolver = new Evolver
                    {
                        Config = evolverConfig
                    };

    IndividualFactory.Instance.RegisterNew(() => new Individual(evolverConfig, indiviualConfig));

    var finalPopulation = evolver.Evolve();

    PrintEndPopulationStats(finalPopulation, evolverConfig, indiviualConfig);
}

private static void PrintEndPopulationStats(Population finalPopulation, EvolveConfig config, IndividualConfig individualConfig)
{
    Console.WriteLine("Final population fitness {0}", finalPopulation.Grade());
    Console.WriteLine("Accepted values:");
    finalPopulation.Individuals.Where(i => Math.Round((i as Individual).Sum, config.Precision) == Math.Round(individualConfig.Target, config.Precision))
                                .GroupBy(i => i.ToString())
                                .ForEach(i => Console.WriteLine("{0} indiviuals {1} sum to {2}", i.Count(), i.First(), (i.First() as Individual).Sum));
}

private static EvolveConfig GetEvolutionConfig()
{
    return new EvolveConfig
            {
                PopulationConfig = new PopulationConfig
                                    {
                                        MutationChance = 0.1,
                                        PopulationSize = 100
                                    },
                Precision = 1
            };

}
```

Output:
        
```        
Final population fitness 0.0220000000000029
Accepted values:
78 indiviuals [0.1, 0.2, 0.3, 0.2, 0, 0.1, 0, 0.2, 0, 0.2, 0.1, 0, 0.1, 0, 0, 0,
 0, 0.3, 0.5, 0.1, 0, 0.1, 0, 0.3, 0.1, 0.1, 0, 0.1, 0.2, 0.2, 0.2, 0.1, 0, 0.4,
 0.2, 0.2, 0, 0.1, 0.1, 0.1, 0.1, 0.2, 0, 0.1, 0, 0.1, 0, 0.1, 0.1, 0, 0.1, 0.1,
 0.2, 0, 0.1, 0.2, 0.1, 0, 0.2, 0, 0, 0, 0.1, 0.1, 0, 0.2, 0.2, 0, 0.2, 0.2, 0.3
, 0.1, 0, 0.1, 0.1, 0, 0, 0.3, 0.1, 0, 0.1, 0, 0.2, 0.2, 0, 0.1, 0, 0.3, 0.1, 0.
3, 0.1, 0.1, 0, 0.1, 0.4, 0.1, 0, 0.2, 0, 0] sum to 10.9
```