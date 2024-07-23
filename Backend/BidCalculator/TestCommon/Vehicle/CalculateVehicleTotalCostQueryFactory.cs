using BidCalculator.Application.Vehicle.Queries.CalculateVehicleTotalCost;
using BidCalculator.Domain.Vehicle;
using TestCommon.TestConstants;

namespace TestCommon.Vehicle;

public static class CalculateVehicleTotalCostQueryFactory
{
    public static CalculateVehicleTotalCostQuery CreateQuery
        (VehicleType vehicleType = null, decimal? basePrice = null)
    {
        return new CalculateVehicleTotalCostQuery
        (vehicleType ?? Constants.VehiclePrice.VehicleType,
            basePrice ?? Constants.VehiclePrice.BasePrice);
    }
}