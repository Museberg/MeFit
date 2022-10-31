using Bogus;
using Infrastructure.Models.Domain;
using Infrastructure.Models.Domain.Exercises;

namespace Infrastructure.Data;

public class FakeData
{
    private static Random Random = new();
    private static int Seed = 8675309;
    
    public static List<Profile> Profiles = new();
    public static List<Models.Domain.Program> Programs = new();
    public static List<User> Users = new();

    public static void Init(int count)
    {
        Randomizer.Seed = new Random(Seed);
        DateOnly constantDateOnly = new DateOnly(2022, 10, 10);


        var newUsers = new Faker<User>()
            .StrictMode(false)
            .RuleFor(u => u.KeycloakId, f => Guid.Empty)
            .RuleFor(u => u.UserId, f => 0)
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName));

        var newRepExercises = new List<Exercise>
        {
            new()
            {
                ExerciseId = 0,
                Type = ExerciseTypeEnum.Repetitions,
                Repetitions = 10,
                Name = "Squat",
                MuscleGroups = new List<MuscleEnum>
                {
                    MuscleEnum.Calves, MuscleEnum.Quadriceps, MuscleEnum.Hamstrings, MuscleEnum.Gluteus, MuscleEnum.Loin, MuscleEnum.Abdominals
                    
                },
                Description = "Stand with your feet about shoulder wide apart." +
                              " Initiate the movement by sending your hips back as if you're sitting back into an invisible chair. " +
                              "Bends knees to lower down as as far as possible with chest lifted in a controlled movement. Keep lower back neutral.",
                Contributor = newUsers.Generate(),
                ImageLink = "https://www.spotebi.com/wp-content/uploads/2014/10/squat-exercise-illustration.jpg",
                VideoLink = "https://www.youtube.com/watch?v=ubdIGnX2Hfs"
            },
            new()
            {
                ExerciseId = 0,
                Type = ExerciseTypeEnum.Repetitions,
                Repetitions = 10,
                Name = "Leg press",
                MuscleGroups = new List<MuscleEnum>
                {
                    MuscleEnum.Calves, MuscleEnum.Quadriceps, MuscleEnum.Hamstrings, MuscleEnum.Gluteus
                },
                Description = "Your bottom should be flat against the seat rather than raised. Your legs should form an angle of about 90 degrees at the knees. " +
                              "Now push! (your legs)",
                Contributor = newUsers.Generate(),
                ImageLink = "https://www.evolutionofbodybuilding.net/wp-content/uploads/2020/01/big-ramy-1700lbs-leg-press-arnold-classic-2020.jpg",
                VideoLink = "https://www.youtube.com/watch?v=s9-zeWzPUmA"
            },
            new()
            {
                ExerciseId = 0,
                Type = ExerciseTypeEnum.Repetitions,
                Repetitions = 10,
                Name = "Lunge",
                MuscleGroups = new List<MuscleEnum>
                {
                    MuscleEnum.Quadriceps, MuscleEnum.Hamstrings, MuscleEnum.Gluteus
                },
                Description = "Bend the knees and lower your body until the back knee is a few inches from the floor. " +
                              "At the bottom of the movement, the front thigh is parallel to the ground, " +
                              "the back knee points towards the floor, and your weight is evenly distributed between both legs.",
                Contributor = newUsers.Generate(),
                ImageLink = "https://www.spotebi.com/wp-content/uploads/2016/09/front-and-back-lunges-exercise-illustration-spotebi.jpg",
                VideoLink = "https://www.youtube.com/watch?v=AvBrsGNA7V8"
            },
            new()
            {
                ExerciseId = 0,
                Type = ExerciseTypeEnum.Repetitions,
                Repetitions = 5,
                Name = "Deadlift",
                MuscleGroups = new List<MuscleEnum>
                {
                    MuscleEnum.Calves, MuscleEnum.Quadriceps, MuscleEnum.Hamstrings, MuscleEnum.Gluteus, MuscleEnum.Loin, MuscleEnum.Abdominals
                },
                Description = "Standing with your feet shoulder-wide apart, grasp the bar with your hands just outside your legs. " +
                              "Lift the bar by driving your hips forwards, keep a flat back. Lower the bar under control " +
                              "- though once you get to really heavy weights, it's okay to drop it on your final rep.",
                Contributor = newUsers.Generate(),
                ImageLink = "https://content.artofmanliness.com/uploads/2012/12/Deadlifts-1.jpg",
                VideoLink = "https://www.youtube.com/watch?v=op9kVnSso6Q"
            },
            new()
            {
                ExerciseId = 0,
                Type = ExerciseTypeEnum.Repetitions,
                Repetitions = 10,
                Name = "Bench press",
                MuscleGroups = new List<MuscleEnum>
                {
                    MuscleEnum.Triceps, MuscleEnum.Pectorals, MuscleEnum.Deltoids
                },
                Description = "Lie flat on your back on a bench and grip the bar with your hands just wider than shoulder-wide apart. " +
                              "Bring the bar slowly down to your chest as your breathe in. Push up as you breathe out. Now repeat 10 times",
                Contributor = newUsers.Generate(),
                ImageLink = "https://www.muscleandfitness.com/wp-content/uploads/2020/07/Young-Arnold-Schwarzenegger-Working-Out-His-Chest-And-Arms-In-Venice-Beach.jpg?quality=86&strip=all",
                VideoLink = "https://www.youtube.com/watch?v=4cO1KHAsHxo"
            },
            new()
            {
                ExerciseId = 0,
                Type = ExerciseTypeEnum.Repetitions,
                Repetitions = 10,
                Name = "Chest fly",
                MuscleGroups = new List<MuscleEnum>
                {
                    MuscleEnum.Pectorals, MuscleEnum.Deltoids
                },
                Description = "Lie with your head and shoulders supported by the bench and your feet flat on the floor. " +
                              "Hold the dumbbells directly above your chest, palms facing each other, then lower the weights in an arc out to the sides as far as is comfortable. " +
                              "Use your pectoral muscles to reverse the movement back to the start. " +
                              "Keep a slight bend in your elbows throughout and don’t arch your back.",
                Contributor = newUsers.Generate(),
                ImageLink = "https://www.muscleandfitness.com/wp-content/uploads/2015/01/arnold-schwarzenegger-chest-workout.jpg?quality=86&strip=all",
                VideoLink = "https://www.youtube.com/watch?v=gyftXjBH9sc"
            },
            new()
            {
                ExerciseId = 0,
                Type = ExerciseTypeEnum.Repetitions,
                Repetitions = 10,
                Name = "Push up",
                MuscleGroups = new List<MuscleEnum>
                {
                    MuscleEnum.Pectorals, MuscleEnum.Deltoids, MuscleEnum.Triceps
                },
                Description = "Contract your abs and tighten your core by pulling your belly button toward your spine. " +
                              "Inhale as you slowly bend your elbows and lower yourself to the floor until your elbows are at a 90-degree angle. " +
                              "Exhale while contracting your chest muscles and pushing back up through your hands, returning to the start position",
                Contributor = newUsers.Generate(),
                ImageLink = "https://static.boredpanda.com/blog/wp-content/uploads/2020/03/arnold-schwarzenegger-home-workout-routine-2-5e7b3c41414db__700.jpg",
                VideoLink = "https://www.youtube.com/shorts/vgBZOigc4ko"
            },
            new()
            {
                ExerciseId = 0,
                Type = ExerciseTypeEnum.Repetitions,
                Repetitions = 10,
                Name = "Pull down",
                MuscleGroups = new List<MuscleEnum>
                {
                    MuscleEnum.Lats, MuscleEnum.Biceps, MuscleEnum.Forearms
                },
                Description = "Grasp the bar with a wide grip with an overhand, knuckles up grip. " +
                              "Pull the bar down till chin-level while you are exhaling." +
                              "Inhale while letting the bar move up in one smooth and controlled motion",
                Contributor = newUsers.Generate(),
                ImageLink = "https://i.ytimg.com/vi/fum5h7wOHfI/maxresdefault.jpg",
                VideoLink = "https://www.youtube.com/shorts/zk8Fjr0mDgs"
            },
            new()
            {
                ExerciseId = 0,
                Type = ExerciseTypeEnum.Repetitions,
                Repetitions = 10,
                Name = "Bent over row",
                MuscleGroups = new List<MuscleEnum>
                {
                    MuscleEnum.Lats, MuscleEnum.Biceps
                },
                Description = "Assume a starting position while holding a dumbbell in each hand with a neutral grip. " +
                              "Hinge forwards until your torso is roughly parallel with the floor (or slightly above)" +
                              " and then begin the movement by driving the elbows behind the body while retracting the shoulder blades. " +
                              "Pull the dumbbells your body until the elbows are at (or just past) the midline and then slowly lower the dumbbells " +
                              "back to the starting position under control.",
                Contributor = newUsers.Generate(),
                ImageLink = "https://bod-blog-assets.prod.cd.beachbodyondemand.com/bod-blog/wp-content/uploads/2022/07/14134844/rear-delt-exercises-600-bent-over-row.jpg",
                VideoLink = "https://www.youtube.com/watch?v=6TSP1TRMUzs"
            }

        };
        var newTimedExercises = new List<Exercise>
        {
            new()
            {
                ExerciseId = 0,
                Type = ExerciseTypeEnum.Timed,
                Seconds = 60,
                Name = "Planking",
                MuscleGroups = new List<MuscleEnum>
                {
                    MuscleEnum.Abdominals, MuscleEnum.Triceps, MuscleEnum.Loin
                },
                Description =
                    "Start on all fours. Hinge forward to lay forearms flat with the palms facing downward on the floor. Elbows should be directly under shoulders and planted onto the floor." +
                    "Step the feet back until the legs are fully extended. Bring the feet together, toes pointed toward the floor." +
                    "Using the midsection as momentum, keep forearms and elbows planted into the ground while lifting the torso, stomach and legs off of the floor. Keep the head in line with the spine and hips while squeezing the glutes, hamstrings, and quadriceps and pushing the heels toward the back of the room. Gaze gently ahead toward the fingertips."
                    + "Resisting any movement, hold position for desired timeframe, depending on comfort and strength level. Release, bringing the torso, stomach and legs back gently down to the floor.",
                Contributor = newUsers.Generate(),
                ImageLink =
                    "https://chicagohealthonline.com/wp-content/uploads/2020/06/premium-health-planking-20200610-1170x700.jpg.webp",
                VideoLink = "https://youtu.be/ql8qf61rCDo",
            },
            new()
            {
                ExerciseId = 0,
                Type = ExerciseTypeEnum.Timed,
                Seconds = 600,
                Name = "Dancing",
                MuscleGroups = new List<MuscleEnum>
                {
                    MuscleEnum.Calves, MuscleEnum.Quadriceps, MuscleEnum.Hamstrings
                },
                Description = "Dance however you want!",
                Contributor = newUsers.Generate(),
                ImageLink =
                    "https://global-uploads.webflow.com/5e2b8863ba7fff8df8949888/6130d37e6447aaa022e4e3b8_how-to-start-dancing-ITD-thumb.jpg",
                VideoLink = "https://youtu.be/TIfAkOBMf5A"
            }
        };
        var newDistanceExercises = new List<Exercise>
        {
            new()
            {
                ExerciseId = 0,
                Type = ExerciseTypeEnum.Distance,
                DistanceInKm = 1,
                Name = "Swimming",
                MuscleGroups = new List<MuscleEnum>
                {
                    MuscleEnum.Abdominals, MuscleEnum.Forearms
                },
                Description =
                    "A swimming stroke executed in a prone position by coordinating a kick in which the legs are brought forward with the knees together and the feet are turned outward and whipped back with a glide and a backward sweeping movement of the arms",
                Contributor = newUsers.Generate(),
                ImageLink =
                    "https://i.guim.co.uk/img/media/8fd5916a28cf4fc3a54f0ff9756c50ea797811ba/0_187_5616_3370/master/5616.jpg?width=1200&height=900&quality=85&auto=format&fit=crop&s=c262b782fde8e203945c21e23245aa8c",
                VideoLink = "https://youtu.be/EElzlIMjk_c"
            },
            new()
            {
                ExerciseId = 0,
                Type = ExerciseTypeEnum.Distance,
                DistanceInKm = 5,
                Name = "Cycling",
                MuscleGroups = new List<MuscleEnum>
                {
                    MuscleEnum.Abdominals, MuscleEnum.Forearms
                },
                Description = "You know how to ride a bike.",
                Contributor = newUsers.Generate(),
                ImageLink =
                    "https://images.immediate.co.uk/production/volatile/sites/21/2022/05/Cube-Axial-WS-12-45369da.jpg?quality=45&resize=768,574",
                VideoLink = "https://youtu.be/4ssLDk1eX9w"
            },
            new()
            {
                ExerciseId = 0,
                Type = ExerciseTypeEnum.Distance,
                DistanceInKm = 2,
                Name = "Jogging",
                MuscleGroups = new List<MuscleEnum>
                {
                    MuscleEnum.Quadriceps, MuscleEnum.Gluteus, MuscleEnum.Hamstrings, MuscleEnum.Abdominals
                },
                Description = "Jogging is another work for running.",
                Contributor = newUsers.Generate(),
                ImageLink =
                    "https://static.nike.com/a/images/f_auto,cs_srgb/w_1536,c_limit/30801422-1e6d-4a28-bf6e-1bdc6c9bd3f5/7-muscle-groups-you-activate-when-running.jpg",
                VideoLink = "https://youtu.be/PvbhZKxAzPI"
            }
        };
        var allExercises = new List<Exercise>();
        allExercises.AddRange(newRepExercises);
        allExercises.AddRange(newTimedExercises);
        allExercises.AddRange(newDistanceExercises);

        var newWorkouts = new List<Workout>
        {
            new()
            {
                WorkoutId = 0,
                Name = "Upper body",
                Description = "This workout contains exercises with focus on the upper body",
                Exercises = allExercises.Where(r => r.MuscleGroups
                    .Any(m => m is MuscleEnum.Abdominals or MuscleEnum.Biceps or MuscleEnum.Forearms
                        or MuscleEnum.Triceps or MuscleEnum.Pectorals or MuscleEnum.Deltoids)).ToList(),
                Contributor = newUsers.Generate()
            },
            new ()
            {
                WorkoutId = 0,
                Name = "Never skip leg day",
                Description = "This workout contains exercises with focus on the legs",
                Exercises = allExercises.Where(r => r.MuscleGroups
                    .Any(m => m is MuscleEnum.Calves or MuscleEnum.Hamstrings or MuscleEnum.Gluteus or MuscleEnum.Quadriceps)).ToList(),
                Contributor = newUsers.Generate()
            }
        };

        var newPrograms = new List<Models.Domain.Program>
        {
            new()
            {
                ProgramId = 0,
                Name = "Fully body workout",
                Description = "This program contains workout for both upper body and legs",
                Contributor = newUsers.Generate(),
                Workouts = newWorkouts
            }
        };

        Programs = newPrograms;

        /*var fakeGoals = new Faker<Goal>()
            .StrictMode(false)
            .RuleFor(g => g.GoalId, f => 0)
            .RuleFor(g => g.StartingDate, f => f.Date.PastDateOnly(1, constantDateOnly))
            .RuleFor(g => g.EndDate, f => f.Date.FutureDateOnly(1, constantDateOnly))
            .RuleFor(g => g.CompletedWorkouts, f => fakeCompletedWorkouts.Generate(2));
        
        var fakePrograms = new Faker<Models.Domain.Program>()
            .StrictMode(false)
            .RuleFor(p => p.ProgramId, f => 0)
            .RuleFor(p => p.Name, f => f.Lorem.Sentence(3))
            .RuleFor(p => p.Description, f => f.Lorem.Sentence())
            .RuleFor(p => p.Workouts, f => f.PickRandom(fakeWorkoutsList, 2).ToList())
            .RuleFor(p => p.Contributor, f => f.PickRandom(Users));

        var fakeCompletedWorkouts = new Faker<CompletedWorkout>()
            .RuleFor(cw => cw.CompletedWorkoutId, 0)
            .RuleFor(cw => cw.Workout, f => f.PickRandom(fakeWorkouts));
        
        
        
        var fakeProfiles = new Faker<Profile>()
            .StrictMode(false)
            .RuleFor(p => p.ProfileId, f => 0)
            .RuleFor(p => p.User, f => f.PickRandom(Users))
            .RuleFor(p => p.Goals, f => fakeGoals.Generate(5))
            .RuleFor(p => p.Disabilities, f => f.Lorem.Sentence())
            .RuleFor(p => p.MedicalConditions, f => f.Lorem.Sentence())
            .RuleFor(p => p.Height, f => f.Random.Double(0.1, 0.2) * 1000) // Height between 100-200 cm
            .RuleFor(p => p.Weight, f => f.Random.Double(0.05, 0.15) * 1000); // Weight between 50-150 kg


        
        Programs = fakePrograms.Generate(count);*/
    }
}