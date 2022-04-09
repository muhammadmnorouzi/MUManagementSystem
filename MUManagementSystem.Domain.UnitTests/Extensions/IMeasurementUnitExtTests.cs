using System;

using MUManagementSystem.Domain.Models.Abstractions;
using MUManagementSystem.Domain.Models;
using Xunit;
using MUManagementSystem.Domain.Extensions;
using Shouldly;

namespace MUManagementSystem.Domain.UnitTests.Extensions
{
    public class IMeasurementUnitExtTests
    {
        [Fact]
        public void CoefficientMeasurementUnit_ShouldReturnSameValueForSameIMeasurementUnit()
        {
            // Given
            IMeasurementUnit measurementUnit = new CoefficientMeasurementUnit(
                Guid.NewGuid(),
                Guid.NewGuid(),
                "arbitrary",
                "arb",
                1.7M);

            decimal givenValue = 12.3M;

            // When
            decimal result = measurementUnit.ConvertTo(givenValue, measurementUnit);

            // Then
            result.ShouldBe(givenValue);
        }

        [Fact]
        public void FormulizedMeasurmentUnit_ShouldReturnSameValueForSameIMeasurementUnit()
        {
            // Given
            IMeasurementUnit measurementUnit = new FormulizedMeasurmentUnit(
                Guid.NewGuid() , 
                Guid.NewGuid(), 
                "arbitrary", 
                "arb",
                new MeasurementUnitFormula("a + 15") ,
                new MeasurementUnitFormula("a - 15"));

            decimal givenValue = 12.3M;

            // When
            decimal result = measurementUnit.ConvertTo(givenValue, measurementUnit);

            // Then
            result.ShouldBe(givenValue);
        }

        [Fact]
        public void PrimaryMeasurementUnit_ShouldReturnSameValueForSameIMeasurementUnit()
        {
            // Given
            IMeasurementUnit measurementUnit = new PrimaryMeasurementUnit(
                Guid.NewGuid(), "arbitrary", "arb", "some dimension");

            decimal givenValue = 12.3M;

            // When
            decimal result = measurementUnit.ConvertTo(givenValue, measurementUnit);

            // Then
            result.ShouldBe(givenValue);
        }
    }
}
