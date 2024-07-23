using BidCalculator.Application.Vehicle.Services.Interfaces;
using BidCalculator.Domain.Common;
using BidCalculator.Domain.Vehicle;

namespace BidCalculator.Application.Vehicle.Services.Implementations;

public class SpecialFeeCalculator : IVehicleFeeCalculator
{
    public VehicleFeeType FeeType => VehicleFeeType.Special;
    
    public Task<Result<VehicleFee>> CalculateFee(VehicleType vehicleType, decimal basePrice)
    {
        decimal feeAmount;
        
        if (vehicleType == VehicleType.Common)
        {
            feeAmount = basePrice * 0.02m;
        }
        else if (vehicleType == VehicleType.Luxury)
        {
            feeAmount = basePrice * 0.04m;
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