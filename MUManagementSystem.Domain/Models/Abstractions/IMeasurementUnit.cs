using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUManagementSystem.Domain.Models.Abstractions
{
    // Marker interface
    public interface IMeasurementUnit
    {
        string Name { get; init; }
        string Symbol { get; init; }

        decimal ToBase(decimal value);
        decimal FromBase(decimal value);
    }
}
