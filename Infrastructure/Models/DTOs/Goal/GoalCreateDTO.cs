using System.ComponentModel.DataAnnotations;

namespace Infrastructure.DTOs.Goal
{
    public class GoalCreateDTO
    {
        /// <summary>
        /// Starting data of goal
        /// </summary>
        /// <exmaple>25-10-2022</exmaple>
        public DateOnly StartingDate { get; set; }
        /// <summary>
        /// End day of goal
        /// </summary>
        /// <exmaple>01-11-2022</exmaple>
        public DateOnly EndDate { get; set; }
        /// <summary>
        /// Has the goal been completed=
        /// </summary>
        /// <exmaple>true</exmaple>
        public bool IsAchieved { get; set; }
        public int ProfileId { get; set; }
        public int ProgramId { get; set; }
    }
}
