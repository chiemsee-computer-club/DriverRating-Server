using DriverRating.Data.Entities;
using DriverRating.Dtos;

namespace DriverRating.Extensions;

public static class RatingExtensions
{
    public static Rating ToDbModel(this RatingDto ratingDto, int driverId)
    {
        return new Rating
        {
            DriverId = driverId,
            AdditionalStuff = ratingDto.AdditionalStuff,
            Convenience = ratingDto.Convenience,
            DriverFriendliness = ratingDto.DriverFriendliness,
            DrivingSkills = ratingDto.DrivingSkills,
            WorstExperience = ratingDto.WorstExperience,
            CreatedUtc = ratingDto.CreatedUtc
        };
    }

    public static RatingDto ToDto(this Rating ratingEntity)
    {
        return new RatingDto
        {
            Convenience = ratingEntity.Convenience,
            AdditionalStuff = ratingEntity.AdditionalStuff,
            DriverFriendliness = ratingEntity.DriverFriendliness,
            DrivingSkills = ratingEntity.DrivingSkills,
            WorstExperience = ratingEntity.WorstExperience,
            CreatedUtc = ratingEntity.CreatedUtc
        };
    }

}