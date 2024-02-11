using MediatR;
using Training.FlightBooking.Core.DTOs;

namespace Training.FlightBooking.Core.Shared;

public class SendNotification(PassengerDto passenger, ItineraryDto? itinary = null) : INotification
{
    public readonly PassengerDto Passenger = passenger;
    public readonly ItineraryDto? Itinary = itinary;
}