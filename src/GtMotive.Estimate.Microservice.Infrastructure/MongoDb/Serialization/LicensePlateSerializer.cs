using System;
using GtMotive.Estimate.Microservice.Domain;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Serialization
{
    /// <summary>
    /// Bson serializer for <see cref="LicensePlate"/> value object.
    /// </summary>
    public sealed class LicensePlateSerializer : SerializerBase<LicensePlate>
    {
        /// <inheritdoc/>
        public override LicensePlate Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            ArgumentNullException.ThrowIfNull(context);
            var text = context.Reader.ReadString();
            return new LicensePlate(text);
        }

        /// <inheritdoc/>
        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, LicensePlate value)
        {
            ArgumentNullException.ThrowIfNull(context);
            context.Writer.WriteString(value.ToString());
        }
    }
}
