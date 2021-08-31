using System;

namespace Domain
{
    public class RideAttendee
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public Guid RideId { get; set; }
        public Ride Ride { get; set; }
        public bool IsDriver { get; set; }
    }
}