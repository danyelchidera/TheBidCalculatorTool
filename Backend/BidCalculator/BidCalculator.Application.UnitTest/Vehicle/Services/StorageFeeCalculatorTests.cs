using BidCalculator.Domain.Vehicle;
using TestCommon.FeeCalculators;

namespace BidCalculator.Application.UnitTest.Vehicle.Services;

public class StorageFeeCalculatorTests
{
    [Theory]
    [InlineData(398, nameof(VehicleType.Common), 100)]
    [InlineData(501, nameof(VehicleType.Common), 100)]
    [InlineData(57, nameof(VehicleType.Common), 100)]
    [InlineData(1800, nameof(VehicleType.Luxury), 100)]
    [InlineData(1100, nameof(VehicleType.Common), 100)]
    [InlineData(1000000, nameof(VehicleType.Luxury), 100)]
    public async Task CalculateStorageFee_ShouldReturnCorrectFeeAmountAndType
        (decimal basePrice, string vehicleTypeName, decimal expectedFee)
    {
        // Arrange
        var storageFeeCalculator = FeeCalculatorFactory.GetCalculator(VehicleFeeType.Storage);
        VehicleType.TryGetVehicleTypeByName(vehicleTypeName, out var vehicleType);
        
        // Act
        var result = await storageFeeCalculator.CalculateFee(vehicleType, basePrice);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(expectedFee, result.Value.Amount);
        Assert.Equal(VehicleFeeType.Storage, result.Value.Type);
    }
}