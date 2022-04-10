using MUManagementSystem.Domain.Models;
using System;

namespace MUManagementSystem.Domain.UnitTests
{
    public abstract class TestsBase
    {
        public CoefficientMeasurementUnit CreateCoefficientMeasurementUnit(
            Guid? baseMeasurementUnitId = null,
            decimal ratio = 1.0M)
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
               ratio);
        }

        public FormulizedMeasurmentUnit CreateFormulizedMeasurmentUnit(
            Guid? baseMeasurementUnitId = null,
            string fromBaseFormula = "a",
            string toBaseFormula = "a")
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
                new MeasurementUnitFormula(fromBaseFormula),
                new MeasurementUnitFormula(toBaseFormula));
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