using Bogus;
using Infrastructure.Models.Domain;

namespace Infrastructure.Data;

public class FakeData
{
    private static Random Random = new();
    private static int Seed = 8675309;
    
    public static List<Profile> Profiles = new();

    public static void Init(int count)
    {
        Randomizer.Seed = new Random(Seed);
        DateOnly constantDateOnly = new DateOnly(2022, 10, 10);
        var exercises = new[]
        {
            "Squat", "Leg press", "Lunge", "Deadlift", "Leg extension", "Leg curl", "Standing calf raise", 
            "Seated calf raise", "Bench press", "Chest fly", "Push-ups", "Pull-down", "Pull-up", "Shoulder press",
            "Shoulder shrug", "Pushdown", "Triceps extension", "Biceps curl", "Crunch", "Leg raise", "Back extension" 
        };
        var muscleGroups = new[]
        {
            "Calves", "Quadricpes", "Hamstrings", "Gluteus", "Lower back", "Lats", "Abdominals", "Triceps", "Biceps", "Forearms"
        };
        var videoLinks = new[]
        {
            "https://www.youtube.com/watch?v=T8jI4RnHHf0&list=PLD-MFRMx69csS6yj3LpSBGN1dGJel7Evc",
            "https://www.youtube.com/watch?v=kYsA9-Qbtyk&list=PLD-MFRMx69csS6yj3LpSBGN1dGJel7Evc&index=2",
            "https://www.youtube.com/watch?v=kYsA9-Qbtyk&list=PLD-MFRMx69csS6yj3LpSBGN1dGJel7Evc&index=3",
            "https://www.youtube.com/watch?v=kYsA9-Qbtyk&list=PLD-MFRMx69csS6yj3LpSBGN1dGJel7Evc&index=4",
            "https://www.youtube.com/watch?v=kYsA9-Qbtyk&list=PLD-MFRMx69csS6yj3LpSBGN1dGJel7Evc&index=5",
            "https://www.youtube.com/watch?v=kYsA9-Qbtyk&list=PLD-MFRMx69csS6yj3LpSBGN1dGJel7Evc&index=6",
            "https://www.youtube.com/watch?v=kYsA9-Qbtyk&list=PLD-MFRMx69csS6yj3LpSBGN1dGJel7Evc&index=7",
            "https://www.youtube.com/watch?v=kYsA9-Qbtyk&list=PLD-MFRMx69csS6yj3LpSBGN1dGJel7Evc&index=8",
            "https://www.youtube.com/watch?v=kYsA9-Qbtyk&list=PLD-MFRMx69csS6yj3LpSBGN1dGJel7Evc&index=9",
        };
        
        
        var fakeAddresses = new Faker<Address>()
            .StrictMode(true)
            .RuleFor(a => a.AddressId, f => 0)
            .RuleFor(a => a.AddressLine1, f => f.Address.StreetName())
            .RuleFor(a => a.AddressLine2, f => f.Address.SecondaryAddress())
            .RuleFor(a => a.AddressLine3, f => string.Empty)
            .RuleFor(a => a.PostalCode, f => f.Address.ZipCode())
            .RuleFor(a => a.City, f => f.Address.City())
            .RuleFor(a => a.Country, f => f.Address.Country());

        var fakeExercises = new Faker<Exercise>()
            .StrictMode(true)
            .RuleFor(e => e.ExerciseId, f => 0)
            .RuleFor(e => e.Name, f => f.PickRandom(exercises))
            .RuleFor(e => e.Description, f => f.Lorem.Paragraph())
            .RuleFor(e => e.TargetMuscleGroup, f => f.PickRandom(muscleGroups))
            .RuleFor(e => e.ImageLink, f => f.Image.PlaceImgUrl(category: "people"))
            .RuleFor(e => e.VideoLink, f => f.PickRandom(videoLinks));
        
        var fakeSets = new Faker<Set>()
            .StrictMode(true)
            .RuleFor(s => s.SetId, f => 0)
            .RuleFor(s => s.ExerciseRepetitions, f => f.Random.Number(50))
            .RuleFor(s => s.Exercise, f => fakeExercises.Generate());
        
        var fakeWorkouts = new Faker<Workout>()
            .StrictMode(true)
            .RuleFor(w => w.WorkoutId, f => 0)
            .RuleFor(w => w.Type, f => f.Lorem.Word())
            .RuleFor(w => w.IsCompleted, f => Random.Next(100) <= 20)
            .RuleFor(w => w.Set, f => fakeSets.Generate());
        
        var fakePrograms = new Faker<Models.Domain.Program>()
            .StrictMode(true)
            .RuleFor(p => p.ProgramId, f => 0)
            .RuleFor(p => p.Name, f => f.Lorem.Sentence(3))
            .RuleFor(p => p.Category, f => f.Lorem.Word())
            .RuleFor(p => p.Workouts, f => fakeWorkouts.Generate(f.Random.Number(9) + 1));
        
        var fakeGoals = new Faker<Goal>()
            .StrictMode(true)
            .RuleFor(g => g.GoalId, f => 0)
            .RuleFor(g => g.StartingDate, f => f.Date.PastDateOnly(1, constantDateOnly))
            .RuleFor(g => g.EndDate, f => f.Date.FutureDateOnly(1, constantDateOnly))
            .RuleFor(g => g.IsAchieved, f => Random.Next(100) <= 60)
            .RuleFor(g => g.Program, f => fakePrograms.Generate());
        
        var fakeProfiles = new Faker<Profile>()
            .StrictMode(false)
            .RuleFor(p => p.ProfileId, f => 0)
            .RuleFor(p => p.FirstName, f => f.Name.FirstName())
            .RuleFor(p => p.LastName, f => f.Name.LastName())
            .RuleFor(p => p.Disabilities, f => f.Lorem.Sentence())
            .RuleFor(p => p.MedicalConditions, f => f.Lorem.Sentence())
            .RuleFor(p => p.Goals, f => fakeGoals.Generate(f.Random.Number(9) + 1))
            .RuleFor(p => p.Height, f => f.Random.Double(0.1, 0.2) * 1000) // Height between 100-200 cm
            .RuleFor(p => p.Weight, f => f.Random.Double(0.05, 0.15) * 1000); // Weight between 50-150 kg

        Profiles = fakeProfiles.Generate(count);
    }
}