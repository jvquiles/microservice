using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Vehicle aggregate root interface.
    /// </summary>
    public interface IVehicle
    {
        /// <summary>
        /// Gets the vehicle identifier.
        /// </summary>
        VehicleId Id { get; }

        /// <summary>
        /// Gets the license plate.
        /// </summary>
        LicensePlate LicensePlate { get; }

        /// <summary>
        /// Gets the brand.
        /// </summary>
        string Brand { get; }

        /// <summary>
        /// Gets the model.
        /// </summary>
        string Model { get; }

        /// <summary>
        /// Gets the manufacturing year.
        /// </summary>
        int Year { get; }

        /// <summary>
        /// Gets the daily rental rate.
        /// </summary>
        decimal DailyRate { get; }

        /// <summary>
        /// Gets the rental records for this vehicle.
        /// </summary>
        IReadOnlyCollection<RentalItem> Rentals { get; }

        /// <summary>
        /// Rents this vehicle to a user for the specified period.
        /// </summary>
        /// <param name="userEmail">The user email.</param>
        /// <param name="startDate">The rental start date.</param>
        /// <param name="endDate">The rental end date.</param>
        /// <param name="userHasActiveRental">A task indicating whether the user has an active rental.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task Rent(string userEmail, DateTime startDate, DateTime endDate, Task<bool> userHasActiveRental);

        /// <summary>
        /// Finishes an active rental by its identifier.
        /// </summary>
        /// <param name="rentalId">The rental identifier.</param>
        void FinishRental(Guid rentalId);

        /// <summary>
        /// Determines whether the vehicle is too old to be rented or listed.
        /// </summary>
        /// <returns>True if the vehicle is too old, false otherwise.</returns>
        bool IsTooOld();
    }
}
