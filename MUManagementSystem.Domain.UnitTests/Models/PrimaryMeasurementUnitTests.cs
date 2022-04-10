using MUManagementSystem.Domain.Models;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MUManagementSystem.Domain.UnitTests.Models
{
    public class PrimaryMeasurementUnitTests:TestsBase
    {
        [Fact]
        public void GetBaseMeasurementUnitId_ShouldReturnBaseMeasurementUnitId()
        {
            PrimaryMeasurementUnit measurementUnit = CreatePrimaryMeasurementUnit();

            measurementUnit.GetBaseMeasurementUnitId().ShouldBe(measurementUnit.Id);
        }
    }
}
