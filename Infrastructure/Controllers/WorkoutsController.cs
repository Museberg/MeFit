using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Infrastructure.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Infrastructure.DTOs.Workout;
using Microsoft.AspNetCore.Cors;
using System.Security.Claims;
using Infrastructure.Services;

namespace Infrastructure.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutsController : ControllerBase
    {
        private readonly MeFitDbContext _context;
        private readonly IMapper _mapper;
        public WorkoutsController(MeFitDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkoutReadDTO>>> GetWorkouts()
        {
            List<Workout> workouts = await _context.Workouts.OrderBy(x => x.Name).ToListAsync();
            return _mapper.Map<List<WorkoutReadDTO>>(workouts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkoutReadDTO>> GetWorkout(int id)
        {
            var workout = await _context.Workouts.FindAsync(id);

            if (workout == null)
            {
                return NotFound();
            }

            return _mapper.Map<WorkoutReadDTO>(workout);
        }

        [HttpPost]
        public async Task<ActionResult<WorkoutCreateDTO>> PostWorkout(WorkoutCreateDTO workoutDTO)
        {
            Workout workout = _mapper.Map<Workout>(workoutDTO);
            workout.Contributor = GetIdentity().CurrentUser(_context);

            try
            {
                _context.Workouts.Add(workout);
                await _context.SaveChangesAsync();
            } catch
            {
                return BadRequest();
            }
            
            return CreatedAtAction("GetWorkout", new { id = workout.WorkoutId }, workoutDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkout(int id, WorkoutEditDTO workoutDTO)
        {
            Workout workout = _mapper.Map<Workout>(workoutDTO);

            try
            {
                _context.Entry(workout).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkoutExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkout(int id)
        {
            // !! Check if contributor has contributed to workout !!

            var workout = await _context.Workouts.FindAsync(id);

            if (workout == null)
            {
                return NotFound();
            }

            try
            {
                _context.Workouts.Remove(workout);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        [HttpGet("{id}/Exercises")]
        public async Task<ActionResult<IEnumerable<int>>> GetExerciseIds(int id)
        {
            var workout = await _context.Workouts.Include(w => w.Exercises).FirstOrDefaultAsync(p => p.WorkoutId == id);

            List<int> exerciseIds = new List<int>();

            foreach (var exercise in workout.Exercises)
            {
                exerciseIds.Add(exercise.ExerciseId);
            }

            return exerciseIds;
        }

        [HttpPut("{id}/Exercises")]
        public async Task<IActionResult> AddWorkouts(int id, [FromBody] List<int> exerciseIds)
        {
            Models.Domain.Workout? workout = await _context.Workouts.Include(t => t.Exercises).FirstOrDefaultAsync(s => s.WorkoutId == id);

            if (workout == null)
            {
                return NotFound();
            }

            foreach (var exerciseId in exerciseIds)
            {
                Exercise exercise = await _context.Exercises.FindAsync(exerciseId);

                if (exercise == null)
                {
                    return BadRequest();
                }

                workout.Exercises.Add(exercise);
            }

            try
            {
                _context.Entry(workout).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }


        private bool WorkoutExists(int id)
        {
            return _context.Workouts.Any(e => e.WorkoutId == id);
        }

        private IEnumerable<Claim> GetIdentity()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            return identity.Claims;
        }
    }
}