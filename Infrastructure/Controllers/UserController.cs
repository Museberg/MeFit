using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Infrastructure.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Infrastructure.Services;
using AutoMapper;
using Infrastructure.DTOs.User;
using Infrastructure.Models.DTOs.Exercises.ExerciseReadDTO;
using Infrastructure.DTOs.Workout;
using Infrastructure.DTOs.Program;
using Infrastructure.DTOs.Goal;

namespace Infrastructure.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MeFitDbContext _context;
        private readonly IMapper _mapper;
        public UserController(MeFitDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> PostUser()
        {
            if (GetIdentity().UserExists(_context))
            {
                return NoContent();
            }

            UserCreateDTO userDTO = GetIdentity().CreateUser();
            User user = _mapper.Map<User>(userDTO);

            try { 
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

            } catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProfile()
        {

            User? user = GetIdentity().CurrentUser(_context);

            if (user == null)
            {
                return NoContent();
            }

            try
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }

            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        [HttpGet("Exercises")]
        public async Task<ActionResult<IEnumerable<ExerciseReadDTO>>> userExercises(int id)
        {
            var user = await _context.Users.Include(w => w.exercisesContributed).FirstOrDefaultAsync(p => p.UserId == id);

            List<Exercise> exercises = new List<Exercise>();

            foreach (var exercise in user.exercisesContributed)
            {
                exercises.Add(exercise);
            }

            return _mapper.Map<List<ExerciseReadDTO>>(exercises);
        }

        [HttpGet("Workouts")]
        public async Task<ActionResult<IEnumerable<WorkoutReadDTO>>> userWorkouts(int id)
        {
            var user = await _context.Users.Include(w => w.workoutsContributed).FirstOrDefaultAsync(p => p.UserId == id);

            List<Workout> workouts = new List<Workout>();

            foreach (var workout in user.workoutsContributed)
            {
                workouts.Add(workout);
            }

            return _mapper.Map<List<WorkoutReadDTO>>(workouts);
        }

        [HttpGet("Programs")]
        public async Task<ActionResult<IEnumerable<ProgramReadDTO>>> userPrograms(int id)
        {
            var user = await _context.Users.Include(w => w.programsContributed).FirstOrDefaultAsync(p => p.UserId == id);

            List<Models.Domain.Program> programs = new List<Models.Domain.Program>();

            foreach (var program in user.programsContributed)
            {
                programs.Add(program);
            }

            return _mapper.Map<List<ProgramReadDTO>>(programs);
        }

        [HttpGet("Goals")]
        public async Task<ActionResult<IEnumerable<GoalReadDTO>>> userGoals(int id)
        {
            var user = await _context.Users.Include(w => w.userGoals).FirstOrDefaultAsync(p => p.UserId == id);

            List<Goal> goals = new List<Goal>();

            foreach (var goal in user.userGoals)
            {
                goals.Add(goal);
            }

            return _mapper.Map<List<GoalReadDTO>>(goals);
        }

        private IEnumerable<Claim> GetIdentity()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            return identity.Claims;
        }
    }
}
