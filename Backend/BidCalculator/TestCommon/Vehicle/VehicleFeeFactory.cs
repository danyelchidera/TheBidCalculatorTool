using BidCalculator.Domain.Vehicle;
using TestCommon.TestConstants;

namespace TestCommon.Vehicle;

public static class VehicleFeeFactory
{
    public static VehicleFee CreateVehicleFee(
        VehicleFeeType? feeType = null, 
        decimal? amount = null)
    {
        return new VehicleFee(feeType ?? Constants.VehicleFee.VehicleFeeType, Constants.VehicleFee.Amount);
    }
}