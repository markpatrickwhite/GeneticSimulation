using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeneticSimulation.UnitTests
{
    [TestClass]
    public class AlleleTests
    {
        [TestMethod]
        public void ctor_ShouldNotBeNull()
        {
            var sut = new Allele();
            sut.Should().NotBeNull();
        }

        [TestMethod]
        public void ctor_ValueRange_ShouldNotBeNull()
        {
            var sut = new Allele();
            sut.ValueRange.Should().NotBeNull();
        }
    }
}