using System;
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
        public async Task DeleteAll()
        {
            await _vehicles.DeleteManyAsync(Builders<VehicleEntity>.Filter.Empty);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<IVehicle>> GetAll(bool? availableForRent = null)
        {
            var currentDate = DateTime.UtcNow;
            var limitYear = currentDate.Year - VehicleEntity.MaxVehicleAge;
            var notTooOldFilter = Builders<VehicleEntity>.Filter.Gte(v => v.Year, limitYear);

            FilterDefinition<VehicleEntity> filter;
            if (availableForRent.HasValue)
            {
                var activeRentalFilter = Builders<VehicleEntity>.Filter.ElemMatch(
                    v => v.RentalsList,
                    Builders<RentalItem>.Filter.And(
                        Builders<RentalItem>.Filter.Lte(r => r.StartDate, currentDate),
                        Builders<RentalItem>.Filter.Gte(r => r.EndDate, currentDate)));

                filter = availableForRent.Value
                    ? Builders<VehicleEntity>.Filter.And(notTooOldFilter, Builders<VehicleEntity>.Filter.Not(activeRentalFilter))
                    : Builders<VehicleEntity>.Filter.And(notTooOldFilter, activeRentalFilter);
            }
            else
            {
                filter = notTooOldFilter;
            }

            return await _vehicles.Find(filter).ToListAsync();
        }

        /// <inheritdoc/>
        public async Task Update(IVehicle vehicle)
        {
            var entity = (VehicleEntity)vehicle;
            await _vehicles.ReplaceOneAsync(v => v.Id == entity.Id, entity);
        }

        /// <inheritdoc/>
        public async Task<bool> UserHasActiveRental(string email, DateTime startDate, DateTime endDate)
        {
            var filter = Builders<VehicleEntity>.Filter.ElemMatch(
                v => v.RentalsList,
                Builders<RentalItem>.Filter.And(
                    Builders<RentalItem>.Filter.Eq(r => r.UserEmail, email),
                    Builders<RentalItem>.Filter.Lt(r => r.StartDate, endDate),
                    Builders<RentalItem>.Filter.Gt(r => r.EndDate, startDate)));

            var exists = await _vehicles.Find(filter).AnyAsync();
            return exists;
        }
    }
}
