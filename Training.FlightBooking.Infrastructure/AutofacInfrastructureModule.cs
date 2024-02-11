using System.Reflection;
using Ardalis.SharedKernel;
using Autofac;
using MediatR;
using MediatR.Pipeline;
using Training.FlightBooking.Core.BookingAggregate;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.BookingAggregate;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.PassengerAggregate;
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
    var flightAssembly = Assembly.GetAssembly(typeof(Flight)); 
    var bookingAssembly = Assembly.GetAssembly(typeof(Booking)); 
    var passengerAssembly = Assembly.GetAssembly(typeof(Passenger)); 
    var airplaneAssembly = Assembly.GetAssembly(typeof(Airplane)); 
    
    var infrastructureAssembly = Assembly.GetAssembly(typeof(AutofacInfrastructureModule));

    AddToAssembliesIfNotNull(flightAssembly);    
    AddToAssembliesIfNotNull(bookingAssembly);
    AddToAssembliesIfNotNull(passengerAssembly);
    AddToAssembliesIfNotNull(airplaneAssembly);
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
    RegisterMediatR(builder);
  }

  private void RegisterEF(ContainerBuilder builder)
  {
    builder.RegisterGeneric(typeof(EfRepository<>))
      .As(typeof(IRepository<>))
      .As(typeof(IReadRepository<>))
      .InstancePerLifetimeScope();
  }

  private void RegisterMediatR(ContainerBuilder builder)
  {
    builder
      .RegisterType<Mediator>()
      .As<IMediator>()
      .InstancePerLifetimeScope();

    builder
      .RegisterGeneric(typeof(LoggingBehavior<,>))
      .As(typeof(IPipelineBehavior<,>))
      .InstancePerLifetimeScope();

    builder
      .RegisterType<MediatRDomainEventDispatcher>()
      .As<IDomainEventDispatcher>()
      .InstancePerLifetimeScope();

    var mediatrOpenTypes = new[]
    {
      typeof(IRequestHandler<,>),
      typeof(IRequestExceptionHandler<,,>),
      typeof(IRequestExceptionAction<,>),
      typeof(INotificationHandler<>),
    };

    foreach (var mediatrOpenType in mediatrOpenTypes)
    {
      builder
        .RegisterAssemblyTypes(_assemblies.ToArray())
        .AsClosedTypesOf(mediatrOpenType)
        .AsImplementedInterfaces();
    }
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