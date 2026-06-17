using System;

namespace GtMotive.Estimate.Microservice.Domain
{
    /// <summary>
    /// Value object representing a Vehicle identifier.
    /// </summary>
    public readonly struct VehicleId : IEquatable<VehicleId>
    {
        private readonly Guid _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleId"/> struct.
        /// </summary>
        /// <param name="value">The GUID value.</param>
        public VehicleId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new DomainException("VehicleId cannot be empty.");
            }

            _value = value;
        }

        /// <summary>
        /// Compares two VehicleId instances for equality.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>True if equal.</returns>
        public static bool operator ==(VehicleId left, VehicleId right) => left.Equals(right);

        /// <summary>
        /// Compares two VehicleId instances for inequality.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>True if not equal.</returns>
        public static bool operator !=(VehicleId left, VehicleId right) => !left.Equals(right);

        /// <summary>
        /// Converts the identifier to a GUID.
        /// </summary>
        /// <returns>The GUID representation.</returns>
        public Guid ToGuid() => _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is VehicleId other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(VehicleId other) => _value == other._value;

        /// <inheritdoc/>
        public override int GetHashCode() => _value.GetHashCode();
    }
}
