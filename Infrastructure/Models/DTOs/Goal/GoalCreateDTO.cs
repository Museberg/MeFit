using Infrastructure.Models.Domain;

namespace Infrastructure.Models.DTOs.Goal
{
    public class GoalCreateDTO
    {
        /// <summary>
        /// Starting data of goal
        /// </summary>
        /// <exmaple>25-10-2022</exmaple>
        public string StartingDate { get; set; }
        /// <summary>
        /// End day of goal
        /// </summary>
        /// <exmaple>01-11-2022</exmaple>
        public string EndDate { get; set; }

        public int ProgramId { get; set; }

        public ICollection<CompletedWorkout> CompletedWorkouts { get; set; }
    }
}