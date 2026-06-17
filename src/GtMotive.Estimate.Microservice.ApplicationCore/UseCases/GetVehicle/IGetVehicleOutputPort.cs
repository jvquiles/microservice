namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetVehicle
{
    /// <summary>
    /// Output port for the Get Vehicle use case.
    /// </summary>
    public interface IGetVehicleOutputPort
        : IOutputPortStandard<GetVehicleOutput>, IOutputPortNotFound
    {
    }
}
