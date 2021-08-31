using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Rides
{
    public class Details
    {
        public class Query : IRequest<Result<RideDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<RideDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;

            }
            public async Task<Result<RideDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var ride = await _context.Rides
                    .ProjectTo<RideDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x=> x.Id == request.Id);

                return Result<RideDto>.Success(ride);
            }
        }

    }
}