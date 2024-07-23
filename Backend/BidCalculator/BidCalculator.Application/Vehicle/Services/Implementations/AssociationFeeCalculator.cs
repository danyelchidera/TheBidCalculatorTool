using BidCalculator.Application.Vehicle.Services.Interfaces;
using BidCalculator.Domain.Common;
using BidCalculator.Domain.Vehicle;

namespace BidCalculator.Application.Vehicle.Services.Implementations;

public class AssociationFeeCalculator : IVehicleFeeCalculator
{
    public VehicleFeeType FeeType => VehicleFeeType.Association;
    
    public Task<Result<VehicleFee>> CalculateFee(VehicleType vehicleType, decimal basePrice)
    {
        if (basePrice is >= 1 and <= 500)
        {
            return Task.FromResult(Result<VehicleFee>
                .CreateSuccessResult(new VehicleFee(FeeType, 5)));
        }
        if (basePrice is > 500 and <= 1000)
        {
            return Task.FromResult(Result<VehicleFee>
                .CreateSuccessResult(new VehicleFee(FeeType, 10)));
        }
        if (basePrice is > 1000 and <= 3000)
        {
            return Task.FromResult(Result<VehicleFee>
                .CreateSuccessResult(new VehicleFee(FeeType, 15)));
        }
        
        return Task.FromResult(Result<VehicleFee>
            .CreateSuccessResult(new VehicleFee(FeeType, 20)));
        
    }
}