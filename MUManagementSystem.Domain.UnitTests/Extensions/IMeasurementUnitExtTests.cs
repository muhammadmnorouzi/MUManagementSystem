using MUManagementSystem.Domain.Extensions;
using MUManagementSystem.Domain.Models.Abstractions;
using Shouldly;
using System;
using Xunit;

namespace MUManagementSystem.Domain.UnitTests.Extensions
{
    public class IMeasurementUnitExtTests:TestsBase
    {
        public IMeasurementUnitExtTests()
        {
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
            // Given
            Guid baseMeasurementUnitId = Guid.NewGuid();

            IMeasurementUnit primary = CreatePrimaryMeasurementUnit(baseMeasurementUnitId);
            IMeasurementUnit formulized = CreateFormulizedMeasurmentUnit(baseMeasurementUnitId);
            IMeasurementUnit coefficient = CreateCoefficientMeasurementUnit(baseMeasurementUnitId);

            decimal givenValue = 16.0M;
            decimal result = default;

            // Then

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
            // Given
            Guid baseMeasurementUnitId = Guid.NewGuid();

            IMeasurementUnit primary = CreatePrimaryMeasurementUnit(baseMeasurementUnitId);
            IMeasurementUnit formulized = CreateFormulizedMeasurmentUnit(baseMeasurementUnitId);
            IMeasurementUnit coefficient = CreateCoefficientMeasurementUnit(baseMeasurementUnitId);

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
