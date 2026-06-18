namespace GtMotive.Estimate.Microservice.Domain
{
    /// <summary>
    /// Concrete implementation of the Vehicle aggregate root.
    /// </summary>
    public sealed class VehicleEntity : Vehicle
    {
        private readonly bool _isAvailable;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleEntity"/> class.
        /// </summary>
        /// <param name="id">The vehicle identifier.</param>
        /// <param name="licensePlate">The license plate.</param>
        /// <param name="brand">The brand.</param>
        /// <param name="model">The model.</param>
        /// <param name="year">The manufacturing year.</param>
        /// <param name="dailyRate">The daily rental rate.</param>
        public VehicleEntity(
            VehicleId id,
            LicensePlate licensePlate,
            string brand,
            string model,
            int year,
            decimal dailyRate)
        {
            Id = id;
            LicensePlate = licensePlate;
            Brand = brand;
            Model = model;
            Year = year;
            DailyRate = dailyRate;
            _isAvailable = true;
        }

        /// <inheritdoc/>
        public override bool IsAvailable()
        {
            return _isAvailable;
        }
    }
}
