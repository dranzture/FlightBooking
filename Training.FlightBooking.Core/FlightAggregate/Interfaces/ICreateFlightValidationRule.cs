namespace Training.FlightBooking.Core.FlightAggregate.Interfaces;

public interface ICreateFlightValidationRule
{
    Task ValidateAsync(Flight flight, CancellationToken token);
}