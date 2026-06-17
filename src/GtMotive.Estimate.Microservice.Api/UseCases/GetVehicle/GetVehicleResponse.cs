using System;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetVehicle
{
    /// <summary>
    /// Response for the Get Vehicle endpoint.
    /// </summary>
    public sealed class GetVehicleResponse
    {
        /// <summary>
        /// Gets the vehicle identifier.
        /// </summary>
        public Guid VehicleId { get; init; }

        /// <summary>
        /// Gets the license plate.
        /// </summary>
        public string LicensePlate { get; init; }

        /// <summary>
        /// Gets the brand.
        /// </summary>
        public string Brand { get; init; }

        /// <summary>
        /// Gets the model.
        /// </summary>
        public string Model { get; init; }

        /// <summary>
        /// Gets the manufacturing year.
        /// </summary>
        public int Year { get; init; }

        /// <summary>
        /// Gets the daily rental rate.
        /// </summary>
        public decimal DailyRate { get; init; }
    }
}
