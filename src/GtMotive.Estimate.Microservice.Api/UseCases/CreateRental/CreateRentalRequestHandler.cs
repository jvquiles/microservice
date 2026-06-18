using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateRental;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateRental
{
    /// <summary>
    /// MediatR handler for <see cref="CreateRentalRequest"/>.
    /// </summary>
    public sealed class CreateRentalRequestHandler(
        IVehicleRepository vehicleRepository,
        CreateRentalPresenter presenter)
        : IRequestHandler<CreateRentalRequest, IWebApiPresenter>
    {
        public async Task<IWebApiPresenter> Handle(CreateRentalRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            var input = new CreateRentalInput
            {
                VehicleId = new VehicleId(request.VehicleId),
                UserEmail = request.UserEmail,
                StartDate = request.StartDate,
                EndDate = request.EndDate
            };
            var useCase = new CreateRentalUseCase(vehicleRepository, presenter);
            await useCase.Execute(input);
            return presenter;
        }
    }
}
