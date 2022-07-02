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
        public string Children { get; set; }
        public string Animals { get; set; }
        public string Smoking { get; set; }
        public string Baggage { get; set; }
        public string BaggageCost { get; set; }
        public bool IsCancelled { get; set; }
        public ICollection<RideAttendee> Attendees {get; set;} = new List<RideAttendee>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        
    }
}