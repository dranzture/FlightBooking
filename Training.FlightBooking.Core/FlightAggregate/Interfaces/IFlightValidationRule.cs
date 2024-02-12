namespace Training.FlightBooking.Core.FlightAggregate.Interfaces;

public interface IFlightValidationRule
{
    Task ValidateAsync(Flight flight, CancellationToken token);
}