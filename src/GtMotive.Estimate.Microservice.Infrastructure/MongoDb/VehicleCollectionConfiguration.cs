using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb
{
    /// <summary>
    /// Configures MongoDB indexes for the Vehicles collection.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class VehicleCollectionConfiguration
    {
        /// <summary>
        /// Creates all required indexes on the Vehicles collection.
        /// </summary>
        /// <param name="collection">The Vehicles collection.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task CreateIndexes(IMongoCollection<VehicleEntity> collection)
        {
            ArgumentNullException.ThrowIfNull(collection);
            await collection.Indexes.CreateManyAsync(
            [
                new CreateIndexModel<VehicleEntity>(
                    Builders<VehicleEntity>.IndexKeys
                        .Ascending(v => v.Year)),

                new CreateIndexModel<VehicleEntity>(
                    Builders<VehicleEntity>.IndexKeys
                        .Ascending($"{nameof(VehicleEntity.RentalsList)}.{nameof(RentalItem.StartDate)}")
                        .Ascending($"{nameof(VehicleEntity.RentalsList)}.{nameof(RentalItem.EndDate)}")),

                new CreateIndexModel<VehicleEntity>(
                    Builders<VehicleEntity>.IndexKeys
                        .Ascending($"{nameof(VehicleEntity.RentalsList)}.{nameof(RentalItem.UserEmail)}")
                        .Ascending($"{nameof(VehicleEntity.RentalsList)}.{nameof(RentalItem.StartDate)}")
                        .Ascending($"{nameof(VehicleEntity.RentalsList)}.{nameof(RentalItem.EndDate)}")),
            ]);
        }
    }
}
