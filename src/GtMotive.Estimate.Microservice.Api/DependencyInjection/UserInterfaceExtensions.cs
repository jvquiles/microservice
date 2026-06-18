using GtMotive.Estimate.Microservice.Api.UseCases.CreateRental;
using GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.GetAllVehicles;
using GtMotive.Estimate.Microservice.Api.UseCases.GetVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateRental;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllVehicles;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Api.DependencyInjection
{
    public static class UserInterfaceExtensions
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<CreateVehiclePresenter>();
            services.AddScoped<ICreateVehicleOutputPort, CreateVehiclePresenter>();

            services.AddScoped<GetVehiclePresenter>();

            services.AddScoped<GetAllVehiclesPresenter>();
            services.AddScoped<IGetAllVehiclesOutputPort, GetAllVehiclesPresenter>();

            services.AddScoped<CreateRentalPresenter>();
            services.AddScoped<ICreateRentalOutputPort, CreateRentalPresenter>();

            return services;
        }
    }
}
