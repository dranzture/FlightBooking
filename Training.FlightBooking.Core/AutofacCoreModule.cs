using Autofac;
using Training.IntegrationTest.Core.BookingAggregate.Interfaces;
using Training.IntegrationTest.Core.FlightAggregate.Interfaces;
using Training.IntegrationTest.Core.Services;

namespace Training.IntegrationTest.Core;

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