using System;
using System.Collections.Generic;
using Application.Profiles;

namespace Application.Rides
{
    public class RideDto
    {
        public Guid Id { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime departureDate { get; set; }
        public DateTime returnDate { get; set; }
        public string passengerNumber { get; set; }
        public string Cost { get; set; }
        public bool Children { get; set; }
        public bool Animals { get; set; }
        public bool Smoking { get; set; }
        public string DriverUsername { get; set; }
        public bool IsCancelled { get; set; }
        public ICollection<AttendeeDto> Attendees { get; set; }
    }
}