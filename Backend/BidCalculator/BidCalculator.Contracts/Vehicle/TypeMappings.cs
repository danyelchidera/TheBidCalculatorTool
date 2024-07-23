namespace BidCalculator.Contracts.Vehicle;
using DomainVehicleType = BidCalculator.Domain.Vehicle.VehicleType;
using DomainVehicleFeeType = BidCalculator.Domain.Vehicle.VehicleFeeType;

public class TypeMappings
{
    public static VehicleType VehicleTypeToDto(DomainVehicleType vehicleType)
    {
        return vehicleType.Name switch
        {
            nameof(DomainVehicleType.Common) => VehicleType.Common,
            nameof(DomainVehicleType.Luxury) => VehicleType.Luxury
        };
    }
    
    public static VehicleFeeType VehicleFeeTypeToDto(DomainVehicleFeeType vehicleFeeType)
    {
        return vehicleFeeType.Name switch
        {
            nameof(DomainVehicleFeeType.Basic) => VehicleFeeType.Basic,
            nameof(DomainVehicleFeeType.Special) => VehicleFeeType.Special,
            nameof(DomainVehicleFeeType.Association) => VehicleFeeType.Association,
            nameof(DomainVehicleFeeType.Storage) => VehicleFeeType.Storage
        };
    }
}