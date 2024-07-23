using BidCalculator.Domain.Vehicle;
using TestCommon.FeeCalculators;

namespace BidCalculator.Application.UnitTest.Vehicle.Services;

public class SpecialFeeCalculatorTests
{
    [Theory]
    [InlineData(398, nameof(VehicleType.Common), 7.96)]
    [InlineData(501, nameof(VehicleType.Common), 10.02)]
    [InlineData(57, nameof(VehicleType.Common), 1.14)]
    [InlineData(1800, nameof(VehicleType.Luxury), 72)]
    [InlineData(1100, nameof(VehicleType.Common), 22)]
    [InlineData(1000000, nameof(VehicleType.Luxury), 40000)]
    public async Task CalculateSpecialFee_ShouldReturnCorrectFeeAmountAndType(decimal basePrice, string vehicleTypeName, decimal expectedFee)
    {
        // Arrange
        var specialFeeCalculator = FeeCalculatorFactory.GetCalculator(VehicleFeeType.Special);
        VehicleType.TryGetVehicleTypeByName(vehicleTypeName, out var vehicleType);
        
        // Act
        var result = await specialFeeCalculator.CalculateFee(vehicleType, basePrice);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(expectedFee, result.Value.Amount);
        Assert.Equal(VehicleFeeType.Special, result.Value.Type);
    }
}