namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateRental
{
    /// <summary>
    /// Output port for the Create Rental use case.
    /// </summary>
    public interface ICreateRentalOutputPort
        : IOutputPortStandard<CreateRentalOutput>, IOutputPortNotFound, IOutputPortBusinessRuleViolation
    {
    }
}
