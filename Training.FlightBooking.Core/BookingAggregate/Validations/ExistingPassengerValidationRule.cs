using Ardalis.SharedKernel;
using Training.FlightBooking.Core.BookingAggregate.Interfaces;
using Training.FlightBooking.Core.BookingAggregate.Specifications;
using Training.FlightBooking.Core.PassengerAggregate;
using Training.FlightBooking.Core.PassengerAggregate.Specifications;

namespace Training.FlightBooking.Core.BookingAggregate.Validations;

public class ExistingPassengerValidationRule(IRepository<Booking> repository) : IBookPassengerValidationRule
{
    private readonly IRepository<Booking> _repository = repository;
    
    public async Task ValidateAsync(Booking booking, CancellationToken token)
    {
        var passengerNoTrack = new FindByFlightIdAndPassengerId(booking.FlightId,booking.PassengerId);
        var passenger = await _repository.FirstOrDefaultAsync(passengerNoTrack, token);
        if (passenger is not null) throw new ArgumentException("Passenger has already booked flight");
    }
}