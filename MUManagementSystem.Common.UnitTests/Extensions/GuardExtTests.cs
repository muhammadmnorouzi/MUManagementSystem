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
        #region ThrowIfNullOrEmpty Tests
        [Fact]
        public void ThrowIfNullOrEmpty_ShouldThrowIfStringIsNullOrEmpty()
        {
            // Given
            string emptyString = string.Empty;
            string nullString = null!;

            // Then
             Should.Throw<ArgumentNullException>(() => emptyString.ThrowIfNullOrEmpty());
            Should.Throw<ArgumentNullException>(() => nullString.ThrowIfNullOrEmpty());
        }

        [Fact]
        public void ThrowIfNullOrEmpty_ShouldReturnSameValueIfStringIsNotNullOrEmpty()
        {
            // Given
            string givenString = "This is an example.";

            // When
            string returnedString = givenString.ThrowIfNullOrEmpty();

            // Then
            returnedString.ShouldBe(givenString);
        }
        #endregion

        #region ThrowIfNull<T> Tests
        [Fact]
        public void ThrowIfNull_ShouldThrowIfTheObjectIsNull()
        {
            // Given
            object nullObject = null!;

            // Then
            Should.Throw<ArgumentNullException>(() => nullObject.ThrowIfNull());
        }

        [Fact]
        public void ThrowIfNull_ShouldReturnTheSameObjectWhenItIsNotNull()
        {
            // Given
            object givenObject = new object();

            // When
            object returnedObject = givenObject.ThrowIfNull();

            // Then
            returnedObject.ShouldBe(givenObject);
        }
        #endregion
    }
}
