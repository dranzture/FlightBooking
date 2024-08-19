using System.ComponentModel.DataAnnotations;

namespace Training.FlightBooking.Core.Shared;

public static class FormatHelper
{
    public static bool ValidateEmail(string email)
    {
        return new EmailAddressAttribute().IsValid(email);
    }
}