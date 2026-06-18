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
        /// Gets a value indicating whether the vehicle is available for rent.
        /// </summary>
        /// <returns>The availability value.</returns>
        public abstract bool IsAvailable();
    }
}
