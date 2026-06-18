using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetAllVehicles
{
    /// <summary>
    /// Request to get all vehicles.
    /// </summary>
    public sealed class GetAllVehiclesRequest
        : IRequest<IWebApiPresenter>
    {
    }
}
