using System.ComponentModel.DataAnnotations;
using Infrastructure.Models.Domain;

namespace Infrastructure.Models.DTOs.Goal
{
    public class GoalReadDTO
    {
        /// <summary>
        /// Primary key of the goal
        /// </summary>
        /// <exmaple></exmaple>
        [Key]
        public int GoalId { get; set; }
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
        /// <summary>
        /// Has the goal been completed=
        /// </summary>
        /// <exmaple>true</exmaple>
        public ICollection<CompletedWorkout> CompletedWorkouts { get; set; }
        /// <summary>
        /// List of program names
        /// </summary>
        /// <exmaple>[Upper body training, Tap dancing class]</exmaple>
        public Models.Domain.Program Program { get; set; }
    }
}