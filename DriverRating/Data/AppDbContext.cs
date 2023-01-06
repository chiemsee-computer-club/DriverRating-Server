using DriverRating.Data.Entities;
using DriverRating.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace DriverRating.Data;

public class AppDbContext : DbContext
{
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<Driver> Drivers { get; set; }
        
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DriverMapping());
        modelBuilder.ApplyConfiguration(new RatingMapping());
    }
}