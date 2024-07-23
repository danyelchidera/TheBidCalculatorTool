using BidCalculator.Application.Vehicle.Services.Interfaces;
using BidCalculator.Domain.Common;
using BidCalculator.Domain.Vehicle;
using MediatR;

namespace BidCalculator.Application.Vehicle.Queries.CalculateVehicleTotalCost;

public class CalculateTotalVehicleCostHandler(IEnumerable<IVehicleFeeCalculator> vehicleFeeCalculators)
    : IRequestHandler<CalculateVehicleTotalCostQuery, Result<VehiclePrice>>
{
    public async Task<Result<VehiclePrice>> Handle(CalculateVehicleTotalCostQuery request, CancellationToken cancellationToken)
    {
        var vehiclePrice = new VehiclePrice(request.BasePrice, request.VehicleType);

        foreach (var calculator in vehicleFeeCalculators)
        {
            var result = await calculator.CalculateFee(request.VehicleType, request.BasePrice);

            if (!result.IsSuccess)
            {
                return Result<VehiclePrice>.CreateErrorResult(result.Error);
            }

            vehiclePrice.AddFees(result.Value);
        }

        return Result<VehiclePrice>.CreateSuccessResult(vehiclePrice);
    }
}