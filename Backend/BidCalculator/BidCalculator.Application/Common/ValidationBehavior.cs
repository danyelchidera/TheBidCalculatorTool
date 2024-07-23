using BidCalculator.Domain.Common;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using IResult = BidCalculator.Domain.Common.IResult;

namespace BidCalculator.Application.Common;

public class ValidationBehavior<TRequest, TResponse>(IValidator<TRequest>? validator = null)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IResult
{
    private readonly IValidator<TRequest>? _validator = validator;

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (_validator is null)
        {
            return await next();
        }

        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid)
        {
            return await next();
        }
        
        var errors =  validationResult.Errors
            .ConvertAll(error => new Error(
                Code: StatusCodes.Status400BadRequest,
                Message: error.ErrorMessage));

        return (dynamic)errors;
    }
}
