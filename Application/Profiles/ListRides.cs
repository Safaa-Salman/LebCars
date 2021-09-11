using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Profiles
{
    public class ListRides
    {
        public class Query : IRequest<Result<List<UserRideDto>>>
        {
            public string Username { get; set; }
            public string Predicate { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<UserRideDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<UserRideDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.RideAttendees
                    .Where(u => u.AppUser.UserName == request.Username)
                    .OrderBy(a => a.Ride.departureDate)
                    .ProjectTo<UserRideDto>(_mapper.ConfigurationProvider)
                    .AsQueryable();

                query = request.Predicate switch
                {
                    "past" => query.Where(a => a.departureDate <= DateTime.Now | a.returnDate <= DateTime.Now),
                    "hosting" => query.Where(a => a.DriverUsername == request.Username),
                    _ => query.Where(a => a.departureDate >= DateTime.Now | a.returnDate >= DateTime.Now)
                };

                var rides = await query.ToListAsync();

                return Result<List<UserRideDto>>.Success(rides);
            }
        }
    }
}