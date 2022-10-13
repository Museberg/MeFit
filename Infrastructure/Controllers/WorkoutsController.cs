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

        [Authorize(Roles = "Contributor")]
        [HttpPost]
        public async Task<ActionResult<WorkoutCreateDTO>> PostWorkout(WorkoutCreateDTO workoutDTO)
        {
            Workout workout = _mapper.Map<Workout>(workoutDTO);

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


        [Authorize(Roles = "Contributor")]
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

        [Authorize(Roles = "Contributor")]
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

        private bool WorkoutExists(int id)
        {
            return _context.Workouts.Any(e => e.WorkoutId == id);
        }
    }
}