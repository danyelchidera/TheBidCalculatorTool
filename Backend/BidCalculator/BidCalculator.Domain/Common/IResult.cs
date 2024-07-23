namespace BidCalculator.Domain.Common;

public interface IResult
{
    List<Error>? Errors { get; }
    public bool IsSuccess { get; }
}