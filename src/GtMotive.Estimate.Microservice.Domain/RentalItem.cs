using System;

namespace GtMotive.Estimate.Microservice.Domain
{
    /// <summary>
    /// Value object representing a rental record embedded in a Vehicle aggregate.
    /// </summary>
    public sealed class RentalItem
    {
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
