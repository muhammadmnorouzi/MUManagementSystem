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
            primary = CreatePrimaryMeasurementUnit();

            formulized = CreateFormulizedMeasurmentUnit();

            coefficient = CreateCoefficientMeasurementUnit();
        }

        [Fact]
        public void ConvertTo_ShouldThrowInvalidOperationExceptionWhenBaseMeasurementUnitIdsAreNotEqual()
        {
            // Given
            IMeasurementUnit primary = CreatePrimaryMeasurementUnit();
            IMeasurementUnit formulized = CreateFormulizedMeasurmentUnit();
            IMeasurementUnit coefficient = CreateCoefficientMeasurementUnit();

            // Then
            Should.Throw<InvalidOperationException>(() => primary.ConvertTo(1, formulized));
            Should.Throw<InvalidOperationException>(() => primary.ConvertTo(1, coefficient));

            Should.Throw<InvalidOperationException>(() => formulized.ConvertTo(1, primary));
            Should.Throw<InvalidOperationException>(() => formulized.ConvertTo(1, coefficient));

            Should.Throw<InvalidOperationException>(() => coefficient.ConvertTo(1, primary));
            Should.Throw<InvalidOperationException>(() => coefficient.ConvertTo(1, formulized));
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

        private CoefficientMeasurementUnit CreateCoefficientMeasurementUnit(Guid? baseMeasurementUnitId = null)
        {
            if (!baseMeasurementUnitId.HasValue)
            {
                baseMeasurementUnitId = Guid.NewGuid();
            }

            return new CoefficientMeasurementUnit(
               Guid.NewGuid(),
               baseMeasurementUnitId,
               "arbitrary",
               "arb",
               2.0M);
        }

        private FormulizedMeasurmentUnit CreateFormulizedMeasurmentUnit(Guid? baseMeasurementUnitId = null)
        {
            if (!baseMeasurementUnitId.HasValue)
            {
                baseMeasurementUnitId = Guid.NewGuid();
            }

            return new FormulizedMeasurmentUnit(
                Guid.NewGuid(),
                baseMeasurementUnitId.Value,
                "arbitrary formulized",
                "arb",
                new MeasurementUnitFormula("a + 15"),
                new MeasurementUnitFormula("a - 15"));
        }

        private PrimaryMeasurementUnit CreatePrimaryMeasurementUnit(Guid? baseMeasurementUnitId = null)
        {
            if (!baseMeasurementUnitId.HasValue)
            {
                baseMeasurementUnitId = Guid.NewGuid();
            }

            return new PrimaryMeasurementUnit(
                 baseMeasurementUnitId.Value,
                 "arbitrary primary",
                 "arb",
                 "some dimension");
        }
    }
}
