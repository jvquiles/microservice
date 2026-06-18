using System;
using System.Text.Json.Serialization;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateRental
{
    /// <summary>
    /// Request to create a vehicle rental.
    /// </summary>
    public sealed class CreateRentalRequest
        : IRequest<IWebApiPresenter>
    {
        /// <summary>
        /// Gets or sets the vehicle identifier (from route).
        /// </summary>
        [JsonRequired]
        public Guid VehicleId { get; set; }

        /// <summary>
        /// Gets or sets the user email.
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// Gets or sets the rental start date.
        /// </summary>
        [JsonRequired]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the rental end date.
        /// </summary>
        [JsonRequired]
        public DateTime EndDate { get; set; }
    }
}
