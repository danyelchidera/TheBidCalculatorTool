namespace BidCalculator.Contracts.Vehicle;

public record VehiclePriceResponse(decimal BasePrice, decimal TotalPrice, List<VehicleFee> Fees, VehicleType VehicleType);