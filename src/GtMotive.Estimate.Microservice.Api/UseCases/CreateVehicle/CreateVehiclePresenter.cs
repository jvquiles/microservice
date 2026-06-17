using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle
{
    /// <summary>
    /// Presenter for the Create Vehicle use case.
    /// </summary>
    public sealed class CreateVehiclePresenter
        : IWebApiPresenter, ICreateVehicleOutputPort
    {
        /// <inheritdoc/>
        public IActionResult ActionResult { get; private set; }

        /// <inheritdoc/>
        public void StandardHandle(CreateVehicleOutput output)
        {
            ArgumentNullException.ThrowIfNull(output);
            var response = new CreateVehicleResponse
            {
                VehicleId = output.VehicleId.ToGuid(),
                LicensePlate = output.LicensePlate.ToString(),
                Brand = output.Brand,
                Model = output.Model,
                Year = output.Year,
                DailyRate = output.DailyRate
            };

            ActionResult = new CreatedAtRouteResult(
                "GetVehicle",
                new { vehicleId = response.VehicleId },
                response);
        }
    }
}
