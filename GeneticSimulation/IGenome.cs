using System.Collections.Generic;

namespace GeneticSimulation
{
    public interface IGenome
    {
        string Name { get; set; }
        Dictionary<string, IChromosome> Chromosomes { get; set; }
        void AddChromosome(IChromosome chromosome);
        void RemoveChromosome(string key);
    }
}