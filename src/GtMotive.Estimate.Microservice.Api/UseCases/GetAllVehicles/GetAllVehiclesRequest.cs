using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetAllVehicles
{
    /// <summary>
    /// Request to get all vehicles.
    /// </summary>
    public sealed class GetAllVehiclesRequest
        : IRequest<IWebApiPresenter>
    {
        /// <summary>
        /// Gets or sets an optional filter by availability.
        /// </summary>
        public bool? AvailableForRent { get; set; }
    }
}
