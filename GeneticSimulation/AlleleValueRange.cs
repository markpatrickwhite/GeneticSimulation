using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticSimulation
{
    public class AlleleValueRange : IAlleleValueRange
    {
        public AlleleValueRange()
        {
            MinValue = 0;
            MaxValue = 0;
        }

        public AlleleValueRange(int min, int max)
        {
            MinValue = min;
            MaxValue = max;
        }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
    }
}
