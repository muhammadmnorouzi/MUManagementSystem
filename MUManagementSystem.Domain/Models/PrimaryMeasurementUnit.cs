using MUManagementSystem.Common.Extensions;
using MUManagementSystem.Domain.Models.Abstractions;

namespace MUManagementSystem.Domain.Models
{
    public sealed class PrimaryMeasurementUnit : BaseEntity, IMeasurementUnit
    {
        public string Name { get; init; } = default!;
        public string Symbol { get; init; } = default!;
        public string Dimonsion { get; init; } = default!;

        public PrimaryMeasurementUnit(Guid id, string name, string symbol, string dimonsion)
        {
            Id = id;
            Name = name.ThrowIfNullOrEmpty();
            Symbol = symbol.ThrowIfNullOrEmpty();
            Dimonsion = dimonsion.ThrowIfNullOrEmpty();
        }

        public decimal ToBase(decimal value)
        {
            return value;
        }

        public decimal FromBase(decimal value)
        {
            return value;
        }

        public Guid GetBaseMeasurementUnitId()
        {
           return this.Id;
        }
    }
}
