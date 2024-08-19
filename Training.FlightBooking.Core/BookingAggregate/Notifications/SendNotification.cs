using Training.FlightBooking.Core.DTOs;
using DomainEventBase = Training.FlightBooking.Core.Shared.DomainEventBase;

namespace Training.FlightBooking.Core.BookingAggregate.Notifications;

public class SendNotification(PassengerDto passenger, ItineraryDto? itinerary = null) : DomainEventBase
{
    public readonly PassengerDto Passenger = passenger;
    public readonly ItineraryDto? Itinerary = itinerary;
}