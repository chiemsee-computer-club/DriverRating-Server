using DriverRating.Data.Entities;
using DriverRating.Dtos;

namespace DriverRating.Data;

public interface IAppDbRepository
{
    public Task AddRatingAsync(string externalDriverId, RatingDto ratingDto);
    public Task<IEnumerable<Rating>?> GetRatingsAsync(string driverId);
}