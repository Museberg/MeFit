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

namespace Infrastructure.Controllers.CardioExercisesControllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CardioExercisesController : ControllerBase
    {
        private readonly MeFitDbContext _context;
        private readonly IMapper _mapper;

        public CardioExercisesController(MeFitDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardioExerciseReadDTO>>> GetCardioExercises()
        {
            List<CardioExercise> CardioExercises = await _context.CardioExercises.OrderBy(x => x.MuscleGroups).ToListAsync();
            return _mapper.Map<List<CardioExerciseReadDTO>>(CardioExercises);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CardioExerciseReadDTO>> GetCardioExercise(int id)
        {
            var CardioExercise = await _context.CardioExercises.FindAsync(id);

            if (CardioExercise == null)
            {
                return NotFound();
            }

            return _mapper.Map<CardioExerciseReadDTO>(CardioExercise);
        }

        [Authorize(Roles = "Contributor")]
        [HttpPost]
        public async Task<ActionResult<CardioExerciseCreateDTO>> PostCardioExercise(CardioExerciseCreateDTO CardioExerciseDTO)
        {
            CardioExercise CardioExercise = _mapper.Map<CardioExercise>(CardioExerciseDTO);

            try
            {
                _context.CardioExercises.Add(CardioExercise);
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
        public async Task<IActionResult> PutCardioExercise(int id, CardioExerciseEditDTO CardioExerciseDTO)
        {
            CardioExercise CardioExercise = _mapper.Map<CardioExercise>(CardioExerciseDTO);

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
            var CardioExercise = await _context.CardioExercises.FindAsync(id);


            if (CardioExercise == null)
            {
                return NotFound();
            }

            try
            {
                _context.CardioExercises.Remove(CardioExercise);
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
            return _context.CardioExercises.Any(e => e.ExerciseId == id);
        }
    }
}