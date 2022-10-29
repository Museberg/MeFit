using Bogus;
using Infrastructure.Models.Domain;
using Infrastructure.Models.Domain.Exercises;

namespace Infrastructure.Data;

public class FakeData
{
    private static Random Random = new();
    private static int Seed = 8675309;
    
    public static List<Profile> Profiles = new();
    public static List<User> Users = new();

    public static void Init(int count)
    {
        Randomizer.Seed = new Random(Seed);
        DateOnly constantDateOnly = new DateOnly(2022, 10, 10);
        // Exercises and list of musclegroups
        var repExerciseMuscleGroupsDict = new Dictionary<string, List<MuscleEnum>>
        {
            {"Squat", new List<MuscleEnum>
            {
               MuscleEnum.Calves, MuscleEnum.Quadriceps, MuscleEnum.Hamstrings, MuscleEnum.Gluteus, MuscleEnum.Loin, MuscleEnum.Abdominals
            }},
            {"Leg press", new List<MuscleEnum>
            {
                MuscleEnum.Calves, MuscleEnum.Quadriceps, MuscleEnum.Hamstrings, MuscleEnum.Gluteus
            }},
            {"Lunge", new List<MuscleEnum>
            {
                MuscleEnum.Quadriceps, MuscleEnum.Hamstrings, MuscleEnum.Gluteus
            }},
            {"Deadlift", new List<MuscleEnum>
            {
                MuscleEnum.Calves, MuscleEnum.Quadriceps, MuscleEnum.Hamstrings, MuscleEnum.Gluteus, MuscleEnum.Loin, MuscleEnum.Abdominals
            }},
            {"Bench press", new List<MuscleEnum>
            {
                MuscleEnum.Triceps, MuscleEnum.Pectorals, MuscleEnum.Deltoids
            }},
            {"Chest fly", new List<MuscleEnum>
            {
                MuscleEnum.Pectorals, MuscleEnum.Deltoids
            }},
            {"Push up", new List<MuscleEnum>
            {
                MuscleEnum.Pectorals, MuscleEnum.Deltoids, MuscleEnum.Triceps
            }},
            {"Pull down", new List<MuscleEnum>
            {
                MuscleEnum.Lats, MuscleEnum.Biceps, MuscleEnum.Forearms
            }},
            {"Bent over row", new List<MuscleEnum>
            {
                MuscleEnum.Lats, MuscleEnum.Biceps
            }}
        };
        var cardioExerciseMuscleGroupDict = new Dictionary<string, List<MuscleEnum>>
        {
            {"Swimming", new List<MuscleEnum>
            {
                MuscleEnum.Abdominals, MuscleEnum.Forearms   
            }},
            {"Cycling", new List<MuscleEnum>
            {
                MuscleEnum.Abdominals, MuscleEnum.Forearms
            }},
            {"Jogging", new List<MuscleEnum>
            {
                MuscleEnum.Abdominals, MuscleEnum.Forearms
            }}
        };
        var timedExerciseMuscleGroupDict = new Dictionary<string, List<MuscleEnum>>
        {
            {"Planking", new List<MuscleEnum>
            {
                MuscleEnum.Loin, MuscleEnum.Triceps
            }},
            {"Dancing", new List<MuscleEnum>
            {
                MuscleEnum.Calves, MuscleEnum.Quadriceps, MuscleEnum.Hamstrings
            }}
        };
        
        var repExercises = new List<string>(repExerciseMuscleGroupsDict.Keys);
        var cardioExercises = new List<string>(cardioExerciseMuscleGroupDict.Keys);
        var timedExercises = new List<string>(timedExerciseMuscleGroupDict.Keys);
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
        
        var fakeUsers = new Faker<User>()
            .StrictMode(false)
            .RuleFor(u => u.KeycloakId, f => Guid.Empty)
            .RuleFor(u => u.UserId, f => 0)
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.Email, f => f.Person.Email);

        Users = fakeUsers.Generate(count);
        
  
        // Exercises
        var cardioIndex = 0;
        var fakeCardioExercises = new Faker<Exercise>()
            .StrictMode(false)
            .RuleFor(e => e.ExerciseId, f => 0)
            .RuleFor(e => e.Name, f => cardioExercises[cardioIndex++])
            .RuleFor(e => e.Description, f => f.Lorem.Paragraph())
            .RuleFor(e => e.DistanceInKm, f => f.Random.Double(42))
            .RuleFor(e => e.Type, f => ExerciseTypeEnum.Distance)
            .RuleFor(e => e.MuscleGroups, f => cardioExerciseMuscleGroupDict[f.PickRandom(cardioExercises)])
            .RuleFor(e => e.ImageLink, f => f.Image.LoremFlickrUrl(keywords: "workout"))
            .RuleFor(e => e.VideoLink, f => f.PickRandom(videoLinks))
            .RuleFor(e => e.Contributor, f => f.PickRandom(Users));

        var repIndex = 0;
        var fakeRepExercises = new Faker<Exercise>()
            .StrictMode(false)
            .RuleFor(e => e.ExerciseId, f => 0)
            .RuleFor(e => e.Name, f => repExercises[repIndex++])
            .RuleFor(e => e.Description, f => f.Lorem.Paragraph())
            .RuleFor(e => e.Repetitions, f => f.Random.Number(50))
            .RuleFor(e => e.Type, f => ExerciseTypeEnum.Repetitions)
            .RuleFor(e => e.MuscleGroups, f => repExerciseMuscleGroupsDict[f.PickRandom(repExercises)])
            .RuleFor(e => e.ImageLink, f => f.Image.LoremFlickrUrl(keywords: "workout"))
            .RuleFor(e => e.VideoLink, f => f.PickRandom(videoLinks))
            .RuleFor(e => e.Contributor, f => f.PickRandom(Users));

        var timedIndex = 0;
        var fakeTimedExercises = new Faker<Exercise>()
            .StrictMode(false)
            .RuleFor(e => e.ExerciseId, f => 0)
            .RuleFor(e => e.Name, f => timedExercises[timedIndex++])
            .RuleFor(e => e.Description, f => f.Lorem.Paragraph())
            .RuleFor(e => e.Type, f => ExerciseTypeEnum.Timed)
            .RuleFor(e => e.Seconds, f => f.Random.Double(7200))
            .RuleFor(e => e.MuscleGroups, f => timedExerciseMuscleGroupDict[f.PickRandom(timedExercises)])
            .RuleFor(e => e.ImageLink, f => f.Image.LoremFlickrUrl(keywords: "workout"))
            .RuleFor(e => e.VideoLink, f => f.PickRandom(videoLinks))
            .RuleFor(e => e.Contributor, f => f.PickRandom(Users));
        

        var mixedExercises = new List<Exercise>();
        mixedExercises.AddRange(fakeTimedExercises.Generate(timedExercises.Count));
        mixedExercises.AddRange(fakeRepExercises.Generate(repExercises.Count));
        mixedExercises.AddRange(fakeCardioExercises.Generate(cardioExercises.Count));

        var fakeWorkouts = new Faker<Workout>()
            .StrictMode(false)
            .RuleFor(w => w.WorkoutId, f => 0)
            .RuleFor(w => w.Name, f => f.Lorem.Word())
            .RuleFor(w => w.Description, f => f.Lorem.Sentence())
            .RuleFor(w => w.Exercises, f => f.PickRandom(mixedExercises, 2).ToList())
            .RuleFor(w => w.Contributor, f => f.PickRandom(Users));

        var fakeWorkoutsList = fakeWorkouts.Generate(15);


        var fakePrograms = new Faker<Models.Domain.Program>()
            .StrictMode(false)
            .RuleFor(p => p.ProgramId, f => 0)
            .RuleFor(p => p.Name, f => f.Lorem.Sentence(3))
            .RuleFor(p => p.Description, f => f.Lorem.Sentence())
            .RuleFor(p => p.Workouts, f => f.PickRandom(fakeWorkoutsList, 2).ToList())
            .RuleFor(p => p.Contributor, f => f.PickRandom(Users));

        var fakeProgramsList = fakePrograms.Generate(count);
        
        var fakeCompletedWorkouts = new Faker<CompletedWorkout>()
            .RuleFor(cw => cw.CompletedWorkoutId, 0)
            .RuleFor(cw => cw.Workout, f => f.PickRandom(fakeProgramsList).Workouts.First());

        var fakeGoals = new Faker<Goal>()
            .StrictMode(false)
            .RuleFor(g => g.GoalId, f => 0)
            .RuleFor(g => g.StartingDate, f => f.Date.PastDateOnly(1, constantDateOnly))
            .RuleFor(g => g.EndDate, f => f.Date.FutureDateOnly(1, constantDateOnly))
            .RuleFor(g => g.Program, f => f.PickRandom(fakeProgramsList))
            .RuleFor(g => g.CompletedWorkouts, f => fakeCompletedWorkouts.Generate(2));
        
        
        var fakeProfiles = new Faker<Profile>()
            .StrictMode(false)
            .RuleFor(p => p.ProfileId, f => 0)
            .RuleFor(p => p.User, f => f.PickRandom(Users))
            .RuleFor(p => p.Goals, f => fakeGoals.Generate(5))
            .RuleFor(p => p.Disabilities, f => f.Lorem.Sentence())
            .RuleFor(p => p.MedicalConditions, f => f.Lorem.Sentence())
            .RuleFor(p => p.Height, f => f.Random.Double(0.1, 0.2) * 1000) // Height between 100-200 cm
            .RuleFor(p => p.Weight, f => f.Random.Double(0.05, 0.15) * 1000); // Weight between 50-150 kg


        Profiles = fakeProfiles.Generate(count);
    }
}