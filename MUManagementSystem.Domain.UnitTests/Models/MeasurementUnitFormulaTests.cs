using MUManagementSystem.Domain.Exceptions;
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
    public class MeasurementUnitFormulaTests
    {
        [Fact]
        public void IsValidFormula_ShouldReturnTrueIfFormulaIsInCorrectFormat()
        {
            MeasurementUnitFormula.IsValidFormula("a + 3.0M / 7").ShouldBe(true);
            MeasurementUnitFormula.IsValidFormula("8").ShouldBe(true);
            MeasurementUnitFormula.IsValidFormula("8 + 8").ShouldBe(true);
            MeasurementUnitFormula.IsValidFormula("a").ShouldBe(true);
            MeasurementUnitFormula.IsValidFormula("(a)").ShouldBe(true);
            MeasurementUnitFormula.IsValidFormula("1 + a").ShouldBe(true);
            MeasurementUnitFormula.IsValidFormula("a * 2").ShouldBe(true);
            MeasurementUnitFormula.IsValidFormula("1 * a / 4").ShouldBe(true);
            MeasurementUnitFormula.IsValidFormula("1 * a / 4").ShouldBe(true);
            MeasurementUnitFormula.IsValidFormula("(a + 1) * (3 / 8 * a) - a").ShouldBe(true);
            MeasurementUnitFormula.IsValidFormula("((a + 2) / 3) * (3 - 7)").ShouldBe(true);
        }

        [Fact]
        public void IsValidFormula_ShouldThrowInvalidMeasurementUnitFormulaExceptionWhenTheGivenFormulaIsInvalid()
        {
            Should.Throw<InvalidMeasurementUnitFormulaException>(() => new MeasurementUnitFormula("a + 3.0 / 7"));
            Should.Throw<InvalidMeasurementUnitFormulaException>(() => new MeasurementUnitFormula("b"));
            Should.Throw<InvalidMeasurementUnitFormulaException>(() => new MeasurementUnitFormula("("));
            Should.Throw<InvalidMeasurementUnitFormulaException>(() => new MeasurementUnitFormula("())"));
            Should.Throw<InvalidMeasurementUnitFormulaException>(() => new MeasurementUnitFormula("(a 3)"));
            Should.Throw<InvalidMeasurementUnitFormulaException>(() => new MeasurementUnitFormula("(a + )"));
            Should.Throw<InvalidMeasurementUnitFormulaException>(() => new MeasurementUnitFormula("( + )"));
            Should.Throw<InvalidMeasurementUnitFormulaException>(() => new MeasurementUnitFormula("4 + * "));
        }
    }
}
