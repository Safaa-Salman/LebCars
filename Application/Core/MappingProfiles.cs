using System.Linq;
using Application.Rides;
using Application.Comments;
using Application.Profiles;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : AutoMapper.Profile
    {
        public MappingProfiles()
        {
            string currentUsername = null;
            CreateMap<Ride, Ride>();
            CreateMap<Ride, RideDto>()
                .ForMember(d => d.DriverUsername, o => o.MapFrom(s => s.Attendees
                    .FirstOrDefault(x => x.IsDriver).AppUser.UserName));
            CreateMap<RideAttendee, AttendeeDto>()
                .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.AppUser.DisplayName))
                .ForMember(d => d.Username, o => o.MapFrom(s => s.AppUser.UserName))
                .ForMember(d => d.Bio, o => o.MapFrom(s => s.AppUser.Bio))
                .ForMember(d => d.Age, o => o.MapFrom(s => s.AppUser.Age))
                .ForMember(d => d.Gender, o => o.MapFrom(s => s.AppUser.Gender))
                .ForMember(d => d.CarModel, o => o.MapFrom(s => s.AppUser.CarModel))
                .ForMember(d => d.CarNumber, o => o.MapFrom(s => s.AppUser.CarNumber))
                .ForMember(d => d.PhoneNumber, o => o.MapFrom(s => s.AppUser.PhoneNumber))
                .ForMember(d => d.Image, o => o.MapFrom(s => s.AppUser.Photos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember(d => d.FollowersCount, o => o.MapFrom(s => s.AppUser.Followers.Count))
                .ForMember(d => d.FollowingCount, o => o.MapFrom(s => s.AppUser.Followings.Count))
                .ForMember(d => d.Following,
                    o => o.MapFrom(s => s.AppUser.Followers.Any(x => x.Observer.UserName == currentUsername)));
            CreateMap<AppUser, Profiles.Profile>()
                .ForMember(d => d.Image, o => o.MapFrom(s => s.Photos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember(d => d.FollowersCount, o => o.MapFrom(s => s.Followers.Count))
                .ForMember(d => d.FollowingCount, o => o.MapFrom(s => s.Followings.Count))
                .ForMember(d => d.Following,
                    o => o.MapFrom(s => s.Followers.Any(x => x.Observer.UserName == currentUsername)));
            CreateMap<Comment, CommentDto>()
                .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.Author.DisplayName))
                .ForMember(d => d.Username, o => o.MapFrom(s => s.Author.UserName))
                .ForMember(d => d.Image, o => o.MapFrom(s => s.Author.Photos.FirstOrDefault(x => x.IsMain).Url));
            CreateMap<RideAttendee, UserRideDto>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Ride.Id))
                .ForMember(d => d.Departure, o => o.MapFrom(s => s.Ride.Departure))
                .ForMember(d => d.Destination, o => o.MapFrom(s => s.Ride.Destination))
                .ForMember(d => d.departureDate, o => o.MapFrom(s => s.Ride.departureDate))
                .ForMember(d => d.returnDate, o => o.MapFrom(s => s.Ride.returnDate))
                .ForMember(d => d.DriverUsername, o => o.MapFrom(s => 
                    s.Ride.Attendees.FirstOrDefault(x => x.IsDriver).AppUser.UserName));
        }
    }
}