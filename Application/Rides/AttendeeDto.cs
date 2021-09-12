namespace Application.Rides
{
    public class AttendeeDto
    {
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string CarModel{ get; set; }
        public string CarNumber { get; set; }
        public string PhoneNumber { get; set; }
        public bool Following { get; set; }
        public int FollowersCount { get; set; }
        public int FollowingCount { get; set; }

    }
}