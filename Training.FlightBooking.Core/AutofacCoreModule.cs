using Autofac;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces;
using Training.FlightBooking.Core.FlightAggregate.Interfaces;
using Training.FlightBooking.Core.BookingAggregate.Interfaces;
using Training.FlightBooking.Core.Services;

namespace Training.FlightBooking.Core;

public class AutofacCoreModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CreateAirplaneService>().As<ICreateAirplaneService>().InstancePerLifetimeScope();
        builder.RegisterType<UpdateAirplaneCapacityService>().As<IUpdateAirplaneCapacityService>().InstancePerLifetimeScope();
        
        builder.RegisterType<BookPassengerService>().As<IBookPassengerService>().InstancePerLifetimeScope();
        builder.RegisterType<RetrieveAllBookingsService>().As<IRetrieveAllBookingsService>().InstancePerLifetimeScope();
        builder.RegisterType<DeletePassengerBookService>().As<IDeletePassengerBookService>().InstancePerLifetimeScope();
        
        builder.RegisterType<UpdateFlightStatusService>().As<IUpdateFlightStatusService>().InstancePerLifetimeScope();
        builder.RegisterType<CreateFlightService>().As<ICreateFlightService>().InstancePerLifetimeScope();
        builder.RegisterAssemblyTypes(typeof(ICreateFlightValidationRule).Assembly)
            .Where(t => typeof(ICreateFlightValidationRule).IsAssignableFrom(t) && !t.IsAbstract)
            .AsImplementedInterfaces();
    }
}