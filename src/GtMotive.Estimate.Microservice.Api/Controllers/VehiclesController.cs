using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.GetVehicle;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    /// <summary>
    /// Vehicles endpoint.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public sealed class VehiclesController(IMediator mediator)
        : ControllerBase
    {
        /// <summary>
        /// Creates a new vehicle.
        /// </summary>
        /// <param name="request">The create vehicle request.</param>
        /// <returns>The created vehicle.</returns>
        [HttpPost(Name = "CreateVehicle")]
        public async Task<IActionResult> Post([FromBody] CreateVehicleRequest request)
        {
            var presenter = await mediator.Send(request);
            return presenter.ActionResult;
        }

        /// <summary>
        /// Gets a vehicle by id.
        /// </summary>
        /// <param name="vehicleId">The vehicle identifier.</param>
        /// <returns>The vehicle.</returns>
        [HttpGet("{vehicleId:Guid}", Name = "GetVehicle")]
        public async Task<IActionResult> Get(Guid vehicleId)
        {
            var presenter = await mediator.Send(new GetVehicleRequest { VehicleId = vehicleId });
            return presenter.ActionResult;
        }
    }
}
