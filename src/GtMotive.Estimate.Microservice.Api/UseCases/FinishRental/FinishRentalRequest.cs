using System;
using System.Text.Json.Serialization;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.FinishRental
{
    /// <summary>
    /// Request to finish a vehicle rental.
    /// </summary>
    public sealed class FinishRentalRequest
        : IRequest<IWebApiPresenter>
    {
        /// <summary>
        /// Gets or sets the vehicle identifier (from route).
        /// </summary>
        [JsonRequired]
        public Guid VehicleId { get; set; }

        /// <summary>
        /// Gets or sets the rental identifier (from route).
        /// </summary>
        [JsonRequired]
        public Guid RentalId { get; set; }
    }
}
