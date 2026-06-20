using System.Diagnostics.CodeAnalysis;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Serialization;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb
{
    /// <summary>
    /// Provides the shared MongoDB client and ensures indexes are created.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class MongoService
    {
        private static bool _created;

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoService"/> class.
        /// </summary>
        /// <param name="options">The MongoDB settings.</param>
        public MongoService(IOptions<MongoDbSettings> options)
        {
            MongoClient = new MongoClient(options.Value.ConnectionString);
            BsonClassMaps.Register();
            EnsureIndexes(MongoClient, options.Value.MongoDbDatabaseName);
        }

        /// <summary>
        /// Gets the MongoDB client.
        /// </summary>
        public MongoClient MongoClient { get; }

        private static void EnsureIndexes(MongoClient mongoClient, string databaseName)
        {
            if (_created)
            {
                return;
            }

            var database = mongoClient.GetDatabase(databaseName);
            var collection = database.GetCollection<VehicleEntity>("Vehicles");
            VehicleCollectionConfiguration.CreateIndexes(collection).GetAwaiter().GetResult();

            _created = true;
        }
    }
}
