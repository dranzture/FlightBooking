using Ardalis.SharedKernel;
using Training.FlightBooking.Core.BookingAggregate.Interfaces;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.FlightAggregate.Specifications;

namespace Training.FlightBooking.Core.BookingAggregate.Validations;

public class ExistingFlightValidationRule(IRepository<Flight> repository) : IBookPassengerValidationRule
{
    private readonly IRepository<Flight> _repository = repository;
    
    public async Task ValidateAsync(Booking booking, CancellationToken token)
    {
        var flightNoTrack = new GetFlightById(booking.FlightId);
        
        var flight = await _repository.FirstOrDefaultAsync(flightNoTrack, token);
        if (flight is null) throw new ArgumentException("Flight not found");
    }
}