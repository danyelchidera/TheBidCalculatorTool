using System.Reflection.Metadata;
using BidCalculator.Domain.Vehicle;
using TestCommon.TestConstants;

namespace TestCommon.Vehicle;

public static class VehiclePriceFactory
{
    public static VehiclePrice CreateVehiclePrice(
        VehicleType? vehicleType = null,
        decimal? basePrice = null)
    {
        return new VehiclePrice
            (basePrice ?? Constants.VehiclePrice.BasePrice,
            vehicleType ?? Constants.VehiclePrice.VehicleType);
    }
}