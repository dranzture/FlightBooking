using System.Reflection;
using Ardalis.SharedKernel;
using Autofac;
using Training.FlightBooking.Core.BookingAggregate;
using Training.FlightBooking.Core.FlightAggregate;
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
    }
    
    private void AddToAssembliesIfNotNull(Assembly? assembly)
    {
        if(assembly != null)
        {
            _assemblies.Add(assembly);
        }
    }
    private void LoadAssemblies()
    {
        var flightAssembly = Assembly.GetAssembly(typeof(Flight));
        var bookingAssembly = Assembly.GetAssembly(typeof(Booking));
        var dataAssembly = Assembly.GetAssembly(typeof(AutofacDataModule));

        AddToAssembliesIfNotNull(flightAssembly);
        AddToAssembliesIfNotNull(bookingAssembly);
        AddToAssembliesIfNotNull(dataAssembly);
    }
    
    
    private void RegisterEF(ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(EfRepository<>))
            .As(typeof(IRepository<>))
            .As(typeof(IReadRepository<>))
            .InstancePerLifetimeScope();
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