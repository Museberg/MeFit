using Infrastructure.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data;

public class MeFitDbContext : DbContext
{
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<Goal> Goals { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Models.Domain.Program> Programs { get; set; }
    public DbSet<Set> Sets { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Workout> Workouts { get; set; }

    public MeFitDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<DateOnly>()
            .HaveConversion<DateOnlyConverter>()
            .HaveColumnType("date");
    }
    
    /// <summary>
    /// Converts <see cref="DateOnly" /> to <see cref="DateTime"/> and vice versa.
    /// </summary>
    public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        /// <summary>
        /// Creates a new instance of this converter.
        /// </summary>
        public DateOnlyConverter() : base(
            d => d.ToDateTime(TimeOnly.MinValue),
            d => DateOnly.FromDateTime(d))
        { }
    }
}