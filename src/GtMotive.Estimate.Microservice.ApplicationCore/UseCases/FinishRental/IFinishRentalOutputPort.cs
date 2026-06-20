namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.FinishRental
{
    /// <summary>
    /// Output port for the Finish Rental use case.
    /// </summary>
    public interface IFinishRentalOutputPort
        : IOutputPortStandard<FinishRentalOutput>, IOutputPortNotFound
    {
    }
}
