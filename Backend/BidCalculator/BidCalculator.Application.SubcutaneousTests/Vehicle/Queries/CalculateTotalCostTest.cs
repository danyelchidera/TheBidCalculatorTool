using BidCalculator.Application.SubcutaneousTests.Common;
using BidCalculator.Domain.Vehicle;
using MediatR;
using TestCommon.TestConstants;
using TestCommon.Vehicle;

namespace BidCalculator.Application.SubcutaneousTests.Vehicle.Queries;

[Collection(MediatorFactoryCollection.CollectionName)]
public class CalculateTotalCostTest(MediatorFactory mediatorFactory)
{
    private readonly IMediator _mediator = mediatorFactory.CreateMediator();

    [Fact]
    public async Task CalculateTotalCost_WhenBasePriceIsZero_ShouldReturnValidationError()
    {
        // Arrange
        var calculateTotalCostQuery = CalculateVehicleTotalCostQueryFactory.CreateQuery(basePrice: 0);

        // Act
        var calculateTotalCostResult = await _mediator.Send(calculateTotalCostQuery);

        // Assert
        
        Assert.False(calculateTotalCostResult.IsSuccess);
        Assert.Equal
        (Constants.ValidationErros.BasePriceMustBeGreaterThanZeroError, 
            calculateTotalCostResult.Errors.First().Message);
    }
    
    [Theory]
    [InlineData(398, nameof(VehicleType.Common), 550.76)]
    [InlineData(501, nameof(VehicleType.Common), 671.02)]
    [InlineData(57, nameof(VehicleType.Common), 173.14)]
    [InlineData(1800, nameof(VehicleType.Luxury), 2167)]
    [InlineData(1100, nameof(VehicleType.Common), 1287)]
    [InlineData(1000000, nameof(VehicleType.Luxury), 1040320)]
    public async Task CalculateTotalCost_WhenQueryIsValid_ShouldReturnCorrectTotalPrice(decimal basePrice, string vehicleTypeName, decimal expectedTotal)
    {
        // Arrange
        VehicleType.TryGetVehicleTypeByName(vehicleTypeName, out var vehicleType);
        var calculateTotalCostQuery = CalculateVehicleTotalCostQueryFactory.CreateQuery(vehicleType, basePrice);

        // Act
        var calculateTotalCostResult = await _mediator.Send(calculateTotalCostQuery);


        // Assert
        Assert.True(calculateTotalCostResult.IsSuccess);
        Assert.Equal
        (expectedTotal, 
            calculateTotalCostResult.Value.TotalPrice);
    }
}
