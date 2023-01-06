using DriverRating.Data.Entities;
using DriverRating.Dtos;
using DriverRating.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DriverRating.Data;

public class AppDbRepository : IAppDbRepository
{
    private readonly AppDbContext _dbContext;

    public AppDbRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddRatingAsync(string externalDriverId, RatingDto ratingDto)
    {
        var driver = await GetDriverByExternalIdAsync(externalDriverId);

        var rating = ratingDto.ToDbModel(driver.Id);
        rating.CreatedUtc = DateTime.UtcNow;

        await _dbContext.Ratings.AddAsync(rating);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Rating>?> GetRatingsAsync(string driverId)
    {
        var driver = await GetDriverByExternalIdAsync(driverId);
        return driver.Ratings?.ToList();
    }

    private async Task<Driver> GetDriverByExternalIdAsync(string externalId)
    {
        return await _dbContext.Drivers
            .Include(x => x.Ratings)
            .SingleAsync(x => x.ExternalId == externalId);
    }
}