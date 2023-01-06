using DriverRating.Models;

namespace DriverRating.Data.Entities;

public class Rating
{
    public int Id { get; set; }
    
    public int DriverId { get; set; }

    public virtual Driver Driver { get; set; }
    
    public StarRating Convenience { get; set; }
    
    public StarRating DrivingSkills { get; set; }
    
    public StarRating DriverFriendliness { get; set; }

    public string? WorstExperience { get; set; }

    public string? AdditionalStuff { get; set; }
    public DateTime CreatedUtc { get; set; }
}