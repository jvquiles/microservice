using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateRental;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateRental
{
    /// <summary>
    /// Presenter for the Create Rental use case.
    /// </summary>
    public sealed class CreateRentalPresenter
        : IWebApiPresenter, ICreateRentalOutputPort
    {
        /// <inheritdoc/>
        public IActionResult ActionResult { get; private set; }

        /// <inheritdoc/>
        public void StandardHandle(CreateRentalOutput output)
        {
            ArgumentNullException.ThrowIfNull(output);

            var response = new CreateRentalResponse
            {
                VehicleId = output.VehicleId.ToGuid(),
                RentalId = output.RentalId,
                UserEmail = output.UserEmail,
                StartDate = output.StartDate,
                EndDate = output.EndDate
            };

            ActionResult = new OkObjectResult(response);
        }

        /// <inheritdoc/>
        public void NotFoundHandle(string message)
        {
            ActionResult = new NotFoundObjectResult(message);
        }

        /// <inheritdoc/>
        public void BusinessRuleViolationHandle(string message)
        {
            ActionResult = new ConflictObjectResult(message);
        }
    }
}
