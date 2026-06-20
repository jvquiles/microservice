using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.Api.UseCases.CreateRental;
using GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.GetAllVehicles;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Specs
{
    /// <summary>
    /// Functional integration tests for vehicle rental operations.
    /// </summary>
    public sealed class VehicleRentalFunctionalTests(CompositionRootTestFixture fixture)
        : FunctionalTestBase(fixture)
    {
        /// <inheritdoc/>
        public override async Task InitializeAsync()
        {
            await Fixture.UsingRepository<IVehicleRepository>(repo => repo.DeleteAll());
            await base.InitializeAsync();
        }

        [Fact]
        public async Task RentVehicleAndRetrieveShouldIncludeRentals()
        {
            var vehicleId = Guid.Empty;

            await Fixture.UsingHandlerForRequestResponse<CreateVehicleRequest, IWebApiPresenter>(async handler =>
            {
                var request = new CreateVehicleRequest
                {
                    LicensePlate = $"FUN-RENTAL-{Guid.NewGuid():N}"[..15],
                    Brand = "Functional",
                    Model = "Test",
                    Year = 2024,
                    DailyRate = 100m
                };
                var presenter = await handler.Handle(request, CancellationToken.None);
                var result = (CreatedAtRouteResult)presenter.ActionResult;
                var response = (CreateVehicleResponse)result.Value;
                vehicleId = response.VehicleId;
            });

            var startDate = DateTime.UtcNow.AddDays(1);
            var endDate = DateTime.UtcNow.AddDays(5);

            await Fixture.UsingHandlerForRequestResponse<CreateRentalRequest, IWebApiPresenter>(async handler =>
            {
                var request = new CreateRentalRequest
                {
                    VehicleId = vehicleId,
                    UserEmail = "test@test.com",
                    StartDate = startDate,
                    EndDate = endDate
                };
                var presenter = await handler.Handle(request, CancellationToken.None);
                presenter.ActionResult.Should().BeOfType<OkObjectResult>();
            });

            await Fixture.UsingRepository<IVehicleRepository>(async repo =>
            {
                var vehicle = await repo.GetBy(new VehicleId(vehicleId));
                vehicle.Should().NotBeNull();
                vehicle.Rentals.Should().HaveCount(1);
                var rental = vehicle.Rentals.First();
                rental.UserEmail.Should().Be("test@test.com");
                rental.StartDate.Should().BeCloseTo(startDate, TimeSpan.FromMilliseconds(1));
                rental.EndDate.Should().BeCloseTo(endDate, TimeSpan.FromMilliseconds(1));
            });
        }

        [Fact]
        public async Task GetAllVehiclesShouldFilterByAvailability()
        {
            var vehicleId = Guid.Empty;

            await Fixture.UsingHandlerForRequestResponse<CreateVehicleRequest, IWebApiPresenter>(async handler =>
            {
                var request = new CreateVehicleRequest
                {
                    LicensePlate = $"FUN-AVAIL-{Guid.NewGuid():N}"[..15],
                    Brand = "Functional",
                    Model = "Test",
                    Year = 2024,
                    DailyRate = 100m
                };
                var presenter = await handler.Handle(request, CancellationToken.None);
                var result = (CreatedAtRouteResult)presenter.ActionResult;
                var response = (CreateVehicleResponse)result.Value;
                vehicleId = response.VehicleId;
            });

            await Fixture.UsingHandlerForRequestResponse<CreateRentalRequest, IWebApiPresenter>(async handler =>
            {
                var request = new CreateRentalRequest
                {
                    VehicleId = vehicleId,
                    UserEmail = "test@test.com",
                    StartDate = DateTime.UtcNow.AddDays(-10),
                    EndDate = DateTime.UtcNow.AddDays(10)
                };
                var presenter = await handler.Handle(request, CancellationToken.None);
                presenter.ActionResult.Should().BeOfType<OkObjectResult>();
            });

            await Fixture.UsingHandlerForRequestResponse<GetAllVehiclesRequest, IWebApiPresenter>(async handler =>
            {
                var request = new GetAllVehiclesRequest
                {
                    AvailableForRent = true
                };
                var presenter = await handler.Handle(request, CancellationToken.None);
                var result = (OkObjectResult)presenter.ActionResult;
                var vehicles = (System.Collections.Generic.List<GetAllVehiclesResponse>)result.Value;
                vehicles.Should().NotContain(v => v.VehicleId == vehicleId);
            });

            await Fixture.UsingHandlerForRequestResponse<GetAllVehiclesRequest, IWebApiPresenter>(async handler =>
            {
                var request = new GetAllVehiclesRequest
                {
                    AvailableForRent = false
                };
                var presenter = await handler.Handle(request, CancellationToken.None);
                var result = (OkObjectResult)presenter.ActionResult;
                var vehicles = (System.Collections.Generic.List<GetAllVehiclesResponse>)result.Value;
                vehicles.Should().Contain(v => v.VehicleId == vehicleId);
            });
        }
    }
}
