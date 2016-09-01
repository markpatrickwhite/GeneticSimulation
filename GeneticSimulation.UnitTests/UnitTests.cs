using System;
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

    [TestClass]
    public class GeneTests
    {
        [TestMethod]
        public void ctor_ShouldNotBeNull()
        {
            var sut = new Gene();
            sut.Should().NotBeNull();
        }

        [TestMethod]
        public void ctor_Allele_ShouldNotBeNull()
        {
            var sut = new Gene();
            sut.Allele.Should().NotBeNull();
        }

        [TestMethod]
        public void ctor_Value_ShouldBeWithinRangeByDefault()
        {
            var sut = new Gene();
            var minimumValue = sut.Allele.ValueRange.MinValue;
            var maximumValue = sut.Allele.ValueRange.MaxValue;
            sut.Value.Should().BeInRange(minimumValue, maximumValue);
        }

        [TestMethod]
        public void ctor_Value_ShouldThrowWhenValueLessThanAlleleRange()
        {
            Action act = () =>
            {
                var gene = new Gene
                {
                    Allele = {ValueRange = new AlleleValueRange(3, 5)},
                    Value = 1
                };
            };
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [TestMethod]
        public void ctor_Value_ShouldThrowWhenValueGreaterThanAlleleRange()
        {
            Action act = () =>
            {
                var gene = new Gene
                {
                    Allele = {ValueRange = new AlleleValueRange(3, 5)},
                    Value = 7
                };
            };
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [TestMethod]
        public void ctor_Value_ShouldNotThrowWhenValueAlleleRangeLowerBoundary()
        {
            var sut = new Gene
            {
                Allele = {ValueRange = new AlleleValueRange(3, 5)},
                Value = 3
            };
            var minimumValue = sut.Allele.ValueRange.MinValue;
            var maximumValue = sut.Allele.ValueRange.MaxValue;
            sut.Value.Should().BeInRange(minimumValue, maximumValue);
        }

        [TestMethod]
        public void ctor_Value_ShouldNotThrowWhenValueAlleleRangeUpperBoundary()
        {
            var sut = new Gene
            {
                Allele = {ValueRange = new AlleleValueRange(3, 5)},
                Value = 5
            };
            var minimumValue = sut.Allele.ValueRange.MinValue;
            var maximumValue = sut.Allele.ValueRange.MaxValue;
            sut.Value.Should().BeInRange(minimumValue, maximumValue);
        }
    }

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