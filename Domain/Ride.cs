using System.Collections.Generic;
using System;

namespace Domain
{
    public class Ride
    {
        public Guid Id { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime departureDate { get; set; }
        public DateTime returnDate { get; set; }
        public string passengerNumber { get; set; }
        public string Cost { get; set; }
        public string Description { get; set; }
        public bool Children { get; set; }
        public bool Animals { get; set; }
        public bool Smoking { get; set; }
        public bool IsCancelled { get; set; }
        public ICollection<RideAttendee> Attendees {get; set;} = new List<RideAttendee>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        
    }
}