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
    }
}
