using System;
using GtMotive.Estimate.Microservice.Domain;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateRental
{
    /// <summary>
    /// Input message for the Create Rental use case.
    /// </summary>
    public sealed class CreateRentalInput
        : IUseCaseInput
    {
        /// <summary>
        /// Gets the vehicle identifier.
        /// </summary>
        public VehicleId VehicleId { get; init; }

        /// <summary>
        /// Gets the user email.
        /// </summary>
        public string UserEmail { get; init; }

        /// <summary>
        /// Gets the rental start date.
        /// </summary>
        public DateTime StartDate { get; init; }

        /// <summary>
        /// Gets the rental end date.
        /// </summary>
        public DateTime EndDate { get; init; }
    }
}
