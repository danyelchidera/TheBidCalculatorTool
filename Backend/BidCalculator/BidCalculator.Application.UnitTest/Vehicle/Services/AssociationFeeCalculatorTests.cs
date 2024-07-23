using BidCalculator.Domain.Vehicle;
using TestCommon.FeeCalculators;

namespace BidCalculator.Application.UnitTest.Vehicle.Services;

public class AssociationFeeCalculatorTests
{
    [Theory]
    [InlineData(398, nameof(VehicleType.Common), 5)]
    [InlineData(501, nameof(VehicleType.Common), 10)]
    [InlineData(57, nameof(VehicleType.Common), 5)]
    [InlineData(1800, nameof(VehicleType.Luxury), 15)]
    [InlineData(1100, nameof(VehicleType.Common), 15)]
    [InlineData(1000000, nameof(VehicleType.Luxury), 20)]
    public async Task CalculateAssociationFee_ShouldReturnCorrectFeeAmountAndType(decimal basePrice, string vehicleTypeName, decimal expectedFee)
    {
        // Arrange
        var associationFeeCalculator = FeeCalculatorFactory.GetCalculator(VehicleFeeType.Association);
        VehicleType.TryGetVehicleTypeByName(vehicleTypeName, out var vehicleType);
        
        // Act
        var result = await associationFeeCalculator.CalculateFee(vehicleType, basePrice);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(expectedFee, result.Value.Amount);
        Assert.Equal(VehicleFeeType.Association, result.Value.Type);
    }
}