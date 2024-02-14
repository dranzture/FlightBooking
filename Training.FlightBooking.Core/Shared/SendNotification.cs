using Ardalis.SharedKernel;
using MediatR;
using Training.FlightBooking.Core.DTOs;

namespace Training.FlightBooking.Core.Shared;

public class SendNotification(PassengerDto passenger, ItineraryDto? itinerary = null) : DomainEventBase
{
    public readonly PassengerDto Passenger = passenger;
    public readonly ItineraryDto? Itinerary = itinerary;
}