using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Ratings
{
    public class GiveRating
    {
        public class Command : IRequest<Result<RatingDto>>
        {
            public string TargetId { get; set; }
            public string Feedback { get; set; }
            public string RatingValue { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.RatingValue).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Command, Result<RatingDto>>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IUserAccessor userAccessor, IMapper mapper)
            {
                _mapper = mapper;
                _userAccessor = userAccessor;
                _context = context;
            }

            public async Task<Result<RatingDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                var observer = await _context.Users.FirstOrDefaultAsync(x =>
                    x.UserName == _userAccessor.GetUsername());

                var target = await _context.Users.FirstOrDefaultAsync(x =>
                    x.Id == request.TargetId);
               

                if (target == null) return null;

                var rating = await _context.UserRatings.FindAsync(observer.Id, target.Id);

                if (rating == null)
                {
                    rating = new Rating
                    {
                        Observer = observer,
                        Target = target,
                        Feedback = request.Feedback,
                        RatingValue = request.RatingValue
                    };

                    _context.UserRatings.Add(rating);
                }
                else
                {
                    _context.UserRatings.Remove(rating);
                }

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Result<RatingDto>.Success(_mapper.Map<RatingDto>(rating));

                return Result<RatingDto>.Failure("Failed to give rating");
            }
        }

    }
}