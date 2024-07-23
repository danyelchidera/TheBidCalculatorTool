using BidCalculator.Application.Vehicle.Services.Implementations;
using BidCalculator.Application.Vehicle.Services.Interfaces;
using BidCalculator.Domain.Vehicle;

namespace TestCommon.FeeCalculators;

public class FeeCalculatorFactory
{
    public static IVehicleFeeCalculator GetCalculator(VehicleFeeType vehicleFeeType)
    {
        return vehicleFeeType.Name switch
        {
            nameof(VehicleFeeType.Basic) => new BasicFeeCalculator(),
            nameof(VehicleFeeType.Special) => new SpecialFeeCalculator(),
            nameof(VehicleFeeType.Association) => new AssociationFeeCalculator(),
            nameof(VehicleFeeType.Storage) => new StorageFeeCalculator()
        };
    }
}