namespace GeneticSimulation
{
    public interface IGene
    {
        IAllele Allele { get; set; }
        int Value { get; set; }
    }
}