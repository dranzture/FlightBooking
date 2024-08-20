using FluentValidation.Results;

namespace Training.FlightBooking.Core.Shared;

public class Result
{
    public bool IsSuccess { get; private set; }
    public List<ValidationFailure>? Errors { get; private set; }

    protected Result(bool isSuccess, List<ValidationFailure>? errors)
    {
        IsSuccess = isSuccess;
        Errors = errors;
    }

    public static Result Success() => new Result(true, null);

    public static Result Failure(List<ValidationFailure>? errors) => new Result(false, errors);
    public static Result Failure(ValidationFailure error) => new Result(false, new List<ValidationFailure>() { error });
}

public class Result<T> : Result
{
    private Result(bool isSuccess, List<ValidationFailure>? errors)
        : base(isSuccess, errors)
    {
    }

    public static Result<T> Success(T value) => new(true, null);

    public static Result<T> Failure(List<ValidationFailure> errors) => new(false, errors);

    public static Result<T> Failure(ValidationFailure error) => new(false, new List<ValidationFailure> { error });
}