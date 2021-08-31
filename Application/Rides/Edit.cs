using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Rides
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Ride Ride { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Ride).SetValidator(new RideValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;

            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var ride = await _context.Rides.FindAsync(request.Ride.Id);

                if (ride == null) return null;

                _mapper.Map(request.Ride, ride); 

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to update ride");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}