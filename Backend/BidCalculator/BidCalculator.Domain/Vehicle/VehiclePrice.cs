using BidCalculator.Domain.Common;

namespace BidCalculator.Domain.Vehicle;

public class VehiclePrice
{
    public decimal BasePrice { get; private set; }
    public List<VehicleFee> Fees { get; private set; }
    
    public VehicleType VehicleType { get; private set; }
    public decimal TotalPrice { get; private set; }

    public VehiclePrice(decimal basePrice, VehicleType vehicleType)
    {
        BasePrice = basePrice;
        TotalPrice = basePrice;
        VehicleType = vehicleType;
        Fees = new List<VehicleFee>();
    }

    public Result<Success> AddFees(VehicleFee fee)
    {
        if (Fees.Any(x => x.Type == fee.Type))
        {
            return Result<Success>.CreateErrorResult(VehicleErrors.VehiclePriceCannotHaveDuplicateFeeTypes);
        }
        
        Fees.Add(fee);
        TotalPrice += fee.Amount;

        return Result<Success>.CreateSuccessResult();
    }
}