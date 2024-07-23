using BidCalculator.Domain.Common;

namespace BidCalculator.Domain.Vehicle;

public static class VehicleErrors
{
    public static readonly Error VehiclePriceCannotHaveDuplicateFeeTypes = new Error(
        Code: 400,
        Message: "Vehicle price cannot contain more than one of the same fee type");
    
    public static readonly Error FeeAmountMustBeGreaterThanZero = new Error(
        Code: 400,
        Message: "A fee amount of zero or less cannot be added to the list of fees");
    
    public static readonly Error InvalidVehicleType = new Error(
        Code: 400,
        Message: "Vehicle type is not valid");
}