namespace MUManagementSystem.Domain.Exceptions
{
    public sealed class InvalidMeasurementUnitFormulaException : Exception
    {
        public InvalidMeasurementUnitFormulaException(string formula)
            : base($"Formula '{formula}' is invalid!")
        {

        }
    }
}
