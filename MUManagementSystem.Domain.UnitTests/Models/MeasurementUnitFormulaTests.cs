using MUManagementSystem.Domain.Exceptions;
using MUManagementSystem.Domain.Models;
using Shouldly;
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

        [Fact]
        public void Calculator_ShouldCalculateCorrectlyWhenObjectIsInstantiated()
        {
            // Given 
            MeasurementUnitFormula formula1 = new MeasurementUnitFormula("a + 2");
            MeasurementUnitFormula formula2 = new MeasurementUnitFormula("a * 2");
            int a = 5;

            // When
            decimal result1 = formula1.Calculator(a);
            decimal result2 = formula2.Calculator(a);

            // Then
            result1.ShouldBe(7);
            result2.ShouldBe(10);
        }

        [Fact]
        public void GetHashCode_ShouldReturnSameHashCodeValueAsFormulaInjected()
        {
            // Given 
            string formula1 = "a + 1",
                formula2 = "a * 1" ,
                formula3 = "(a) * 1" ,
                formula4 = "(a / 1)" ,
                formula5 = "a - (a * 3) * 7";

            new MeasurementUnitFormula(formula1).GetHashCode().ShouldBe(formula1.GetHashCode());
            new MeasurementUnitFormula(formula2).GetHashCode().ShouldBe(formula2.GetHashCode());
            new MeasurementUnitFormula(formula3).GetHashCode().ShouldBe(formula3.GetHashCode());
            new MeasurementUnitFormula(formula4).GetHashCode().ShouldBe(formula4.GetHashCode());
            new MeasurementUnitFormula(formula5).GetHashCode().ShouldBe(formula5.GetHashCode());
        }
    }
}
