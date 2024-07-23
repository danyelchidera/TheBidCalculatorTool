using BidCalculator.Domain.Common;
using BidCalculator.Domain.Vehicle;
using TestCommon.TestConstants;
using TestCommon.Vehicle;

namespace BidCalculator.Domain.UnitTest.Vehicle;

public class VehiclePriceTests
{
    [Fact]
    public void AddFee_WhenSameFeeTypeHasBeenAdded_ShouldFail()
    {
        // Arrange
        var vehiclePrice = VehiclePriceFactory.CreateVehiclePrice();
        
        var fees = Enumerable.Range(0, 2)
            .Select(_ => VehicleFeeFactory.CreateVehicleFee())
            .ToList();

        // Act
        var addFeeResults = fees.ConvertAll(vehiclePrice.AddFees);

        // Assert
        var firstFeeResult = addFeeResults.First();
        var lastFeeResult = addFeeResults.Last();
        
        Assert.True(firstFeeResult.IsSuccess);
        Assert.Equal(Constants.ResultTypes.Success, lastFeeResult.Value);
        Assert.False(lastFeeResult.IsSuccess);
        Assert.Equal(VehicleErrors.VehiclePriceCannotHaveDuplicateFeeTypes, lastFeeResult.Error);
    }
}