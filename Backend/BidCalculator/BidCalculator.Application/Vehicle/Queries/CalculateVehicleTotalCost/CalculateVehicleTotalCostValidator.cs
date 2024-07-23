using FluentValidation;

namespace BidCalculator.Application.Vehicle.Queries.CalculateVehicleTotalCost;

public class CalculateVehicleTotalCostValidator : AbstractValidator<CalculateVehicleTotalCostQuery>
{
    public CalculateVehicleTotalCostValidator()
    {
        RuleFor(x => x.BasePrice)
            .GreaterThan(0).WithMessage("Base price must be greater than zero");
    }
}

