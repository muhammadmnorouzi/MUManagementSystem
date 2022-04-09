using MUManagementSystem.Domain.Models.Abstractions;

namespace MUManagementSystem.Domain.Extensions
{
    public static class IMeasurementUnitExt
    {
        public static decimal ConvertTo(this IMeasurementUnit from, decimal value, IMeasurementUnit to)
        {
            return to.FromBase(from.ToBase(value));
        }
    }
}
