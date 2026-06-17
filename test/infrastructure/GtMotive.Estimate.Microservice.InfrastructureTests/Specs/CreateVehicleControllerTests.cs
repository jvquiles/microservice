using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using GtMotive.Estimate.Microservice.Api.Controllers;
using GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle;
using MediatR;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Specs
{
    /// <summary>
    /// Unit tests for the VehiclesController CreateVehicle action validating controller behavior.
    /// </summary>
    public sealed class CreateVehicleControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly VehiclesController _controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleControllerTests"/> class.
        /// </summary>
        public CreateVehicleControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new VehiclesController(_mediatorMock.Object);
        }

        /// <summary>
        /// CreateVehicle with a valid CreateVehicleRequest should return the presenter's ActionResult.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous test.</returns>
        [Fact]
        public async Task CreateVehicleWithValidRequestReturnsPresenterResult()
        {
            var presenter = new CreateVehiclePresenter();
            var request = new CreateVehicleRequest
            {
                LicensePlate = "1234ABC",
                Brand = "Toyota",
                Model = "Corolla",
                Year = 2024,
                DailyRate = 50m
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<CreateVehicleRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(presenter);

            var result = await _controller.CreateVehicle(request);

            result.Should().Be(presenter.ActionResult);
        }

        /// <summary>
        /// CreateVehicle should pass the CreateVehicleRequest to IMediator.Send.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous test.</returns>
        [Fact]
        public async Task CreateVehicleShouldSendRequestToMediator()
        {
            var request = new CreateVehicleRequest
            {
                LicensePlate = "1234ABC",
                Brand = "Toyota",
                Model = "Corolla",
                Year = 2024,
                DailyRate = 50m
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<CreateVehicleRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CreateVehiclePresenter());

            await _controller.CreateVehicle(request);

            _mediatorMock.Verify(m => m.Send(request, It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
