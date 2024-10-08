﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training.FlightBooking.Core.BookingAggregate;

namespace Training.FlightBooking.Data.Data.Configurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.HasOne(e => e.Flight)
            .WithMany()
            .HasForeignKey(e => e.FlightId);
        
        builder.HasOne(e=>e.Passenger)
            .WithMany(e=>e.Bookings)
            .HasForeignKey(e => e.PassengerId);
        
        builder.Property(e => e.Status)
            .HasConversion(e => e.Value, 
                e => BookingStatus.FromValue(e));
    }
}