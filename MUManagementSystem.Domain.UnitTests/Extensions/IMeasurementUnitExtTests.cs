using MUManagementSystem.Domain.Extensions;
using MUManagementSystem.Domain.Models;
using MUManagementSystem.Domain.Models.Abstractions;
using Shouldly;
using System;
using Xunit;

namespace MUManagementSystem.Domain.UnitTests.Extensions
{
    public class IMeasurementUnitExtTests
    {
        private readonly IMeasurementUnit primary;
        private readonly IMeasurementUnit formulized;
        private readonly IMeasurementUnit coefficient;

        public IMeasurementUnitExtTests()
        {
            primary = new PrimaryMeasurementUnit(
                Guid.NewGuid(),
                "arbitrary",
                "arb",
                "some dimension");

            formulized = new FormulizedMeasurmentUnit(
                Guid.NewGuid(),
                Guid.NewGuid(),
                "arbitrary",
                "arb",
                new MeasurementUnitFormula("a + 15"),
                new MeasurementUnitFormula("a - 15"));

            coefficient = new CoefficientMeasurementUnit(
               Guid.NewGuid(),
               Guid.NewGuid(),
               "arbitrary",
               "arb",
               2.0M);
        }

        [Fact]
        public void ConvertTo_FromOneToOther_ShouldReturnTheCorrectValue()
        {
            decimal givenValue = 16.0M;
            decimal result = default;

            result = primary.ConvertTo(givenValue, formulized);
            result.ShouldBe(givenValue + 15);

            result = primary.ConvertTo(givenValue, coefficient);
            result.ShouldBe(givenValue * 2.0M);

            result = coefficient.ConvertTo(givenValue, primary);
            result.ShouldBe(givenValue / 2.0M);

            result = coefficient.ConvertTo(givenValue, formulized);
            result.ShouldBe(givenValue / 2.0M + 15);

            result = formulized.ConvertTo(givenValue, primary);
            result.ShouldBe(givenValue - 15);

            result = formulized.ConvertTo(givenValue, coefficient);
            result.ShouldBe((givenValue - 15) * 2.0M);
        }

        [Fact]
        public void ConvertTo_FromOneToItself_ShouldReturnTheSame()
        {
            decimal givenValue = 16.0M;

            // Then
            decimal result = default;

            result = primary.ConvertTo(givenValue, primary);
            result.ShouldBe(givenValue);

            result = coefficient.ConvertTo(givenValue, coefficient);
            result.ShouldBe(givenValue);

            result = formulized.ConvertTo(givenValue, formulized);
            result.ShouldBe(givenValue);

        }
    }
}
