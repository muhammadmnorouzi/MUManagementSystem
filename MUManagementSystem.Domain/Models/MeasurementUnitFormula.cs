using MUManagementSystem.Domain.Exceptions;
using Z.Expressions;

namespace MUManagementSystem.Domain.Models
{
    public sealed class MeasurementUnitFormula
    {
        public string Formula { get; }

        private Func<decimal, decimal> _calculator = default!;
        public Func<decimal, decimal> Calculator
        {
            get
            {
                if (_calculator is null)
                {
                    _calculator = GetFunction(this.Formula);
                }

                return _calculator;
            }
        }

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
            if (string.IsNullOrEmpty(formula))
            {
                return false;
            }

            try
            {
                var result = GetFunction(formula);

                return true;
            }
            catch
            {
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Formula.GetHashCode();
        }

        private static Func<decimal, decimal> GetFunction(string formula)
        {
            return Eval.Compile<Func<decimal, decimal>>(formula, "a");
        }
    }
}