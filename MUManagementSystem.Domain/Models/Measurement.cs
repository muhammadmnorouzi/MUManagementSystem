using MUManagementSystem.Common.Extensions;
using MUManagementSystem.Domain.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUManagementSystem.Domain.Models
{
    public sealed class Measurement
    {
        public Measurement(decimal value, IMeasurementUnit measurementUnit)
        {
            Value = value.ThrowIfNegative();
            MeasurementUnit = measurementUnit.ThrowIfNull();
        }

        public decimal Value { get; init; }
        public IMeasurementUnit MeasurementUnit  { get; init; }
    }
}
