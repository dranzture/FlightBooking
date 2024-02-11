using AutoMapper;
using Training.FlightBooking.Core.DTOs;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.ValueObjects;

namespace Training.FlightBooking.Core.Helpers;

public class MapperProfiles : Profile
{
    public MapperProfiles()
    {
        CreateMap<FlightDto, Flight>().ReverseMap();
        CreateMap<AirplaneDto, Airplane>().ReverseMap();
        CreateMap<LocationDto, Location>().ReverseMap();
        CreateMap<ItineraryDto, Itinerary>().ReverseMap();
    }
}