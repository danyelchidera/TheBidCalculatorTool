using BidCalculator.Contracts.Vehicle;
using BidCalculator.Domain.Vehicle;
using Mapster;
using DomainVehicleFee = BidCalculator.Domain.Vehicle.VehicleFee;
using VehicleFee = BidCalculator.Contracts.Vehicle.VehicleFee;
using VehicleType = BidCalculator.Domain.Vehicle.VehicleType;

namespace BidCalculator.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddMapsterConfiguration(this IServiceCollection services)
    {
        services.AddMapster();
        
        TypeAdapterConfig<DomainVehicleFee, VehicleFee>.NewConfig()
            .Map(dest => dest.VehicleFeeType, src => TypeMappings.VehicleFeeTypeToDto(src.Type));
        
        TypeAdapterConfig<VehiclePrice, VehiclePriceResponse>.NewConfig()
            .Map(dest => dest.VehicleType, src => TypeMappings.VehicleTypeToDto(src.VehicleType));
        
        return services;
    }
}
