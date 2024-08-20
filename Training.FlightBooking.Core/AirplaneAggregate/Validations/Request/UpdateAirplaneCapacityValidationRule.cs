using FluentValidation;
using Training.FlightBooking.Core.AirplaneAggregate.Requests;

namespace Training.FlightBooking.Core.AirplaneAggregate.Validations.Request;

public class UpdateAirplaneCapacityValidationRule : AbstractValidator<UpdateAirplaneCapacityRequest>
{
    public UpdateAirplaneCapacityValidationRule()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Capacity).GreaterThan(0).LessThan(250);
    }
}