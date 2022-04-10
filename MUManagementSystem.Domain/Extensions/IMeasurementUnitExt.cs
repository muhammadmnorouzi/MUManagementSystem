using MUManagementSystem.Domain.Models.Abstractions;

namespace MUManagementSystem.Domain.Extensions
{
    public static class IMeasurementUnitExt
    {
        public static decimal ConvertTo(this IMeasurementUnit from, decimal value, IMeasurementUnit to)
        {
            if (from.GetBaseMeasurementUnitId() != to.GetBaseMeasurementUnitId())
            {
                throw new InvalidOperationException(
                    "Converting measurement units is not allowed for those with different BaseMeasurementUnitIds!");
            }

            return to.FromBase(from.ToBase(value));
        }
    }
}
