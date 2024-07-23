namespace BidCalculator.Contracts.Vehicle;

public record CalculateTotalPriceRequest(VehicleType VehicleType, decimal BasePrice);