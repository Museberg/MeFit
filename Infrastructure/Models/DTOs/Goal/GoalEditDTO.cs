namespace Infrastructure.Models.DTOs.Goal
{
    public class GoalEditDTO
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
    }
}