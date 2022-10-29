using Infrastructure.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Data;

public class MeFitDbContext : DbContext
{
    public DbSet<Goal> Goals { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Models.Domain.Program> Programs { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<CompletedWorkout> CompletedWorkouts { get; set; }
    public DbSet<User> Users { get; set; }

    public DbSet<Exercise> Exercises { get; set; }



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
        var valueComparer = new ValueComparer<ICollection<MuscleEnum>>(
            (c1, c2) => c1.SequenceEqual(c2),
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
            c => (ICollection<MuscleEnum>)c.ToHashSet());
        
        builder
            .Entity<Exercise>()
            .Property(e => e.MuscleGroups)
            .HasConversion(
                v => string.Join(",", v.Select(e => e.ToString("D")).ToArray()),
                v => v.Split(new[] { ',' })
                    .Select(e =>  Enum.Parse(typeof(MuscleEnum), e))
                    .Cast<MuscleEnum>()
                    .ToList()
            ).Metadata.SetValueComparer(valueComparer);
        
        
        builder.Entity<CompletedWorkout>()
            .HasOne(c => c.Workout)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Models.Domain.Program>()
            .HasOne(p => p.Contributor)
            .WithMany(c => c.ProgramsContributed)
            .OnDelete(DeleteBehavior.NoAction);

        // Fixing some cascading with many-to-many relationship
        builder.Entity<Exercise>()
            .HasMany(p => p.Workouts)
            .WithMany(p => p.Exercises)
            .UsingEntity<Dictionary<string, object>>(
                "ExerciseWorkout",
                j => j
                    .HasOne<Workout>()
                    .WithMany()
                    .HasForeignKey("WorkoutId")
                    .HasConstraintName("FK_ExerciseWorkout_Workouts_ExerciseId")
                    .OnDelete(DeleteBehavior.NoAction),
                j => j
                    .HasOne<Exercise>()
                    .WithMany()
                    .HasForeignKey("ExerciseId")
                    .HasConstraintName("FK_ExerciseWorkout_Exercises_WorkoutId")
                    .OnDelete(DeleteBehavior.NoAction));
        
        builder.Entity<Models.Domain.Program>()
            .HasMany(p => p.Workouts)
            .WithMany(p => p.Programs)
            .UsingEntity<Dictionary<string, object>>(
                "ProgramWorkout",
                j => j
                    .HasOne<Workout>()
                    .WithMany()
                    .HasForeignKey("WorkoutId")
                    .HasConstraintName("FK_ProgramWorkout_Workouts_ProgramId")
                    .OnDelete(DeleteBehavior.NoAction),
                j => j
                    .HasOne<Models.Domain.Program>()
                    .WithMany()
                    .HasForeignKey("ProgramId")
                    .HasConstraintName("FK_ProgramWorkout_Programs_WorkoutId")
                    .OnDelete(DeleteBehavior.NoAction));


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