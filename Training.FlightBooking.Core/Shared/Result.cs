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

    public static Result Success() => new(true, null);

    public static Result Failure(List<ValidationFailure>? errors) => new(false, errors);

    public static Result Failure(ValidationFailure error) => new(false, new List<ValidationFailure> { error });
}

public class Result<T> : Result
{
    public T? Value { get; private set; }

    private Result(bool isSuccess, T? value, List<ValidationFailure>? errors)
        : base(isSuccess, errors)
    {
        Value = value;
    }

    public static Result<T> Success(T value) => new(true, value, null);

    public new static Result<T> Failure(List<ValidationFailure> errors) => new(false, default, errors);

    public new static Result<T> Failure(ValidationFailure error) => new(false, default, new List<ValidationFailure> { error });
}