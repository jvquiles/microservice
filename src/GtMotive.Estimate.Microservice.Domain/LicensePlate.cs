namespace GtMotive.Estimate.Microservice.Domain
{
    /// <summary>
    /// Value object representing a vehicle license plate.
    /// </summary>
    public readonly struct LicensePlate
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="LicensePlate"/> struct.
        /// </summary>
        /// <param name="value">The license plate text.</param>
        public LicensePlate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new DomainException("License plate cannot be empty.");
            }

            _value = value;
        }

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
