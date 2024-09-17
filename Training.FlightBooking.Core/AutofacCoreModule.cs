using System.Reflection;
using Autofac;
using MediatR;
using Training.FlightBooking.Core.AirplaneAggregate;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces.Validations;
using Training.FlightBooking.Core.AirplaneAggregate.Services;
using Training.FlightBooking.Core.BookingAggregate;
using Training.FlightBooking.Core.BookingAggregate.Events;
using Training.FlightBooking.Core.FlightAggregate.Interfaces;
using Training.FlightBooking.Core.BookingAggregate.Interfaces;
using Training.FlightBooking.Core.BookingAggregate.Interfaces.Services;
using Training.FlightBooking.Core.BookingAggregate.Interfaces.Validations;
using Training.FlightBooking.Core.BookingAggregate.Services;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.FlightAggregate.Handlers;
using Training.FlightBooking.Core.FlightAggregate.Interfaces.Services;
using Training.FlightBooking.Core.FlightAggregate.Interfaces.Validations;
using Training.FlightBooking.Core.FlightAggregate.Services;
using Module = Autofac.Module;

namespace Training.FlightBooking.Core;

public class AutofacCoreModule : Module
{    
    private readonly List<Assembly> _assemblies = new List<Assembly>();

    private void AddToAssembliesIfNotNull(Assembly? assembly)
    {
        if (assembly != null)
        {
            _assemblies.Add(assembly);
        }
    }
    
    private void LoadAssemblies()
    {
        
        var flightAssembly = Assembly.GetAssembly(typeof(Flight));
        var airplaneAssembly = Assembly.GetAssembly(typeof(Airplane));
        var bookingAssembly = Assembly.GetAssembly(typeof(Booking));
        var coreAssembly = Assembly.GetAssembly(typeof(AutofacCoreModule));

        AddToAssembliesIfNotNull(flightAssembly);
        AddToAssembliesIfNotNull(airplaneAssembly);
        AddToAssembliesIfNotNull(bookingAssembly);
        AddToAssembliesIfNotNull(coreAssembly);
    }
    
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CreateAirplaneService>()
            .As<ICreateAirplaneService>()
            .InstancePerLifetimeScope();
        builder.RegisterType<ListAirplanesService>()
            .As<IListAirplanesService>()
            .InstancePerLifetimeScope();
        builder.RegisterType<GetAirplaneService>()
            .As<IGetAirplaneService>()
            .InstancePerLifetimeScope();
        builder.RegisterType<UpdateAirplaneCapacityService>()
            .As<IUpdateAirplaneCapacityService>()
            .InstancePerLifetimeScope();
        builder.RegisterType<UpdateAirplaneService>()
            .As<IUpdateAirplaneService>()
            .InstancePerLifetimeScope();
        builder.RegisterAssemblyTypes(typeof(ICreateAirplaneValidationRule).Assembly)
            .Where(t => typeof(ICreateAirplaneValidationRule).IsAssignableFrom(t) && !t.IsAbstract)
            .AsImplementedInterfaces();
        builder.RegisterAssemblyTypes(typeof(IUpdateAirplaneValidationRule).Assembly)
            .Where(t => typeof(IUpdateAirplaneValidationRule).IsAssignableFrom(t) && !t.IsAbstract)
            .AsImplementedInterfaces();
        builder.RegisterAssemblyTypes(typeof(IUpdateAirplaneCapacityValidationRule).Assembly)
            .Where(t => typeof(IUpdateAirplaneCapacityValidationRule).IsAssignableFrom(t) && !t.IsAbstract)
            .AsImplementedInterfaces();
        
        
        builder.RegisterType<BookPassengersService>()
            .As<IBookPassengersService>()
            .InstancePerLifetimeScope();
        builder.RegisterType<GetBookingService>()
            .As<IGetBookingService>()
            .InstancePerLifetimeScope();
        builder.RegisterType<ListBookingsService>()
            .As<IListBookingsService>()
            .InstancePerLifetimeScope();
        builder.RegisterType<CancelBookingService>()
            .As<ICancelBookingService>()
            .InstancePerLifetimeScope();
        builder.RegisterAssemblyTypes(typeof(IBookPassengerValidationRule).Assembly)
            .Where(t => typeof(IBookPassengerValidationRule).IsAssignableFrom(t) && !t.IsAbstract)
            .AsImplementedInterfaces();
        builder.RegisterAssemblyTypes(typeof(ICancelBookingValidationRule).Assembly)
            .Where(t => typeof(ICancelBookingValidationRule).IsAssignableFrom(t) && !t.IsAbstract)
            .AsImplementedInterfaces();
        builder.RegisterAssemblyTypes(typeof(IDeletePassengerBookingValidationRule).Assembly)
            .Where(t => typeof(IDeletePassengerBookingValidationRule).IsAssignableFrom(t) && !t.IsAbstract)
            .AsImplementedInterfaces();
        

        builder.RegisterType<UpdateFlightAvailabilityService>()
            .As<IUpdateFlightAvailabilityService>()
            .InstancePerLifetimeScope();
        builder.RegisterType<UpdateFlightStatusService>()
            .As<IUpdateFlightStatusService>()
            .InstancePerLifetimeScope();
        builder.RegisterType<CreateFlightService>()
            .As<ICreateFlightService>()
            .InstancePerLifetimeScope();
        builder.RegisterType<ListFlightsService>()
            .As<IListFlightsService>()
            .InstancePerLifetimeScope();
        builder.RegisterAssemblyTypes(typeof(ICreateFlightValidationRule).Assembly)
            .Where(t => typeof(ICreateFlightValidationRule).IsAssignableFrom(t) && !t.IsAbstract)
            .AsImplementedInterfaces();
        builder.RegisterAssemblyTypes(typeof(IUpdateFlightValidationRule).Assembly)
            .Where(t => typeof(IUpdateFlightValidationRule).IsAssignableFrom(t) && !t.IsAbstract)
            .AsImplementedInterfaces();
        
        AddMediatRHandlers(builder);
    }

    private void AddMediatRHandlers(ContainerBuilder builder)
    {
        builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();
        builder.RegisterType<PassengerBookedFlightHandler>().As<INotificationHandler<PassengerBookedFlight>>();
        builder.RegisterType<PassengerCanceledFlightHandler>().As<INotificationHandler<PassengerCanceledFlight>>();
    }
}