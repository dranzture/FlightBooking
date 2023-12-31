﻿using Ardalis.GuardClauses;
using Ardalis.SharedKernel;

namespace Training.IntegrationTest.Core.PassengerAggregate;

public class Passenger : EntityBase<Guid>, IAggregateRoot
{
    public Passenger(string firstName, string lastName, string email, DateTime dateOfBirth)
    {
        FirstName = Guard.Against.NullOrEmpty(firstName);
        LastName = Guard.Against.NullOrEmpty(lastName);
        Email = ValidateEmail(email);
        DateOfBirth = Guard.Against.OutOfSQLDateRange(dateOfBirth);
        Id = Guid.NewGuid();
    }
    
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public DateTime DateOfBirth { get; private set; }

    private string ValidateEmail(string email)
    {
        Guard.Against.InvalidFormat(email, nameof(email),@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$","Invalid email format");
        return email;
    }

    public void UpdateEmail(string email)
    {
        Email = ValidateEmail(email);
    }
    
}