using BidCalculator.Application.Vehicle.Services.Interfaces;
using BidCalculator.Domain.Common;
using BidCalculator.Domain.Vehicle;

namespace BidCalculator.Application.Vehicle.Services.Implementations;

public class StorageFeeCalculator : IVehicleFeeCalculator
{
    public VehicleFeeType FeeType => VehicleFeeType.Storage;
    
    public Task<Result<VehicleFee>> CalculateFee(VehicleType vehicleType, decimal basePrice) => 
        Task.FromResult(Result<VehicleFee>
            .CreateSuccessResult(new VehicleFee(FeeType, 100m)));
    
}