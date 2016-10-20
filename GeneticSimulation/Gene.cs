using System;

namespace GeneticSimulation
{
    public class Gene : IGene
    {
        private int _value;
        public Gene(int value, IAllele allele)
        {
            Value = value;
            Allele = allele;
        } 
        public Gene()
        {
            Allele = new Allele();
            Value = 0;
        }

        public IAllele Allele { get; set; }
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                var lessThanMinimum = value < Allele.ValueRange.MinValue;
                var greaterThanMaximum = value > Allele.ValueRange.MaxValue;
                if (lessThanMinimum || greaterThanMaximum)
                    throw new ArgumentOutOfRangeException();
                _value = value;
            }
        }
    }
}