using BidCalculator.Domain.Common;
using BidCalculator.Domain.Vehicle;
using MediatR;

namespace BidCalculator.Application.Vehicle.Queries.CalculateVehicleTotalCost;

public record CalculateVehicleTotalCostQuery(VehicleType VehicleType, decimal BasePrice) : IRequest<Result<VehiclePrice>>;