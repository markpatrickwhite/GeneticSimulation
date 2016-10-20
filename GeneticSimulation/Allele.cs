using System;

namespace GeneticSimulation
{
    public class Allele : IAllele
    {
        public Allele(string name, IAlleleValueRange alleleValueRange)
        {
            Name = name;
            ValueRange = alleleValueRange;
        }

        public Allele()
        {
            Name = string.Empty;
            ValueRange = new AlleleValueRange();
        }

        public string Name { get; set; }
        public IAlleleValueRange ValueRange { get; set; }
    }
}