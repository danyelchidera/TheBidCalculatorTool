using BidCalculator.Application.Vehicle.Queries.CalculateVehicleTotalCost;
using BidCalculator.Contracts.Vehicle;
using BidCalculator.Domain.Common;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using DomainVehicleType = BidCalculator.Domain.Vehicle.VehicleType;

namespace BidCalculator.Api.Controllers;


[ApiController]
[Route("[Controller]")]
public class VehicleController(ISender mediator, IMapper mapper) : ControllerBase
{
    [HttpGet("calculate-total-price")]
    public async Task<IActionResult> CalculateTotalPrice([FromQuery] CalculateTotalPriceRequest request) {
        if (!DomainVehicleType.TryGetVehicleTypeByName(
                request.VehicleType.ToString(),
                out var vehicleType))
        {
            return Problem(
                statusCode: StatusCodes.Status400BadRequest,
                detail: "Invalid vehicle type");
        }
        
        var query = new CalculateVehicleTotalCostQuery(vehicleType, request.BasePrice);

        var vehiclePriceResult = await mediator.Send(query);

        if (!vehiclePriceResult.IsSuccess)
        {
            return vehiclePriceResult.Errors.Count > 0
                ? Problem(vehiclePriceResult.Errors)
                : Problem(vehiclePriceResult.Error);
        }
        
        return Ok(mapper.Map<VehiclePriceResponse>(vehiclePriceResult.Value));
        
    }
    
    protected IActionResult Problem(List<Error> errors)
    {
        if (errors.Count is 0)
        {
            return Problem();
        }
        
        return ValidationProblem(errors);
    }

    protected IActionResult Problem(Error error)
    {
        return Problem(statusCode: error.Code, detail: error.Message);
    }

    protected IActionResult ValidationProblem(List<Error> errors)
    {
        var modelStateDictionary = new ModelStateDictionary();

        foreach (var error in errors)
        {
            modelStateDictionary.AddModelError(
                error.Code.ToString(),
                error.Message);
        }

        return ValidationProblem(modelStateDictionary);
    }
}