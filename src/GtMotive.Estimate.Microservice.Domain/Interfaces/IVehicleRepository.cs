using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Repository for Vehicle aggregate roots.
    /// </summary>
    public interface IVehicleRepository
    {
        /// <summary>
        /// Adds a new vehicle.
        /// </summary>
        /// <param name="vehicle">The vehicle to add.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task Add(IVehicle vehicle);

        /// <summary>
        /// Gets a vehicle by its identifier.
        /// </summary>
        /// <param name="vehicleId">The vehicle identifier.</param>
        /// <returns>The vehicle.</returns>
        Task<IVehicle> GetBy(VehicleId vehicleId);

        /// <summary>
        /// Gets all vehicles, optionally filtered by availability.
        /// </summary>
        /// <param name="availableForRent">When set, filters by availability for rent.</param>
        /// <returns>A collection of matching vehicles.</returns>
        Task<IEnumerable<IVehicle>> GetAll(bool? availableForRent = null);

        /// <summary>
        /// Updates an existing vehicle.
        /// </summary>
        /// <param name="vehicle">The vehicle to update.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task Update(IVehicle vehicle);

        /// <summary>
        /// Checks if a user has an active rental across any vehicle.
        /// </summary>
        /// <param name="email">The user email.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns>True if an overlapping rental exists.</returns>
        Task<bool> UserHasActiveRental(string email, DateTime startDate, DateTime endDate);

        /// <summary>
        /// Deletes all vehicles.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task DeleteAll();
    }
}
