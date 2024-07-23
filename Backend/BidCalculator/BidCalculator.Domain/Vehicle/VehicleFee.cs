namespace BidCalculator.Domain.Vehicle;

public class VehicleFee
{
    public VehicleFeeType Type { get; private set; }
    public decimal Amount { get; private set; }

    public VehicleFee(VehicleFeeType type, decimal amount)
    {
        Type = type;
        Amount = amount;
    }
}

