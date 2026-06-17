using GtMotive.Estimate.Microservice.Domain;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetVehicle
{
    /// <summary>
    /// Input message for the Get Vehicle use case.
    /// </summary>
    public sealed class GetVehicleInput
        : IUseCaseInput
    {
        /// <summary>
        /// Gets the vehicle identifier.
        /// </summary>
        public VehicleId VehicleId { get; init; }
    }
}
