using System.Reflection;
using Ardalis.SharedKernel;
using Autofac;
using MediatR;
using MediatR.Pipeline;
using Training.FlightBooking.Core.BookingAggregate;
using Training.FlightBooking.Core.FlightAggregate;
using IDomainEventDispatcher = Training.IntegrationTest.Infrastructure.Interfaces.IDomainEventDispatcher;
using MediatRDomainEventDispatcher = Training.FlightBooking.Core.Shared.MediatRDomainEventDispatcher;
using Module = Autofac.Module;

namespace Training.IntegrationTest.Infrastructure;

public class AutofacInfrastructureModule : Module
{
    private readonly bool _isDevelopment = false;
  private readonly List<Assembly> _assemblies = new List<Assembly>();

  public AutofacInfrastructureModule(bool isDevelopment, Assembly? callingAssembly = null)
  {
    _isDevelopment = isDevelopment;
    AddToAssembliesIfNotNull(callingAssembly);
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
    // TODO: Replace these types with any type in the appropriate assembly/project
    var flightAssembly = Assembly.GetAssembly(typeof(Flight));
    var bookingAssembly = Assembly.GetAssembly(typeof(Booking));
    
    var infrastructureAssembly = Assembly.GetAssembly(typeof(AutofacInfrastructureModule));

    AddToAssembliesIfNotNull(flightAssembly);
    AddToAssembliesIfNotNull(bookingAssembly);
    AddToAssembliesIfNotNull(infrastructureAssembly);
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
    DomainEventDispatcher(builder);
  }

  private void RegisterEF(ContainerBuilder builder)
  {
    builder.RegisterGeneric(typeof(EfRepository<>))
      .As(typeof(IRepository<>))
      .As(typeof(IReadRepository<>))
      .InstancePerLifetimeScope();
  }

  private void DomainEventDispatcher(ContainerBuilder builder)
  {
    builder
      .RegisterType<MediatRDomainEventDispatcher>()
      .As<IDomainEventDispatcher>()
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