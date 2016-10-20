using System.Collections.Generic;

namespace GeneticSimulation
{
    public class Genome : IGenome
    {
        public Genome()
        {
            Name = string.Empty;
            Chromosomes = new Dictionary<string, IChromosome>();
        }
        public Genome(string name, Dictionary<string, IChromosome> chromosomes)
        {
            Name = name;
            Chromosomes = chromosomes;
        }

        public string Name { get; set; }
        public Dictionary<string, IChromosome> Chromosomes { get; set; }

        public void AddChromosome(IChromosome chromosome)
        {
            var name = chromosome.Name;
            if (Chromosomes.ContainsKey(name))
            {
                AddDuplicateChromosome(chromosome);
            }
            else
            {
                Chromosomes.Add(name, chromosome);
            }
        }

        private void AddDuplicateChromosome(IChromosome chromosome)
        {
            chromosome.Name = $"{chromosome.Name}_copy";
            AddChromosome(chromosome);
        }

        public void RemoveChromosome(string key)
        {
            Chromosomes.Remove(key);
        }
    }
}
