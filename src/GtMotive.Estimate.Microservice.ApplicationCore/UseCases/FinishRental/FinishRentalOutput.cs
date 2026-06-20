using System;
using GtMotive.Estimate.Microservice.Domain;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.FinishRental
{
    /// <summary>
    /// Output message for the Finish Rental use case.
    /// </summary>
    public sealed class FinishRentalOutput
        : IUseCaseOutput
    {
        /// <summary>
        /// Gets the vehicle identifier.
        /// </summary>
        public VehicleId VehicleId { get; init; }

        /// <summary>
        /// Gets the rental identifier.
        /// </summary>
        public Guid RentalId { get; init; }
    }
}
