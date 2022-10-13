using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Infrastructure.Models.DTOs.Exercises.ExerciseReadDTO;
using Infrastructure.Models.Domain.Exercises;
using Infrastructure.Models.DTOs.Exercises.ExerciseCreateDTO;
using Infrastructure.Models.DTOs.Exercises.ExerciseEditDTO;

namespace Infrastructure.Controllers.TimedExercisesControllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TimedExercisesController : ControllerBase
    {
        private readonly MeFitDbContext _context;
        private readonly IMapper _mapper;

        public TimedExercisesController(MeFitDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimedExerciseReadDTO>>> GetTimedExercises()
        {
            List<TimedExercise> TimedExercises = await _context.TimedExercises.OrderBy(x => x.MuscleGroups).ToListAsync();
            return _mapper.Map<List<TimedExerciseReadDTO>>(TimedExercises);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TimedExerciseReadDTO>> GetTimedExercise(int id)
        {
            var TimedExercise = await _context.TimedExercises.FindAsync(id);

            if (TimedExercise == null)
            {
                return NotFound();
            }

            return _mapper.Map<TimedExerciseReadDTO>(TimedExercise);
        }

        [Authorize(Roles = "Contributor")]
        [HttpPost]
        public async Task<ActionResult<TimedExerciseCreateDTO>> PostTimedExercise(TimedExerciseCreateDTO TimedExerciseDTO)
        {
            TimedExercise TimedExercise = _mapper.Map<TimedExercise>(TimedExerciseDTO);

            try
            {
                _context.TimedExercises.Add(TimedExercise);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return CreatedAtAction("GetTimedExercise", new { id = TimedExercise.ExerciseId }, TimedExerciseDTO);
        }

        [Authorize(Roles = "Contributor")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimedExercise(int id, TimedExerciseEditDTO TimedExerciseDTO)
        {
            TimedExercise TimedExercise = _mapper.Map<TimedExercise>(TimedExerciseDTO);

            try
            {
                _context.Entry(TimedExercise).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimedExerciseExists(id))
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
        public async Task<IActionResult> DeleteTimedExercise(int id)
        {
            var TimedExercise = await _context.TimedExercises.FindAsync(id);


            if (TimedExercise == null)
            {
                return NotFound();
            }

            try
            {
                _context.TimedExercises.Remove(TimedExercise);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        private bool TimedExerciseExists(int id)
        {
            return _context.TimedExercises.Any(e => e.ExerciseId == id);
        }
    }
}