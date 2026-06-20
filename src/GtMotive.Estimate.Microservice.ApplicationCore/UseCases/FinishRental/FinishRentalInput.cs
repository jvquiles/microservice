using System;
using GtMotive.Estimate.Microservice.Domain;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.FinishRental
{
    /// <summary>
    /// Input message for the Finish Rental use case.
    /// </summary>
    public sealed class FinishRentalInput
        : IUseCaseInput
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
