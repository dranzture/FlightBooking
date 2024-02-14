﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Training.IntegrationTest.Infrastructure.Data;

#nullable disable

namespace Training.IntegrationTest.Infrastructure.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Training.FlightBooking.Core.AirplaneAggregate.Airplane", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Airplanes");
                });

            modelBuilder.Entity("Training.FlightBooking.Core.BookingAggregate.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("FlightId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PassengerId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FlightId");

                    b.HasIndex("PassengerId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Training.FlightBooking.Core.FlightAggregate.Flight", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AirplaneId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Arrival")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("AvailableSeats")
                        .HasColumnType("integer");

                    b.Property<int>("BookedSeats")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Departure")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AirplaneId")
                        .IsUnique();

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("Training.FlightBooking.Core.PassengerAggregate.Passenger", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("Training.FlightBooking.Core.BookingAggregate.Booking", b =>
                {
                    b.HasOne("Training.FlightBooking.Core.FlightAggregate.Flight", "Flight")
                        .WithMany()
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Training.FlightBooking.Core.PassengerAggregate.Passenger", "Passenger")
                        .WithMany("Booking")
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flight");

                    b.Navigation("Passenger");
                });

            modelBuilder.Entity("Training.FlightBooking.Core.FlightAggregate.Flight", b =>
                {
                    b.HasOne("Training.FlightBooking.Core.AirplaneAggregate.Airplane", "Airplane")
                        .WithOne()
                        .HasForeignKey("Training.FlightBooking.Core.FlightAggregate.Flight", "AirplaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Training.FlightBooking.Core.ValueObjects.Location", "From", b1 =>
                        {
                            b1.Property<Guid>("FlightId")
                                .HasColumnType("uuid");

                            b1.Property<string>("City")
                                .HasColumnType("text");

                            b1.Property<string>("State")
                                .HasColumnType("text");

                            b1.HasKey("FlightId");

                            b1.ToTable("Flights");

                            b1.WithOwner()
                                .HasForeignKey("FlightId");
                        });

                    b.OwnsOne("Training.FlightBooking.Core.ValueObjects.Location", "To", b1 =>
                        {
                            b1.Property<Guid>("FlightId")
                                .HasColumnType("uuid");

                            b1.Property<string>("City")
                                .HasColumnType("text");

                            b1.Property<string>("State")
                                .HasColumnType("text");

                            b1.HasKey("FlightId");

                            b1.ToTable("Flights");

                            b1.WithOwner()
                                .HasForeignKey("FlightId");
                        });

                    b.Navigation("Airplane");

                    b.Navigation("From")
                        .IsRequired();

                    b.Navigation("To")
                        .IsRequired();
                });

            modelBuilder.Entity("Training.FlightBooking.Core.PassengerAggregate.Passenger", b =>
                {
                    b.Navigation("Booking");
                });
#pragma warning restore 612, 618
        }
    }
}
