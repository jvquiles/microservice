namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllVehicles
{
    /// <summary>
    /// Input message for the Get All Vehicles use case.
    /// </summary>
    public sealed class GetAllVehiclesInput
        : IUseCaseInput
    {
        /// <summary>
        /// Gets or sets an optional filter by availability.
        /// </summary>
        public bool? AvailableForRent { get; set; }
    }
}
