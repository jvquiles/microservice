using System;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllVehicles
{
    /// <summary>
    /// Use case for retrieving all vehicles.
    /// </summary>
    public sealed class GetAllVehiclesUseCase(
        IVehicleRepository vehicleRepository,
        IGetAllVehiclesOutputPort outputPort)
        : IUseCase<GetAllVehiclesInput>
    {
        /// <inheritdoc/>
        public async Task Execute(GetAllVehiclesInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var vehicles = await vehicleRepository.GetAll(input.AvailableForRent);

            var items = vehicles
                .Select(vehicle => new GetAllVehiclesItem
                {
                    VehicleId = vehicle.Id,
                    LicensePlate = vehicle.LicensePlate,
                    Brand = vehicle.Brand,
                    Model = vehicle.Model,
                    Year = vehicle.Year,
                    DailyRate = vehicle.DailyRate
                })
                .ToList();

            var output = new GetAllVehiclesOutput
            {
                Vehicles = items
            };
            outputPort.StandardHandle(output);
        }
    }
}
