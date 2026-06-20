using System;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateRental
{
    /// <summary>
    /// Use case for creating a vehicle rental.
    /// </summary>
    public sealed class CreateRentalUseCase(
        IVehicleRepository vehicleRepository,
        ICreateRentalOutputPort outputPort)
        : IUseCase<CreateRentalInput>
    {
        /// <inheritdoc/>
        public async Task Execute(CreateRentalInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var vehicle = await vehicleRepository.GetBy(input.VehicleId);
            if (vehicle is null)
            {
                outputPort.NotFoundHandle($"Vehicle {input.VehicleId} not found.");
                return;
            }

            if (vehicle.IsTooOld())
            {
                outputPort.BusinessRuleViolationHandle($"Vehicle {input.VehicleId} is too old and cannot be rented.");
                return;
            }

            await vehicle.Rent(
                input.UserEmail,
                input.StartDate,
                input.EndDate,
                vehicleRepository.UserHasActiveRental(input.UserEmail, input.StartDate, input.EndDate));
            await vehicleRepository.Update(vehicle);

            var rentalId = vehicle.Rentals.Last().RentalId;
            var output = new CreateRentalOutput
            {
                VehicleId = vehicle.Id,
                RentalId = rentalId,
                UserEmail = input.UserEmail,
                StartDate = input.StartDate,
                EndDate = input.EndDate
            };

            outputPort.StandardHandle(output);
        }
    }
}
