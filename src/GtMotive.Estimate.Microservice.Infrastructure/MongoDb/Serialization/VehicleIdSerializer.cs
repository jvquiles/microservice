using System;
using GtMotive.Estimate.Microservice.Domain;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Serialization
{
    /// <summary>
    /// Bson serializer for <see cref="VehicleId"/> value object.
    /// </summary>
    public sealed class VehicleIdSerializer
        : SerializerBase<VehicleId>
    {
        /// <inheritdoc/>
        public override VehicleId Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            ArgumentNullException.ThrowIfNull(context);
            var guid = context.Reader.ReadGuid();
            return new VehicleId(guid);
        }

        /// <inheritdoc/>
        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, VehicleId value)
        {
            ArgumentNullException.ThrowIfNull(context);
            context.Writer.WriteGuid(value.ToGuid());
        }
    }
}
