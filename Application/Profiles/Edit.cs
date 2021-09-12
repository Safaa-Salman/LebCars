using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Profiles
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public string DisplayName { get; set; }
            public string Bio { get; set; }
            public string Age { get; set; }
            public string Gender { get; set; }
            public string CarModel{ get; set; }
            public string CarNumber { get; set; }
            public string PhoneNumber { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.DisplayName).NotEmpty();
            }
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
            public async Task<Result<Unit>> Handle(Command request,CancellationToken cancellationToken)
            {
                var user = await _context.Users.FirstOrDefaultAsync(x =>
                x.UserName == _userAccessor.GetUsername());

                user.Bio = request.Bio ?? user.Bio;
                user.DisplayName = request.DisplayName ?? user.DisplayName;
                user.Age = request.Age ?? user.Age;
                user.Gender = request.Gender ?? user.Gender;
                user.CarModel = request.CarModel ?? user.CarModel;
                user.CarNumber = request.CarNumber ?? user.CarNumber;
                user.PhoneNumber = request.PhoneNumber ?? user.PhoneNumber;
                _context.Entry(user).State = EntityState.Modified;
                
                var success = await _context.SaveChangesAsync() > 0;
                if (success) return Result<Unit>.Success(Unit.Value);
                return Result<Unit>.Failure("Problem updating profile");
            }
        }
    }
}