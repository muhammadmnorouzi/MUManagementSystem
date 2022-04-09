using MUManagementSystem.Domain.Models;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MUManagementSystem.Domain.UnitTests.Models
{
    public class FormulizedMeasurmentUnitTests
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
    }
}
