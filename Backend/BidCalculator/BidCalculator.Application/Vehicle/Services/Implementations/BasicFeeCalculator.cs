using BidCalculator.Application.Vehicle.Services.Interfaces;
using BidCalculator.Domain.Common;
using BidCalculator.Domain.Vehicle;

namespace BidCalculator.Application.Vehicle.Services.Implementations;

public class BasicFeeCalculator : IVehicleFeeCalculator
{
    public VehicleFeeType FeeType => VehicleFeeType.Basic;

    public Task<Result<VehicleFee>> CalculateFee(VehicleType vehicleType, decimal basePrice)
    {
        var percentageToPay = basePrice * 0.1m;
        decimal feeAmount;
        
        if (vehicleType == VehicleType.Common)
        {
            feeAmount = Math.Clamp(percentageToPay, 10m, 50m);
        }
        else if (vehicleType == VehicleType.Luxury)
        {
            feeAmount = Math.Clamp(percentageToPay, 25m, 200m);
        }
        else
        {
            return Task.FromResult(Result<VehicleFee>
                .CreateErrorResult(VehicleErrors.InvalidVehicleType));
        }
        
        return Task.FromResult(Result<VehicleFee>
            .CreateSuccessResult(new VehicleFee(FeeType, feeAmount)));
    }
}