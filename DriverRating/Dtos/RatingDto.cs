using DriverRating.Models;

namespace DriverRating.Dtos;

public class RatingDto
{
    public StarRating Convenience { get; set; }
    
    public StarRating DrivingSkills { get; set; }

    public StarRating DriverFriendliness { get; set; }

    public string? WorstExperience { get; set; }

    public string? AdditionalStuff { get; set; }

    public DateTime CreatedUtc { get; set; }
}