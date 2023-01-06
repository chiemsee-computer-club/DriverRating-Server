using Npgsql.Replication.PgOutput;

namespace DriverRating.Data.Entities;

public class Driver
{
    public int Id { get; set; }
    public string ExternalId { get; set; }

    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }
    
    public virtual ICollection<Rating>? Ratings { get; }
}