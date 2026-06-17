using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetVehicle
{
    /// <summary>
    /// Use case for retrieving a vehicle by id.
    /// </summary>
    public sealed class GetVehicleUseCase(
        IVehicleRepository vehicleRepository,
        IGetVehicleOutputPort outputPort)
        : IUseCase<GetVehicleInput>
    {
        /// <inheritdoc/>
        public async Task Execute(GetVehicleInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var vehicle = await vehicleRepository.GetBy(input.VehicleId);

            if (vehicle is null)
            {
                outputPort.NotFoundHandle($"Vehicle {input.VehicleId} not found.");
                return;
            }

            var output = new GetVehicleOutput
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
