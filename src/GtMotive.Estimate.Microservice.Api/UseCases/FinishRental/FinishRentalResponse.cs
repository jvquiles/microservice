using System;

namespace GtMotive.Estimate.Microservice.Api.UseCases.FinishRental
{
    /// <summary>
    /// Response for the Finish Rental endpoint.
    /// </summary>
    public sealed class FinishRentalResponse
    {
        /// <summary>
        /// Gets the vehicle identifier.
        /// </summary>
        public Guid VehicleId { get; init; }

        /// <summary>
        /// Gets the rental identifier.
        /// </summary>
        public Guid RentalId { get; init; }
    }
}
