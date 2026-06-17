using System;
using FluentAssertions;
using GtMotive.Estimate.Microservice.Domain;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.Domain.ValueObjects
{
    /// <summary>
    /// Tests for the <see cref="LicensePlate"/> value object.
    /// </summary>
    public sealed class LicensePlateTests
    {
        /// <summary>
        /// LicensePlate constructed with an empty string should throw DomainException.
        /// </summary>
        [Fact]
        public void ConstructorWithEmptyValueShouldThrowDomainException()
        {
            Action act = () => _ = new LicensePlate(string.Empty);
            act.Should().Throw<DomainException>();
        }

        /// <summary>
        /// LicensePlate constructed with whitespace should throw DomainException.
        /// </summary>
        [Fact]
        public void ConstructorWithWhitespaceValueShouldThrowDomainException()
        {
            Action act = () => _ = new LicensePlate("   ");
            act.Should().Throw<DomainException>();
        }

        /// <summary>
        /// LicensePlate constructed with a valid string should not throw.
        /// </summary>
        [Fact]
        public void ConstructorWithValidValueShouldNotThrow()
        {
            var plate = new LicensePlate("1234ABC");
            plate.ToString().Should().Be("1234ABC");
        }
    }
}
