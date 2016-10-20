using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeneticSimulation.UnitTests
{
    [TestClass]
    public class ChromosomeTests
    {
        [TestMethod]
        public void ctor_ShouldNotBeNull()
        {
            var sut = new Chromosome();
            sut.Should().NotBeNull();
        }
        [TestMethod]
        public void ctor_ShouldNotThrowWhenAddingDuplicateGene()
        {
            var sameName = "TEST1";
            var sut = new Chromosome();
            var fakeGene1 = new Gene {Allele = {Name = sameName}};
            var fakeGene2 = new Gene {Allele = {Name = sameName}};

            Action act = () =>
            {
                sut.AddGene(fakeGene1);
                sut.AddGene(fakeGene2);
            };
            act.ShouldNotThrow();
        }
        [TestMethod]
        public void ctor_ShouldThrowWhenAddingNullGene()
        {
            var sut = new Chromosome();
            Action act = () =>
            {
                sut.AddGene(null);
            };
            act.ShouldThrow<NullReferenceException>();
        }

        [TestMethod]
        public void ctor_ShouldNotThrowWhenRemovingMissingGene()
        {
            var nonExistantName = "TEST1";
            var sut = new Chromosome();
            Action act = () => { sut.RemoveGene(nonExistantName); };
            act.ShouldNotThrow();
        }
    }
}