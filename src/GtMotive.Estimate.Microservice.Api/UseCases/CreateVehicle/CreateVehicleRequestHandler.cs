using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle
{
    /// <summary>
    /// MediatR handler for <see cref="CreateVehicleRequest"/>.
    /// </summary>
    public sealed class CreateVehicleRequestHandler(
        IVehicleRepository vehicleRepository,
        IVehicleFactory vehicleFactory,
        IUnitOfWork unitOfWork,
        CreateVehiclePresenter presenter)
        : IRequestHandler<CreateVehicleRequest, IWebApiPresenter>
    {
        /// <inheritdoc/>
        public async Task<IWebApiPresenter> Handle(CreateVehicleRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            var input = new CreateVehicleInput
            {
                LicensePlate = new LicensePlate(request.LicensePlate),
                Brand = request.Brand,
                Model = request.Model,
                Year = request.Year,
                DailyRate = request.DailyRate
            };

            var useCase = new CreateVehicleUseCase(
                vehicleRepository,
                vehicleFactory,
                unitOfWork,
                presenter);

            await useCase.Execute(input);
            return presenter;
        }
    }
}
