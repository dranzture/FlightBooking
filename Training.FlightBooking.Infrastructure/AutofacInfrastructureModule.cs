using System.Reflection;
using Autofac;
using Training.FlightBooking.Infrastructure.Interfaces;
using Training.FlightBooking.Infrastructure.Services;
using Module = Autofac.Module;

// ReSharper disable once CheckNamespace
namespace Training.FlightBooking.Infrastructure;

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
    DomainEventDispatcher(builder);
  }


  private void DomainEventDispatcher(ContainerBuilder builder)
  {
    builder
      .RegisterType<DomainEventDispatcher>()
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