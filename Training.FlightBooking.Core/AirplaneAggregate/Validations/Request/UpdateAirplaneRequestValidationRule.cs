using FluentValidation;
using Training.FlightBooking.Core.AirplaneAggregate.Requests;

namespace Training.FlightBooking.Core.AirplaneAggregate.Validations.Request;

public class UpdateAirplaneRequestValidationRule : AbstractValidator<UpdateAirplaneRequest>
{
    public UpdateAirplaneRequestValidationRule()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Model).NotEmpty();
        RuleFor(x => x.Manufacturer).NotEmpty();
        RuleFor(x => x.Year).GreaterThan(0);
    }
}