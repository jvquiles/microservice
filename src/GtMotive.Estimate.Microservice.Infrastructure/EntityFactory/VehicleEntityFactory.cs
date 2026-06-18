using System;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.Infrastructure.EntityFactory
{
    /// <summary>
    /// Factory for creating Vehicle entities.
    /// </summary>
    public sealed class VehicleEntityFactory : IVehicleFactory
    {
        /// <inheritdoc/>
        public IVehicle NewVehicle(LicensePlate licensePlate, string brand, string model, int year, decimal dailyRate, bool isAvailable = true)
        {
            return new VehicleEntity(
                new VehicleId(Guid.CreateVersion7()),
                licensePlate,
                brand,
                model,
                year,
                dailyRate);
        }
    }
}
