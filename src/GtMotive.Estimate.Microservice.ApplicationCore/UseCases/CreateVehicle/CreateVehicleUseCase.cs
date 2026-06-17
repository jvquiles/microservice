using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// Use case for creating a new vehicle.
    /// </summary>
    public sealed class CreateVehicleUseCase(
        IVehicleRepository vehicleRepository,
        IVehicleFactory vehicleFactory,
        IUnitOfWork unitOfWork,
        ICreateVehicleOutputPort outputPort)
        : IUseCase<CreateVehicleInput>
    {
        /// <inheritdoc/>
        public async Task Execute(CreateVehicleInput input)
        {
            ArgumentNullException.ThrowIfNull(input);
            var vehicle = vehicleFactory.NewVehicle(
                input.LicensePlate,
                input.Brand,
                input.Model,
                input.Year,
                input.DailyRate);

            await vehicleRepository.Add(vehicle);
            await unitOfWork.Save();

            var output = new CreateVehicleOutput
            {
                VehicleId = vehicle.Id,
                LicensePlate = vehicle.LicensePlate,
                Brand = vehicle.Brand,
                Model = vehicle.Model,
                Year = vehicle.Year,
                DailyRate = vehicle.DailyRate
            };

            outputPort.StandardHandle(output);
        }
    }
}
