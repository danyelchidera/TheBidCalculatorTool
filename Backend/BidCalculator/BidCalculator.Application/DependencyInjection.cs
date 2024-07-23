using BidCalculator.Application.Common;
using BidCalculator.Application.Vehicle.Services.Implementations;
using BidCalculator.Application.Vehicle.Services.Interfaces;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BidCalculator.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection));
            options.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddScoped<IVehicleFeeCalculator, AssociationFeeCalculator>();
        services.AddScoped<IVehicleFeeCalculator, BasicFeeCalculator>();
        services.AddScoped<IVehicleFeeCalculator, SpecialFeeCalculator>();
        services.AddScoped<IVehicleFeeCalculator, StorageFeeCalculator>();
        
        services.AddValidatorsFromAssemblyContaining(typeof(DependencyInjection));


        return services;
    }
}