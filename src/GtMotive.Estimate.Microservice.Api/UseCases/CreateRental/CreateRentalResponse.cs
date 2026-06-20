using System;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateRental
{
    /// <summary>
    /// Response for the Create Rental endpoint.
    /// </summary>
    public sealed class CreateRentalResponse
    {
        /// <summary>
        /// Gets the vehicle identifier.
        /// </summary>
        public Guid VehicleId { get; init; }

        /// <summary>
        /// Gets the rental identifier.
        /// </summary>
        public Guid RentalId { get; init; }

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
