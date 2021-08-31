using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Rides
{
    public class UpdateAttendance
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;
            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                _userAccessor = userAccessor;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var ride = await _context.Rides
                    .Include(a => a.Attendees).ThenInclude(u => u.AppUser)
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (ride == null) return null;

                var user = await _context.Users.FirstOrDefaultAsync(x =>
                    x.UserName == _userAccessor.GetUsername());

                if (user == null) return null;

                var driverUsername = ride.Attendees.FirstOrDefault(x => x.IsDriver)?.AppUser?.UserName;

                var attendance = ride.Attendees.FirstOrDefault(x => x.AppUser.UserName == user.UserName);

                if (attendance != null && driverUsername == user.UserName)
                    ride.IsCancelled = !ride.IsCancelled;

                if(attendance != null && driverUsername != user.UserName)
                    ride.Attendees.Remove(attendance);

                if(attendance == null)
                {
                    attendance = new RideAttendee
                    {
                        AppUser = user,
                        Ride = ride,
                        IsDriver = false
                    };

                    ride.Attendees.Add(attendance);
                }

                var result = await _context.SaveChangesAsync() > 0;

                return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Problem updating attendance");
            }
        }
    }
}