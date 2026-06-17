using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetVehicle;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetVehicle
{
    /// <summary>
    /// MediatR handler for <see cref="GetVehicleRequest"/>.
    /// </summary>
    public sealed class GetVehicleRequestHandler(
        IVehicleRepository vehicleRepository,
        GetVehiclePresenter presenter)
        : IRequestHandler<GetVehicleRequest, IWebApiPresenter>
    {
        public async Task<IWebApiPresenter> Handle(GetVehicleRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            var input = new GetVehicleInput
            {
                VehicleId = new VehicleId(request.VehicleId)
            };
            var useCase = new GetVehicleUseCase(vehicleRepository, presenter);
            await useCase.Execute(input);
            return presenter;
        }
    }
}
