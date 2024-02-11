using Autofac;
using Training.FlightBooking.Core.FlightAggregate.Interfaces;
using Training.FlightBooking.Core.BookingAggregate.Interfaces;
using Training.FlightBooking.Core.Services;

namespace Training.FlightBooking.Core;

public class AutofacCoreModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<IBookPassengerService>().As<BookPassengerService>().InstancePerLifetimeScope();
        builder.RegisterType<ICreateFlightService>().As<CreateFlightService>().InstancePerLifetimeScope();
        builder.RegisterType<IDeletePassengerBookService>().As<DeletePassengerBookService>().InstancePerLifetimeScope();
        builder.RegisterType<IUpdateFlightStatusService>().As<UpdateFlightStatusService>().InstancePerLifetimeScope();
        builder.RegisterType<ICreateBookingService>().As<CreateBookingService>().InstancePerLifetimeScope();
    }
}