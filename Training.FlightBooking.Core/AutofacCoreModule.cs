using Autofac;
using MediatR;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces;
using Training.FlightBooking.Core.AirplaneAggregate.Services;
using Training.FlightBooking.Core.BookingAggregate.Events;
using Training.FlightBooking.Core.FlightAggregate.Interfaces;
using Training.FlightBooking.Core.BookingAggregate.Interfaces;
using Training.FlightBooking.Core.BookingAggregate.Services;
using Training.FlightBooking.Core.FlightAggregate.Handlers;
using Training.FlightBooking.Core.FlightAggregate.Services;

namespace Training.FlightBooking.Core;

public class AutofacCoreModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CreateAirplaneService>().As<ICreateAirplaneService>().InstancePerLifetimeScope();
        builder.RegisterType<UpdateAirplaneCapacityService>().As<IUpdateAirplaneCapacityService>()
            .InstancePerLifetimeScope();
        builder.RegisterType<UpdateAirplaneService>().As<IUpdateAirplaneService>()
            .InstancePerLifetimeScope();
        builder.RegisterAssemblyTypes(typeof(ICreateAirplaneValidationRule).Assembly)
            .Where(t => typeof(ICreateAirplaneValidationRule).IsAssignableFrom(t) && !t.IsAbstract)
            .AsImplementedInterfaces();
        
        builder.RegisterType<BookPassengerService>().As<IBookPassengerService>().InstancePerLifetimeScope();
        builder.RegisterType<RetrieveAllBookingsService>().As<IRetrieveAllBookingsService>().InstancePerLifetimeScope();
        builder.RegisterAssemblyTypes(typeof(IBookPassengerValidationRule).Assembly)
            .Where(t => typeof(IBookPassengerValidationRule).IsAssignableFrom(t) && !t.IsAbstract)
            .AsImplementedInterfaces();

        builder.RegisterType<DeletePassengerBookService>().As<IDeletePassengerBookService>().InstancePerLifetimeScope();

        builder.RegisterType<UpdateFlightAvailabilityService>().As<IUpdateFlightAvailabilityService>()
            .InstancePerLifetimeScope();
        builder.RegisterType<UpdateFlightStatusService>().As<IUpdateFlightStatusService>().InstancePerLifetimeScope();
        builder.RegisterType<CreateFlightService>().As<ICreateFlightService>().InstancePerLifetimeScope();

        builder.RegisterAssemblyTypes(typeof(ICreateFlightValidationRule).Assembly)
            .Where(t => typeof(ICreateFlightValidationRule).IsAssignableFrom(t) && !t.IsAbstract)
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