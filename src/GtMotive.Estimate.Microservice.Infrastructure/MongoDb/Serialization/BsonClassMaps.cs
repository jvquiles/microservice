using System.Diagnostics.CodeAnalysis;
using GtMotive.Estimate.Microservice.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Serialization
{
    /// <summary>
    /// Registers MongoDB Bson serializers and class maps for domain types.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class BsonClassMaps
    {
        private static bool _registered;

        /// <summary>
        /// Registers all required Bson serializers and class maps.
        /// Safe to call multiple times — only registers once.
        /// </summary>
        public static void Register()
        {
            if (_registered)
            {
                return;
            }

            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

            BsonSerializer.RegisterSerializer(new VehicleIdSerializer());
            BsonSerializer.RegisterSerializer(new LicensePlateSerializer());

            BsonClassMap.RegisterClassMap<VehicleEntity>(cm =>
            {
                cm.AutoMap();
                cm.MapMember(x => x.RentalsList);
            });

            BsonClassMap.RegisterClassMap<RentalItem>(cm =>
            {
                cm.MapMember(x => x.RentalId);
                cm.AutoMap();
            });

            _registered = true;
        }
    }
}
