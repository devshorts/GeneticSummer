GeneticSummer
=============

Given some population dynamics finds a set of doubles that sum to the target value using a genetic algorithm


Sample Application:

```csharp
static void Main(string[] args)
        {
            var config = new EvolveConfig
                {
                    PopulationConfig = new PopulationConfig
                        {
                            IndividualSize = 100,
                            Max = 20,
                            Min = 0,
                            MutationChance = 1,
                            MutationAmount = 2,
                            PopulationSize = 100,
                            Target = 10.9
                        },
                    Precision = 1
                };
            var evolver = new Evolver
                {
                    Config = config
                };

            var finalPopulation = evolver.Evolve();

            Console.WriteLine("Final population fitness {0}", finalPopulation.Grade());
            Console.WriteLine("Accepted values:");
            finalPopulation.Individuals.Where(i=> Math.Round(i.Sum, config.Precision) == Math.Round(config.PopulationConfig.Target, config.Precision))
                                       .GroupBy(i => i.ToString())
                                       .ForEach(i=> Console.WriteLine("{0} indiviuals {1} sum to {2}", i.Count(), i.First(), i.First().Sum));
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