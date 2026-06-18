using System.Collections.Generic;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllVehicles
{
    /// <summary>
    /// Output message for the Get All Vehicles use case.
    /// </summary>
    public sealed class GetAllVehiclesOutput
        : IUseCaseOutput
    {
        /// <summary>
        /// Gets the list of vehicles.
        /// </summary>
        public IReadOnlyCollection<GetAllVehiclesItem> Vehicles { get; init; }
    }
}
