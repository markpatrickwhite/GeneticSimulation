using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeneticSimulation.UnitTests
{
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
}