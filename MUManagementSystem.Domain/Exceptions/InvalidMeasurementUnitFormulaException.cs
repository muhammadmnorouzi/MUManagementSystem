using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
