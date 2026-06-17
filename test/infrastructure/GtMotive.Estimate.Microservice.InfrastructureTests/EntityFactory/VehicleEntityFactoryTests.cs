using System;
using FluentAssertions;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Infrastructure.EntityFactory;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.EntityFactory
{
    /// <summary>
    /// Tests for the <see cref="VehicleEntityFactory"/> class.
    /// </summary>
    public sealed class VehicleEntityFactoryTests
    {
        /// <summary>
        /// Factory should create a vehicle with correctly mapped properties.
        /// </summary>
        [Fact]
        public void NewVehicleWithValidPropertiesShouldCreateVehicle()
        {
            var factory = new VehicleEntityFactory();
            var licensePlate = new LicensePlate("1234ABC");
            var result = factory.NewVehicle(licensePlate, "Toyota", "Corolla", 2024, 50m);

            result.Should().NotBeNull();
            result.Id.Should().NotBe(default(VehicleId));
            result.Id.ToGuid().Should().NotBe(Guid.Empty);
            result.LicensePlate.ToString().Should().Be("1234ABC");
            result.Brand.Should().Be("Toyota");
            result.Model.Should().Be("Corolla");
            result.Year.Should().Be(2024);
            result.DailyRate.Should().Be(50m);
        }
    }
}
