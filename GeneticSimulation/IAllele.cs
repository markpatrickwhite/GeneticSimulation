namespace GeneticSimulation
{
    public interface IAllele
    {
        string Name { get; set; }
        IAlleleValueRange ValueRange { get; set; }
    }
}