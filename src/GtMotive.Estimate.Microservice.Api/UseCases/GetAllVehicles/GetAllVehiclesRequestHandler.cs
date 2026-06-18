using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllVehicles;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetAllVehicles
{
    /// <summary>
    /// MediatR handler for <see cref="GetAllVehiclesRequest"/>.
    /// </summary>
    public sealed class GetAllVehiclesRequestHandler(
        IVehicleRepository vehicleRepository,
        GetAllVehiclesPresenter presenter)
        : IRequestHandler<GetAllVehiclesRequest, IWebApiPresenter>
    {
        public async Task<IWebApiPresenter> Handle(GetAllVehiclesRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            var useCase = new GetAllVehiclesUseCase(vehicleRepository, presenter);
            await useCase.Execute(new GetAllVehiclesInput());
            return presenter;
        }
    }
}
