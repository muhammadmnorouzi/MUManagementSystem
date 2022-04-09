using MUManagementSystem.Common.Extensions;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MUManagementSystem.Common.UnitTests.Extensions
{
    public class GuardExtTests
    {
        [Fact]
        public void ShouldThrowIfStringIsNullOrEmpty()
        {
            // Given
            string emptyString = string.Empty;
            string nullString = null!;

            // Then
            Assert.Throws<ArgumentNullException>(() => emptyString.ThrowIfNullOrEmpty());
            Assert.Throws<ArgumentNullException>(() => nullString.ThrowIfNullOrEmpty());
        }

        [Fact]
        public void ShouldReturnSameValueIfStringIsNotNullOrEmpty()
        {
            // Given
            string givenString = "This is an example.";

            // When
            string returnedString = givenString.ThrowIfNullOrEmpty();

            // Then
            returnedString.ShouldBe(givenString);
        }
    }
}
