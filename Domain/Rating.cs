namespace Domain
{
    public class Rating
    {
        public string ObserverId { get; set; }
        public AppUser Observer { get; set; }
        public string TargetId { get; set; }
        public AppUser Target { get; set; }
        public string Feedback { get; set; }
        public string RatingValue { get; set; }
    }
}