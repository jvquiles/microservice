using System;
using FluentAssertions;
using GtMotive.Estimate.Microservice.Domain;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.Domain.ValueObjects
{
    /// <summary>
    /// Tests for the <see cref="VehicleId"/> value object.
    /// </summary>
    public sealed class VehicleIdTests
    {
        /// <summary>
        /// VehicleId constructed with an empty GUID should throw DomainException.
        /// </summary>
        [Fact]
        public void ConstructorWithEmptyGuidShouldThrowDomainException()
        {
            Action act = () => _ = new VehicleId(Guid.Empty);
            act.Should().Throw<DomainException>();
        }

        /// <summary>
        /// VehicleId constructed with a valid GUID should not throw.
        /// </summary>
        [Fact]
        public void ConstructorWithValidGuidShouldNotThrow()
        {
            var id = new VehicleId(Guid.NewGuid());
            id.ToGuid().Should().NotBe(Guid.Empty);
        }

        /// <summary>
        /// Two VehicleId instances with the same value should be equal.
        /// </summary>
        [Fact]
        public void EqualsTwoIdenticalIdsShouldBeEqual()
        {
            var guid = Guid.NewGuid();
            var id1 = new VehicleId(guid);
            var id2 = new VehicleId(guid);

            id1.Should().Be(id2);
            (id1 == id2).Should().BeTrue();
        }
    }
}
