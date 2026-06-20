using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.FinishRental
{
    /// <summary>
    /// Use case for finishing a vehicle rental.
    /// </summary>
    public sealed class FinishRentalUseCase(
        IVehicleRepository vehicleRepository,
        IFinishRentalOutputPort outputPort)
        : IUseCase<FinishRentalInput>
    {
        /// <inheritdoc/>
        public async Task Execute(FinishRentalInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var vehicle = await vehicleRepository.GetBy(input.VehicleId);
            if (vehicle is null)
            {
                outputPort.NotFoundHandle($"Vehicle {input.VehicleId} not found.");
                return;
            }

            vehicle.FinishRental(input.RentalId);
            await vehicleRepository.Update(vehicle);

            var output = new FinishRentalOutput
            {
                VehicleId = vehicle.Id,
                RentalId = input.RentalId
            };

            outputPort.StandardHandle(output);
        }
    }
}
