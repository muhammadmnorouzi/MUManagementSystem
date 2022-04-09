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
    public class FormulizedMeasurmentUnitTests
    {
        [Fact]
        public void Ctor_ShouldThrowExceptionsOnBadArguments()
        {
            Guid id = Guid.NewGuid();
            Guid baseMeasurementUnitId = Guid.NewGuid();
            string goodStr = "some thing";

            //Should.Throw<ArgumentNullException>(() => new FormulizedMeasurmentUnit(id , baseMeasurementUnitId ,
            //    Guid.NewGuid() , 
            //     Guid.NewGuid() ,
            //    null!,
            //    "some thing",
            //    )
        }
    }
}
