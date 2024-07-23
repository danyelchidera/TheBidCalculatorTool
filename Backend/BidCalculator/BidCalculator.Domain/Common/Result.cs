using System.Security.AccessControl;

namespace BidCalculator.Domain.Common;

public class Result<TValue> : IResult
{
    public List<Error>? Errors { get; private set;  }
    public bool IsSuccess { get; private set; }
    public Error? Error { get; private set; }
    public TValue Value { get; private set; }
    
    public static Result<TValue>  CreateSuccessResult()
    {
        return new Result<TValue> 
        {
            IsSuccess = true,
            Error = null
        };
    }
    
    public static Result<TValue>  CreateSuccessResult(TValue value)
    {
        return new Result<TValue> 
        {
            IsSuccess = true,
            Value = value,
            Error = null
        };
    }
    
    public static Result<TValue>  CreateErrorResult(Error error)
    {
        return new Result<TValue> 
        {
            IsSuccess = false,
            Error = error
        };
    }
    
    public static Result<TValue>  CreateValidationErrorResult(List<Error> errors)
    {
        return new Result<TValue> 
        {
            IsSuccess = false,
            Errors = errors
        };
    }
    
    public static implicit operator Result<TValue>(List<Error> errors)
    {
        return CreateValidationErrorResult(errors);
    }
}


