using MUManagementSystem.Domain.Exceptions;
using MUManagementSystem.Domain.Models;
using MUManagementSystem.Domain.Models.Abstractions;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MUManagementSystem.Domain.UnitTests.Models
{
    public class CoefficientMeasurementUnitTests
    {
        [Fact]
        public void Ctor_ShouldThrowExceptionsOnBadArguments()
        {
            Should.Throw<ArgumentNullException>(() =>
                new CoefficientMeasurementUnit(Guid.NewGuid(), Guid.NewGuid(), null!, "some thing", 1));

            Should.Throw<ArgumentNullException>(() =>
                new CoefficientMeasurementUnit(Guid.NewGuid(), Guid.NewGuid(), string.Empty, "some thing", 1));

            Should.Throw<ArgumentNullException>(() =>
                new CoefficientMeasurementUnit(Guid.NewGuid(), Guid.NewGuid(), "some thing", null!, 1));

            Should.Throw<ArgumentNullException>(() =>
                new CoefficientMeasurementUnit(Guid.NewGuid(), Guid.NewGuid(), "some thing", string.Empty, 1));

            Should.Throw<InvalidRationException>(() =>
                new CoefficientMeasurementUnit(Guid.NewGuid(), Guid.NewGuid(), "some thing", "some thing", 0));

            Should.Throw<InvalidRationException>(() =>
               new CoefficientMeasurementUnit(Guid.NewGuid(), Guid.NewGuid(), "some thing", "some thing", -1));

            Should.Throw<InvalidRationException>(() =>
               new CoefficientMeasurementUnit(Guid.NewGuid(), Guid.NewGuid(), "some thing", "some thing", -10));
        }

        [Fact]
        public void ToBase_FromBase_ShouldReturnExpectedValue()
        {
            // Given
            decimal givenRatio = 1.7M;
            decimal givenValue = 10;

            IMeasurementUnit measurementUnit = new CoefficientMeasurementUnit(
                   id: Guid.NewGuid(),
                   baseMeasurementUnitId: Guid.NewGuid(),
                   name: "arbitrary",
                   symbol: "arb",
                   ratio: givenRatio);

            // When
            decimal fromBaseValue = measurementUnit.FromBase(givenValue);
            decimal toBaseValue = measurementUnit.ToBase(fromBaseValue);

            // Then
            fromBaseValue.ShouldBe(givenValue * givenRatio);
            toBaseValue.ShouldBe(givenValue);
        }
    }
}
