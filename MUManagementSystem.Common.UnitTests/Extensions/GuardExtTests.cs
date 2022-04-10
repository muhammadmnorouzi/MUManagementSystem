using MUManagementSystem.Common.Extensions;
using Shouldly;
using System;
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

        #region ThrowIfNegative Tests
        [Fact]
        public void ThrowIfNegative_ShouldThrowArgumentExceptionIfTheGivenValueIsNegative()
        {
            Should.Throw<ArgumentException>(() => (-0.01M).ThrowIfNegative());
            Should.Throw<ArgumentException>(() => (-0.1M).ThrowIfNegative());
            Should.Throw<ArgumentException>(() => (-1M).ThrowIfNegative());
            Should.Throw<ArgumentException>(() => (-10M).ThrowIfNegative());
        }

        [Fact]
        public void ThrowIfNegative_ShouldReturnSameValueIfTheGivenValueIsNotNegative()
        {
            // Given
            decimal value1 = 0M;
            decimal value2 = 1M;
            decimal value3 = 2M;
            decimal value4 = 3M;
            decimal value5 = 4M;

            value1.ThrowIfNegative().ShouldBe(value1);
            value2.ThrowIfNegative().ShouldBe(value2);
            value3.ThrowIfNegative().ShouldBe(value3);
            value4.ThrowIfNegative().ShouldBe(value4);
            value5.ThrowIfNegative().ShouldBe(value5);
        }
        #endregion
    }
}
