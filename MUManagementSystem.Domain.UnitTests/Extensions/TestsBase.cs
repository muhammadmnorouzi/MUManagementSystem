using MUManagementSystem.Domain.Models;
using System;

namespace MUManagementSystem.Domain.UnitTests.Extensions
{
    public abstract class TestsBase
    {
        public CoefficientMeasurementUnit CreateCoefficientMeasurementUnit(Guid? baseMeasurementUnitId = null)
        {
            if (!baseMeasurementUnitId.HasValue)
            {
                baseMeasurementUnitId = Guid.NewGuid();
            }

            return new CoefficientMeasurementUnit(
               Guid.NewGuid(),
               baseMeasurementUnitId.Value,
               "arbitrary",
               "arb",
               2.0M);
        }

        public FormulizedMeasurmentUnit CreateFormulizedMeasurmentUnit(Guid? baseMeasurementUnitId = null)
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

        public PrimaryMeasurementUnit CreatePrimaryMeasurementUnit(Guid? baseMeasurementUnitId = null)
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