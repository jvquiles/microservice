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
        /// <param name="availableForRent">When set, filters by <see cref="IVehicle.IsAvailable"/>.</param>
        /// <returns>A collection of matching vehicles.</returns>
        Task<IEnumerable<IVehicle>> GetAll(bool? availableForRent = null);
    }
}
