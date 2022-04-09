using MUManagementSystem.Domain.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUManagementSystem.Domain.Extensions
{
    public static class IMeasurementUnitExt
    {
        public static decimal ConvertTo(this IMeasurementUnit from , decimal value , IMeasurementUnit to)
        {
            return to.FromBase(from.ToBase(value));
        }
    }
}
