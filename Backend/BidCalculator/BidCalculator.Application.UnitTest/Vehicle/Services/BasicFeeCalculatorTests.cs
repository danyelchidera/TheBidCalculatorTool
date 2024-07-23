using BidCalculator.Domain.Vehicle;
using TestCommon.FeeCalculators;

namespace BidCalculator.Application.UnitTest.Vehicle.Services;

public class BasicFeeCalculatorTests
{
    [Theory]
    [InlineData(398, nameof(VehicleType.Common), 39.8)]
    [InlineData(501, nameof(VehicleType.Common), 50)]
    [InlineData(57, nameof(VehicleType.Common), 10)]
    [InlineData(1800, nameof(VehicleType.Luxury), 180)]
    [InlineData(1100, nameof(VehicleType.Common), 50)]
    [InlineData(1000000, nameof(VehicleType.Luxury), 200)]
    public async Task CalculateBasicFee_ShouldReturnCorrectFeeAmountAndType(decimal basePrice, string vehicleTypeName, decimal expectedFee)
    {
        // Arrange
        var basicFeeCalculator = FeeCalculatorFactory.GetCalculator(VehicleFeeType.Basic);
        VehicleType.TryGetVehicleTypeByName(vehicleTypeName, out var vehicleType);
        
        // Act
        var result = await basicFeeCalculator.CalculateFee(vehicleType, basePrice);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(expectedFee, result.Value.Amount);
        Assert.Equal(VehicleFeeType.Basic, result.Value.Type);
    }
}