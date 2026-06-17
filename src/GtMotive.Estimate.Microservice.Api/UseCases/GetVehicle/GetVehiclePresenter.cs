using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetVehicle;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetVehicle
{
    /// <summary>
    /// Presenter for the Get Vehicle use case.
    /// </summary>
    public sealed class GetVehiclePresenter
        : IWebApiPresenter, IGetVehicleOutputPort
    {
        /// <inheritdoc/>
        public IActionResult ActionResult { get; private set; }

        /// <inheritdoc/>
        public void StandardHandle(GetVehicleOutput output)
        {
            ArgumentNullException.ThrowIfNull(output);

            var response = new GetVehicleResponse
            {
                VehicleId = output.VehicleId.ToGuid(),
                LicensePlate = output.LicensePlate.ToString(),
                Brand = output.Brand,
                Model = output.Model,
                Year = output.Year,
                DailyRate = output.DailyRate
            };

            ActionResult = new OkObjectResult(response);
        }

        /// <inheritdoc/>
        public void NotFoundHandle(string message)
        {
            ActionResult = new NotFoundObjectResult(message);
        }
    }
}
