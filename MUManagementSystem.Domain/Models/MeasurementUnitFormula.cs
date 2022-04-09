using MUManagementSystem.Domain.Exceptions;
using System.Linq.Expressions;
using Z.Expressions;

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
            if(string.IsNullOrEmpty(formula))
            {
                return false;
            }

            try
            {
                var result = Eval.Compile<Func<decimal , decimal>>(formula , "a");

                return true;
            }
            catch
            {
            }

            return false;
        }
    }
}