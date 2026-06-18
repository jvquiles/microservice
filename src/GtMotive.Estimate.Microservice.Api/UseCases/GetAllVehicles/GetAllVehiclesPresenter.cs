using System;
using System.Linq;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllVehicles;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetAllVehicles
{
    /// <summary>
    /// Presenter for the Get All Vehicles use case.
    /// </summary>
    public sealed class GetAllVehiclesPresenter
        : IWebApiPresenter, IGetAllVehiclesOutputPort
    {
        /// <inheritdoc/>
        public IActionResult ActionResult { get; private set; }

        /// <inheritdoc/>
        public void StandardHandle(GetAllVehiclesOutput output)
        {
            ArgumentNullException.ThrowIfNull(output);

            var response = output.Vehicles
                .Select(vehicle => new GetAllVehiclesResponse
                {
                    VehicleId = vehicle.VehicleId.ToGuid(),
                    LicensePlate = vehicle.LicensePlate.ToString(),
                    Brand = vehicle.Brand,
                    Model = vehicle.Model,
                    Year = vehicle.Year,
                    DailyRate = vehicle.DailyRate
                })
                .ToList();

            ActionResult = new OkObjectResult(response);
        }
    }
}
