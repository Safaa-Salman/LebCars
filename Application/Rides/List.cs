using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Rides
{
    public class List
    {
        public class Query : IRequest<Result<List<RideDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<RideDto>>>
        {
            private readonly DataContext _context;
            private readonly ILogger<List> _logger;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<RideDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var rides = await _context.Rides
                    .ProjectTo<RideDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return Result<List<RideDto>>.Success(rides);
            }
        }
    }
}