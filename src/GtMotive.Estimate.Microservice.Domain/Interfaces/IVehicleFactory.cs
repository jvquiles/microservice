namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Factory for creating Vehicle entities.
    /// </summary>
    public interface IVehicleFactory
    {
        /// <summary>
        /// Creates a new vehicle.
        /// </summary>
        /// <param name="licensePlate">The license plate.</param>
        /// <param name="brand">The brand.</param>
        /// <param name="model">The model.</param>
        /// <param name="year">The manufacturing year.</param>
        /// <param name="dailyRate">The daily rental rate.</param>
        /// <param name="isAvailable">Whether the vehicle is available for rent.</param>
        /// <returns>The new vehicle instance.</returns>
        IVehicle NewVehicle(LicensePlate licensePlate, string brand, string model, int year, decimal dailyRate, bool isAvailable = true);
    }
}
