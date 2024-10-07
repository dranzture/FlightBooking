using System.Reflection;
using Ardalis.SharedKernel;
using Autofac;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces.Repository;
using Training.FlightBooking.Core.BookingAggregate;
using Training.FlightBooking.Core.BookingAggregate.Interfaces.Repository;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.FlightAggregate.Interfaces.Repository;
using Training.FlightBooking.Data.Repositories;
using Training.FlightBooking.Data.Repositories.FlightRepositories;
using Module = Autofac.Module;

namespace Training.FlightBooking.Data;

public class AutofacDataModule : Module
{
    private readonly bool _isDevelopment = false;
    private readonly List<Assembly> _assemblies = new List<Assembly>();

    public AutofacDataModule(bool isDevelopment, Assembly? callingAssembly = null)
    {
        _isDevelopment = isDevelopment;
        AddToAssembliesIfNotNull(callingAssembly);
    }

    protected override void Load(ContainerBuilder builder)
    {
        LoadAssemblies();
        if (_isDevelopment)
        {
            RegisterDevelopmentOnlyDependencies(builder);
        }
        else
        {
            RegisterProductionOnlyDependencies(builder);
        }

        RegisterEF(builder);
        RegisterRepositories(builder);
    }

    private void AddToAssembliesIfNotNull(Assembly? assembly)
    {
        if (assembly != null)
        {
            _assemblies.Add(assembly);
        }
    }

    private void LoadAssemblies()
    {
        
        var dataAssembly = Assembly.GetAssembly(typeof(AutofacDataModule));

        AddToAssembliesIfNotNull(dataAssembly);
    }


    private void RegisterEF(ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(EfRepository<>))
            .As(typeof(IRepository<>))
            .As(typeof(IReadRepository<>))
            .InstancePerLifetimeScope();
    }

    private void RegisterRepositories(ContainerBuilder builder)
    {
        builder.RegisterType<FlightRepository>().InstancePerLifetimeScope();
        builder.RegisterType<CachedFlightRepository>().As<IFlightRepository>();
        builder.RegisterType<AirplaneRepository>().As<IAirplaneRepository>();
        builder.RegisterType<BookingRepository>().As<IBookingRepository>();
    }

    private void RegisterDevelopmentOnlyDependencies(ContainerBuilder builder)
    {
        // NOTE: Add any development only services here
        //builder.RegisterType<FakeEmailSender>().As<IEmailSender>()
        //  .InstancePerLifetimeScope();
    }

    private void RegisterProductionOnlyDependencies(ContainerBuilder builder)
    {
        // NOTE: Add any production only (real) services here
    }
}