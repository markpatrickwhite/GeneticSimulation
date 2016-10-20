using System.Collections.Generic;

namespace GeneticSimulation
{
    public interface IChromosome
    {
        string Name { get; set; }
        Dictionary<string, IGene> Genes { get; set; }
        void AddGene(IGene gene);
        void RemoveGene(string key);
    }
}