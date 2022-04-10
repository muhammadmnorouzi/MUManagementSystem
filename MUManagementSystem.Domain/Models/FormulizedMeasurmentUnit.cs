using MUManagementSystem.Common.Extensions;
using MUManagementSystem.Domain.Models.Abstractions;

namespace MUManagementSystem.Domain.Models
{
    public sealed class FormulizedMeasurmentUnit : BaseEntity, IMeasurementUnit
    {
        public Guid BaseMeasurementUnitId { get; init; }
        public string Name { get; init; } = default!;
        public string Symbol { get; init; } = default!;
        public MeasurementUnitFormula CalculateFromBase { get; init; } = default!;
        public MeasurementUnitFormula CalculateToBase { get; init; } = default!;

        public FormulizedMeasurmentUnit(
            Guid id,
            Guid baseMeasurementUnitId,
            string name,
            string symbol,
            MeasurementUnitFormula fromBase,
            MeasurementUnitFormula toBase)
        {
            Id = id;
            BaseMeasurementUnitId = baseMeasurementUnitId;
            Name = name.ThrowIfNullOrEmpty();
            Symbol = symbol.ThrowIfNullOrEmpty();
            CalculateFromBase = fromBase.ThrowIfNull();
            CalculateToBase = toBase.ThrowIfNull();
        }

        public decimal ToBase(decimal value)
        {
            return Math.Round(this.CalculateToBase.Calculator(value), 1);
        }

        public decimal FromBase(decimal value)
        {
            return this.CalculateFromBase.Calculator(value);
        }

        public Guid GetBaseMeasurementUnitId()
        {
            return this.BaseMeasurementUnitId;
        }
    }
}
