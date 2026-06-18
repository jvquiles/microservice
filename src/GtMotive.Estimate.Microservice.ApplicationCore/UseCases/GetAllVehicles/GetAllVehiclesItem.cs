using GtMotive.Estimate.Microservice.Domain;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllVehicles
{
    /// <summary>
    /// A single vehicle item in the Get All Vehicles output.
    /// </summary>
    public sealed class GetAllVehiclesItem
    {
        /// <summary>
        /// Gets the vehicle identifier.
        /// </summary>
        public VehicleId VehicleId { get; init; }

        /// <summary>
        /// Gets the license plate.
        /// </summary>
        public LicensePlate LicensePlate { get; init; }

        /// <summary>
        /// Gets the brand.
        /// </summary>
        public string Brand { get; init; }

        /// <summary>
        /// Gets the model.
        /// </summary>
        public string Model { get; init; }

        /// <summary>
        /// Gets the manufacturing year.
        /// </summary>
        public int Year { get; init; }

        /// <summary>
        /// Gets the daily rental rate.
        /// </summary>
        public decimal DailyRate { get; init; }
    }
}
