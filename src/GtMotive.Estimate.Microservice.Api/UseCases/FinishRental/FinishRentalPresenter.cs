using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.FinishRental;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.FinishRental
{
    /// <summary>
    /// Presenter for the Finish Rental use case.
    /// </summary>
    public sealed class FinishRentalPresenter
        : IWebApiPresenter, IFinishRentalOutputPort
    {
        /// <inheritdoc/>
        public IActionResult ActionResult { get; private set; }

        /// <inheritdoc/>
        public void StandardHandle(FinishRentalOutput output)
        {
            ArgumentNullException.ThrowIfNull(output);

            var response = new FinishRentalResponse
            {
                VehicleId = output.VehicleId.ToGuid(),
                RentalId = output.RentalId
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
