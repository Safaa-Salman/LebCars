using System;
using System.Text.Json.Serialization;

namespace Application.Profiles
{
    public class UserRideDto
    {
        public Guid Id { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime departureDate { get; set; }
        public DateTime returnDate { get; set; }

        [JsonIgnore]
        public string DriverUsername { get; set; }
    }
}