using DriverRating.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DriverRating.Data.Mappings;

public class RatingMapping : IEntityTypeConfiguration<Rating>
{
    public void Configure(EntityTypeBuilder<Rating> builder)
    {
        builder.HasOne(x => x.Driver)
            .WithMany(x => x.Ratings);
    }
}