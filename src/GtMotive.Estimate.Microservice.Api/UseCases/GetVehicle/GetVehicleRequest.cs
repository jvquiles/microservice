using System;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetVehicle
{
    /// <summary>
    /// Request to get a vehicle by id.
    /// </summary>
    public sealed class GetVehicleRequest
        : IRequest<IWebApiPresenter>
    {
        /// <summary>
        /// Gets or sets the vehicle identifier.
        /// </summary>
        public Guid VehicleId { get; set; }
    }
}
