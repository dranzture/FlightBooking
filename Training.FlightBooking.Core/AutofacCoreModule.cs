using Autofac;
using Training.FlightBooking.Core.FlightAggregate.Interfaces;
using Training.FlightBooking.Core.BookingAggregate.Interfaces;
using Training.FlightBooking.Core.Services;

namespace Training.FlightBooking.Core;

public class AutofacCoreModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<BookPassengerService>().As<IBookPassengerService>().InstancePerLifetimeScope();
        builder.RegisterType<CreateFlightService>().As<ICreateFlightService>().InstancePerLifetimeScope();
        builder.RegisterType<DeletePassengerBookService>().As<IDeletePassengerBookService>().InstancePerLifetimeScope();
        builder.RegisterType<UpdateFlightStatusService>().As<IUpdateFlightStatusService>().InstancePerLifetimeScope();
        builder.RegisterType<CreateBookingService>().As<ICreateBookingService>().InstancePerLifetimeScope();
    }
}