using Domain;

namespace Application.Ratings
{
    public class RatingDto
    {
        public string ObserverId { get; set; }
        public string TargetId { get; set; }
        public string Feedback { get; set; }
        public string RatingValue { get; set; }
        public string ObserverUsername { get; set; }
        public string ObserverDisplayName { get; set; }
        public string TargetUsername { get; set; }
        public string TargetDisplayName { get; set; }
    }
}