using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.Domain
{
    /// <summary>
    /// Abstract base class for the Vehicle aggregate root.
    /// </summary>
    public abstract class Vehicle : IVehicle
    {
        /// <summary>
        /// Gets or sets the vehicle identifier.
        /// </summary>
        public VehicleId Id { get; protected set; }

        /// <summary>
        /// Gets or sets the license plate.
        /// </summary>
        public LicensePlate LicensePlate { get; protected set; }

        /// <summary>
        /// Gets or sets the brand.
        /// </summary>
        public string Brand { get; protected set; }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        public string Model { get; protected set; }

        /// <summary>
        /// Gets or sets the manufacturing year.
        /// </summary>
        public int Year { get; protected set; }

        /// <summary>
        /// Gets or sets the daily rental rate.
        /// </summary>
        public decimal DailyRate { get; protected set; }

        /// <summary>
        /// Gets the rental records for this vehicle.
        /// </summary>
        public abstract IReadOnlyCollection<RentalItem> Rentals { get; }

        /// <summary>
        /// Rents this vehicle to a user for the specified period.
        /// </summary>
        /// <param name="userEmail">The user email.</param>
        /// <param name="startDate">The rental start date.</param>
        /// <param name="endDate">The rental end date.</param>
        /// <param name="userHasActiveRental">A task indicating whether the user has an active rental.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public abstract Task Rent(string userEmail, DateTime startDate, DateTime endDate, Task<bool> userHasActiveRental);

        /// <summary>
        /// Finishes an active rental by its identifier.
        /// </summary>
        /// <param name="rentalId">The rental identifier.</param>
        public abstract void FinishRental(Guid rentalId);
    }
}
