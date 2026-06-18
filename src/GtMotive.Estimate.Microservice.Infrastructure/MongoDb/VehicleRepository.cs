using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb
{
    /// <summary>
    /// MongoDB implementation of <see cref="IVehicleRepository"/>.
    /// </summary>
    public sealed class VehicleRepository(
        MongoService mongoService,
        IOptions<MongoDbSettings> options)
        : IVehicleRepository
    {
        private readonly IMongoCollection<VehicleEntity> _vehicles = mongoService.
            MongoClient.GetDatabase(options.Value.MongoDbDatabaseName)
            .GetCollection<VehicleEntity>("Vehicles");

        /// <inheritdoc/>
        public async Task Add(IVehicle vehicle)
        {
            await _vehicles.InsertOneAsync((VehicleEntity)vehicle);
        }

        /// <inheritdoc/>
        public async Task<IVehicle> GetBy(VehicleId vehicleId)
        {
            var filter = Builders<VehicleEntity>.Filter.Eq(v => v.Id, vehicleId);
            var vehicle = await _vehicles.Find(filter).SingleOrDefaultAsync();
            return vehicle;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<IVehicle>> GetAll()
        {
            var vehicles = await _vehicles.Find(_ => true).ToListAsync();
            return vehicles;
        }
    }
}
