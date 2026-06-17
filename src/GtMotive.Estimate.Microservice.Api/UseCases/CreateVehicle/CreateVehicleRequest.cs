using System.Text.Json.Serialization;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle
{
    /// <summary>
    /// Request to create a new vehicle.
    /// </summary>
    public sealed class CreateVehicleRequest
        : IRequest<IWebApiPresenter>
    {
        /// <summary>
        /// Gets or sets the license plate.
        /// </summary>
        public string LicensePlate { get; set; }

        /// <summary>
        /// Gets or sets the brand.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the manufacturing year.
        /// </summary>
        [JsonRequired]
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the daily rental rate.
        /// </summary>
        [JsonRequired]
        public decimal DailyRate { get; set; }
    }
}
