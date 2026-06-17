using System;
using FluentAssertions;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Serialization
{
    /// <summary>
    /// Tests for VehicleEntity BSON serialization and deserialization.
    /// </summary>
    public sealed class VehicleEntitySerializationTests
    {
        /// <summary>
        /// VehicleEntity should round-trip through Bson serialization and deserialization
        /// preserving all property values.
        /// </summary>
        [Fact]
        public void DeserializeShouldPreserveAllProperties()
        {
            BsonClassMaps.Register();

            var vehicleId = new VehicleId(Guid.NewGuid());
            var licensePlate = new LicensePlate("1234ABC");
            var original = new VehicleEntity(vehicleId, licensePlate, "Toyota", "Corolla", 2024, 50m);

            var bson = original.ToBson();
            var deserialized = BsonSerializer.Deserialize<VehicleEntity>(bson);

            deserialized.Should().NotBeNull();
            deserialized.Id.Should().Be(original.Id);
            deserialized.LicensePlate.ToString().Should().Be("1234ABC");
            deserialized.Brand.Should().Be("Toyota");
            deserialized.Model.Should().Be("Corolla");
            deserialized.Year.Should().Be(2024);
            deserialized.DailyRate.Should().Be(50m);
        }
    }
}
