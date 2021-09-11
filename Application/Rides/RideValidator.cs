using Domain;
using FluentValidation;

namespace Application.Rides
{
    public class RideValidator : AbstractValidator<Ride>
    {
        public RideValidator()
        {
            RuleFor(x => x.Departure).NotEmpty();
            RuleFor(x => x.Destination).NotEmpty();
            RuleFor(x => x.departureDate).NotEmpty();
            RuleFor(x => x.returnDate).NotEmpty();
            RuleFor(x => x.passengerNumber).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Cost).NotEmpty();
            RuleFor(x => x.Children).NotEmpty();
            RuleFor(x => x.Animals).NotEmpty();
            RuleFor(x => x.Smoking).NotEmpty();
        }
    }
}