using MUManagementSystem.Domain.Models;
using MUManagementSystem.Domain.Models.Abstractions;
using Shouldly;
using System;
using Xunit;

namespace MUManagementSystem.Domain.UnitTests.Models
{
    public class FormulizedMeasurmentUnitTests:TestsBase
    {
        [Fact]
        public void Ctor_ShouldThrowExceptionsOnBadArguments()
        {
            Guid id = Guid.NewGuid();
            Guid baseMeasurementUnitId = Guid.NewGuid();
            string goodStr = "some thing";
            MeasurementUnitFormula goodFormula = new MeasurementUnitFormula("a");

            Should.Throw<ArgumentNullException>(() =>
                new FormulizedMeasurmentUnit(id, baseMeasurementUnitId, null!, goodStr, goodFormula, goodFormula));

            Should.Throw<ArgumentNullException>(() =>
                new FormulizedMeasurmentUnit(id, baseMeasurementUnitId, string.Empty, goodStr, goodFormula, goodFormula));

            Should.Throw<ArgumentNullException>(() =>
                new FormulizedMeasurmentUnit(id, baseMeasurementUnitId, goodStr, null!, goodFormula, goodFormula));

            Should.Throw<ArgumentNullException>(() =>
                new FormulizedMeasurmentUnit(id, baseMeasurementUnitId, goodStr, string.Empty, goodFormula, goodFormula));

            Should.Throw<ArgumentNullException>(() =>
                new FormulizedMeasurmentUnit(id, baseMeasurementUnitId, goodStr, goodStr, null!, goodFormula));

            Should.Throw<ArgumentNullException>(() =>
                new FormulizedMeasurmentUnit(id, baseMeasurementUnitId, goodStr, goodStr, goodFormula, null!));
        }

        [Fact]
        public void ToBase_FromBase_ShouldReturnExpectedValue()
        {
            // Given
            decimal givenA = 7.6M;

            FormulizedMeasurmentUnit measurementUnit = CreateFormulizedMeasurmentUnit(
                fromBaseFormula: "(a / 8.1M) + 1",
                toBaseFormula: "(a - 1 ) * 8.1M");

            // When
            decimal fromBaseValue = measurementUnit.FromBase(givenA);
            decimal toBaseValue = measurementUnit.ToBase(fromBaseValue);

            // Then
            fromBaseValue.ShouldBe(givenA / 8.1M + 1);
            toBaseValue.ShouldBe(givenA);
        }

        [Fact]
        public void GetBaseMeasurementUnitId_ShouldReturnBaseMeasurementUnitId()
        {
            FormulizedMeasurmentUnit measurementUnit = CreateFormulizedMeasurmentUnit();

            measurementUnit.GetBaseMeasurementUnitId().ShouldBe(measurementUnit.BaseMeasurementUnitId);
        }
    }
}
