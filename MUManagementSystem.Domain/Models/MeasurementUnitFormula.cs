using MUManagementSystem.Domain.Exceptions;
using System.Linq.Expressions;

namespace MUManagementSystem.Domain.Models
{
    public sealed class MeasurementUnitFormula
    {
        public string Formula { get; }

        public MeasurementUnitFormula(string formula)
        {
            if (!IsValidFormula(formula))
            {
                throw new InvalidMeasurementUnitFormulaException(formula);
            }

            Formula = formula;
        }

        public static bool IsValidFormula(string formula)
        {
            throw new NotImplementedException();
        }
    }
}