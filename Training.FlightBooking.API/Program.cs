using Ardalis.GuardClauses;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FastEndpoints;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using Training.FlightBooking.API.Helpers;
using Training.FlightBooking.Core;
using Training.FlightBooking.Data;
using Training.FlightBooking.Data.Data;
using Training.IntegrationTest.Infrastructure;
using Training.IntegrationTest.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new AutofacCoreModule());
    containerBuilder.RegisterModule(new AutofacInfrastructureModule(builder.Environment.IsDevelopment()));
    containerBuilder.RegisterModule(new AutofacDataModule(builder.Environment.IsDevelopment()));
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Guard.Against.Null(connectionString);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" }); });

builder.Services.AddAutoMapper(typeof(MapperProfiles));

builder.Services.AddFastEndpoints();
builder.Services.AddValidatorsFromAssemblyContaining<IValidator>();
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

// Accessing the Autofac service provider
//var autofacServiceProvider = app.Services.GetAutofacRoot();

// Console.WriteLine("Autofac DI container includes the following components:");
// // Now, enumerate the ComponentRegistry
// foreach (var registration in autofacServiceProvider.ComponentRegistry.Registrations)
// {
//     foreach (var service in registration.Services)
//     {
//         if (service is TypedService typedService)
//         {
//             Console.WriteLine(typedService.ServiceType.FullName);
//         }
//     }
// }

//This is a debugger tool of AutoMapper to validate which fields are mapped
app.ValidateAutoMapper();

app.UseFastEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.AddInitialSetups();

app.InitializeData();

app.Run();

//Integration Test Utilizes this partial class.
//Even though it is a 'hack', many other Microsoft MVP developers suggest this approach.
public partial class Program{}