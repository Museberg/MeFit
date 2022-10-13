using Infrastructure.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Bogus;
using Infrastructure.Models.Domain.Exercises;

namespace Infrastructure.Data;

public class MeFitDbContext : DbContext
{
    public DbSet<Goal> Goals { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Models.Domain.Program> Programs { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<User> Users { get; set; }

    // Exercises:
    public DbSet<TimedExercise> TimedExercises { get; set; }
    public DbSet<RepExercise> RepExercises { get; set; }
    public DbSet<CardioExercise> CardioExercises { get; set; }


    public MeFitDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public MeFitDbContext()
    {
        
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<DateOnly>()
            .HaveConversion<DateOnlyConverter>()
            .HaveColumnType("date");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {

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