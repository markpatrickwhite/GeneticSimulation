using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeneticSimulation.UnitTests
{
    [TestClass]
    public class AlleleValueRangeTests
    {
        [TestMethod]
        public void ctor_ShouldNotBeNull()
        {
            var sut = new AlleleValueRange();
            sut.Should().NotBeNull();
        }
    }
}