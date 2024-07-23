using BidCalculator.Domain.Common;
using BidCalculator.Domain.Vehicle;

namespace BidCalculator.Application.Vehicle.Services.Interfaces;

public interface IVehicleFeeCalculator
{
    VehicleFeeType FeeType { get;  }
    Task<Result<VehicleFee>> CalculateFee(VehicleType vehicleType, decimal basePrice);
}