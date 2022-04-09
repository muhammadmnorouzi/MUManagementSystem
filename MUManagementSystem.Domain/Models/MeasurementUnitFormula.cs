namespace MUManagementSystem.Domain.Models
{
    public sealed class MeasurementUnitFormula
    {
        public string Formula { get; }

        public MeasurementUnitFormula(string formula)
        {
            Formula = formula;
        }
    }
}