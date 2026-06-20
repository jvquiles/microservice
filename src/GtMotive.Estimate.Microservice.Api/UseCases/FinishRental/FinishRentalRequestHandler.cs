using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.FinishRental;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.FinishRental
{
    /// <summary>
    /// MediatR handler for <see cref="FinishRentalRequest"/>.
    /// </summary>
    public sealed class FinishRentalRequestHandler(
        IVehicleRepository vehicleRepository,
        FinishRentalPresenter presenter)
        : IRequestHandler<FinishRentalRequest, IWebApiPresenter>
    {
        public async Task<IWebApiPresenter> Handle(FinishRentalRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            var input = new FinishRentalInput
            {
                VehicleId = new VehicleId(request.VehicleId),
                RentalId = request.RentalId
            };
            var useCase = new FinishRentalUseCase(vehicleRepository, presenter);
            await useCase.Execute(input);
            return presenter;
        }
    }
}
