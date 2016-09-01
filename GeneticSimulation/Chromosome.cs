﻿using System.Collections.Generic;

namespace GeneticSimulation
{
    public class Chromosome : IChromosome
    {
        public Chromosome()
        {
            Name = string.Empty;
            Genes = new Dictionary<string, IGene>();
        }
        public Chromosome(string name, Dictionary<string, IGene> genes)
        {
            Name = name;
            Genes = genes;
        }

        public string Name { get; set; }
        public Dictionary<string, IGene> Genes { get; set; }

        public void AddGene(IGene gene)
        {
            var name = gene.Allele.Name;
            if (Genes.ContainsKey(name))
            {
                AddDuplicateGene(gene);
            }
            else
            {
                Genes.Add(name, gene); 
            }
        }

        private void AddDuplicateGene(IGene gene)
        {
            gene.Allele.Name = $"{gene.Allele.Name}_copy";
            AddGene(gene);
        }

        public void RemoveGene(string key)
        {
            Genes.Remove(key);
        }

        public IChromosome Recombine(IChromosome chromosome)
        {
            var recombinedChromosome = new Chromosome();
            //TODO: what if gene count is different between chromosomes?
            //TODO: instead of foreach: iterate through both chromosomes, match genes; if no match, look ahead; on match, pick one at random to use. For look ahead, if next set matches either, use that; otherwise, continue.
            foreach (var gene in chromosome.Genes)
            {
                //TODO: consider handling allele dominance
                //TODO: determine parent gene randomly

                //TODO: determine error chance, and error type if error occurs
                //TODO: determine mutation chance, and mutation type if mutation occurs
                //TODO: determine gene recombination result based upon gene selected, errors, and mutation 
            }
            return recombinedChromosome;
        }

    }
}
