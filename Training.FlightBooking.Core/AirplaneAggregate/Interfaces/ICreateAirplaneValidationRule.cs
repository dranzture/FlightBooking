namespace Training.FlightBooking.Core.AirplaneAggregate.Interfaces;

public interface ICreateAirplaneValidationRule
{
    Task ValidateAsync(Airplane airplane, CancellationToken token);
}