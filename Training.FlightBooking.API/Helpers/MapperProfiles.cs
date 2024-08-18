using AutoMapper;
using Training.FlightBooking.Core.AirplaneAggregate;
using Training.FlightBooking.Core.AirplaneAggregate.Requests;
using Training.FlightBooking.Core.BookingAggregate;
using Training.FlightBooking.Core.BookingAggregate.Requests;
using Training.FlightBooking.Core.DTOs;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.FlightAggregate.Requests;
using Training.FlightBooking.Core.PassengerAggregate;
using Training.FlightBooking.Core.ValueObjects;

namespace Training.FlightBooking.API.Helpers;

public class MapperProfiles : Profile
{
    public MapperProfiles()
    {
        #region FlightTransformations

        CreateMap<FlightDto, Flight>()
            .ForMember(dest => dest.Seats, opt => opt.Ignore())
            .ForMember(dest => dest.BookedSeats, opt => opt.Ignore())
            .ForMember(dest => dest.Airplane, opt => opt.Ignore())
            .ForMember(dest => dest.DomainEvents, opt => opt.Ignore())
            .ReverseMap();

        #endregion

        #region BookingTransformations

        CreateMap<BookingDto, Booking>()
            .ForMember(dest => dest.DomainEvents, opt => opt.Ignore())
            .ReverseMap();
        CreateMap<CreateBookingRequest, Booking>()
            .ForMember(dest => dest.Status, opt => opt.Ignore())
            .ForMember(dest => dest.Flight, opt => opt.Ignore())
            .ForMember(dest => dest.Passenger, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.DomainEvents, opt => opt.Ignore());

        #endregion

        #region AirplaneTransformations

        CreateMap<AirplaneDto, Airplane>()
            .ForMember(dest => dest.DomainEvents, opt => opt.Ignore())
            .ReverseMap();

        #endregion

        #region LocationTransformations

        CreateMap<LocationDto, Location>().ReverseMap();

        #endregion

        #region PassengerTransformations

        CreateMap<PassengerDto, Passenger>()
            .ForMember(dest => dest.Bookings, opt => opt.Ignore())
            .ForMember(dest => dest.DomainEvents, opt => opt.Ignore())
            .ReverseMap();

        #endregion

        #region ItineraryTransformations

        CreateMap<ItineraryDto, Itinerary>().ReverseMap();

        #endregion
    }
}