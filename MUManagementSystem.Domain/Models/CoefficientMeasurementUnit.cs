﻿using MUManagementSystem.Common.Extensions;
using MUManagementSystem.Domain.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUManagementSystem.Domain.Models
{
    public sealed class CoefficientMeasurementUnit : BaseEntity, IMeasurementUnit
    {
        public Guid BaseMeasurementUnitId { get; init; }
        public string Name { get; init; } = default!;
        public string Symbol { get; init; } = default!;
        public decimal Ratio { get; init; }

        public CoefficientMeasurementUnit(
            Guid id,
            Guid baseMeasurementUnitId,
            string name,
            string symbol,
            decimal ratio)
        {
            Id = id;
            BaseMeasurementUnitId = baseMeasurementUnitId;
            Name = name.ThrowIfNullOrEmpty();
            Symbol = symbol.ThrowIfNullOrEmpty();
            Ratio = ratio;
        }
    }
}
