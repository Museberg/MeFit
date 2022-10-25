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
using Infrastructure.Models.Domain;
using Infrastructure.Models.DTOs.Exercises.ExerciseReadDTO;
using Infrastructure.Models.Domain.Exercises;
using Infrastructure.Models.DTOs.Exercises.ExerciseCreateDTO;
using Infrastructure.Models.DTOs.Exercises.ExerciseEditDTO;
using Microsoft.AspNetCore.Cors;

namespace Infrastructure.Controllers
{
    [Authorize]
    [Route("api/Exercises/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly MeFitDbContext _context;
        private readonly IMapper _mapper;

        public ExercisesController(MeFitDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExerciseReadDTO>>> GetCardioExercises()
        {
            List<Exercise> Exercises = await _context.Exercises.OrderBy(x => x.MuscleGroups).ToListAsync();
            return _mapper.Map<List<ExerciseReadDTO>>(Exercises);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExerciseReadDTO>> GetCardioExercise(int id)
        {
            var CardioExercise = await _context.Exercises.FindAsync(id);

            if (CardioExercise == null)
            {
                return NotFound();
            }

            return _mapper.Map<ExerciseReadDTO>(CardioExercise);
        }

        [Authorize(Roles = "Contributor")]
        [HttpPost]
        public async Task<ActionResult<ExerciseCreateDTO>> PostCardioExercise(ExerciseCreateDTO CardioExerciseDTO)
        {
            Exercise CardioExercise = _mapper.Map<Exercise>(CardioExerciseDTO);

            try
            {
                _context.Exercises.Add(CardioExercise);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return CreatedAtAction("GetCardioExercise", new { id = CardioExercise.ExerciseId }, CardioExerciseDTO);
        }

        [Authorize(Roles = "Contributor")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCardioExercise(int id, ExerciseEditDTO CardioExerciseDTO)
        {
            Exercise CardioExercise = _mapper.Map<Exercise>(CardioExerciseDTO);

            try
            {
                _context.Entry(CardioExercise).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardioExerciseExists(id))
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
        public async Task<IActionResult> DeleteCardioExercise(int id)
        {
            var CardioExercise = await _context.Exercises.FindAsync(id);


            if (CardioExercise == null)
            {
                return NotFound();
            }

            try
            {
                _context.Exercises.Remove(CardioExercise);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        private bool CardioExerciseExists(int id)
        {
            return _context.Exercises.Any(e => e.ExerciseId == id);
        }
    }
}