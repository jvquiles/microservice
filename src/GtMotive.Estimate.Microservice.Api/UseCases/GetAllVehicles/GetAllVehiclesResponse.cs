using System;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetAllVehicles
{
    /// <summary>
    /// Response for the Get All Vehicles endpoint.
    /// </summary>
    public sealed class GetAllVehiclesResponse
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
