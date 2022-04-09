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
            IEnumerable<string> validFormulas = new string[]
            {
               "a",
               "(a)",
               "1 + a" ,
               "a * 2" ,
               "1 * a / 4" ,
               "(a + 1) * (3 / 8 * a) - a",
               "((a + 2) / 3) * (3 - 7)"
            };

            foreach (string formula in validFormulas)
            {
                MeasurementUnitFormula.IsValidFormula(formula).ShouldBe(true);
            }
        }
    }
}
