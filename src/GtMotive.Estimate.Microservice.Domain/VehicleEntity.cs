using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.Domain
{
    /// <summary>
    /// Concrete implementation of the Vehicle aggregate root.
    /// </summary>
    public sealed class VehicleEntity : Vehicle
    {
#pragma warning disable IDE0032 // Usar propiedad automática
#pragma warning disable SA1010 // Opening square brackets should be spaced correctly
        private Collection<RentalItem> _rentals = [];
#pragma warning restore SA1010 // Opening square brackets should be spaced correctly
#pragma warning restore IDE0032 // Usar propiedad automática

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

            if (IsTooOld())
            {
                throw new DomainException($"Vehicle year {year} is too old. Vehicles older than 5 years cannot be used.");
            }
        }

        /// <summary>
        /// Gets the maximum allowed vehicle age in years.
        /// </summary>
        /// <returns>The maximum allowed vehicle age in years.</returns>
        public static int MaxVehicleAge => 5;

        /// <inheritdoc/>
        public override IReadOnlyCollection<RentalItem> Rentals => _rentals;

        /// <summary>
        /// Gets or sets the internal rentals collection for MongoDB serialization.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be read-only
#pragma warning disable IDE0028 // Collection initialization can be simplified
#pragma warning disable SA1010 // Opening square brackets should be spaced correctly
        public Collection<RentalItem> RentalsList
        {
            get => _rentals;
            set => _rentals = value ?? [];
        }
#pragma warning restore SA1010 // Opening square brackets should be spaced correctly
#pragma warning restore IDE0028 // Collection initialization can be simplified
#pragma warning restore CA2227 // Collection properties should be read-only

        /// <inheritdoc/>
        public override async Task Rent(
            string userEmail,
            DateTime startDate,
            DateTime endDate,
            Task<bool> userHasActiveRental)
        {
            if (startDate >= endDate)
            {
                throw new DomainException("End date should be after start date.");
            }

            if (!IsAvailable(startDate, endDate))
            {
                throw new DomainException("Vehicle is not available for rent.");
            }

            var hasActiveRental = await userHasActiveRental;
            if (hasActiveRental)
            {
                throw new DomainException($"User {userEmail} already has an active rental for the requested period.");
            }

            _rentals.Add(new RentalItem
            {
                RentalId = Guid.CreateVersion7(),
                UserEmail = userEmail,
                StartDate = startDate,
                EndDate = endDate
            });
        }

        /// <inheritdoc/>
        public override void FinishRental(Guid rentalId)
        {
            var rental = _rentals.FirstOrDefault(r => r.RentalId == rentalId)
                ?? throw new DomainException($"Rental {rentalId} not found for {Id} vehicle.");
            _rentals.Remove(rental);
        }

        /// <inheritdoc/>
        public override bool IsTooOld()
        {
            return Year < DateTime.UtcNow.Year - MaxVehicleAge;
        }

        private bool IsAvailable(DateTime startDate, DateTime endDate)
        {
            return !_rentals.Any(r => r.StartDate <= endDate && r.EndDate >= startDate);
        }
    }
}
