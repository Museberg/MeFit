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

namespace Infrastructure.Controllers.RepExercisesControllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RepExercisesController : ControllerBase
    {
        private readonly MeFitDbContext _context;
        private readonly IMapper _mapper;

        public RepExercisesController(MeFitDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepExerciseReadDTO>>> GetRepExercises()
        {
            List<RepExercise> RepExercises = await _context.RepExercises.OrderBy(x => x.MuscleGroups).ToListAsync();
            return _mapper.Map<List<RepExerciseReadDTO>>(RepExercises);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RepExerciseReadDTO>> GetRepExercise(int id)
        {
            var RepExercise = await _context.RepExercises.FindAsync(id);

            if (RepExercise == null)
            {
                return NotFound();
            }

            return _mapper.Map<RepExerciseReadDTO>(RepExercise);
        }

        [Authorize(Roles = "Contributor")]
        [HttpPost]
        public async Task<ActionResult<RepExerciseCreateDTO>> PostRepExercise(RepExerciseCreateDTO RepExerciseDTO)
        {
            RepExercise RepExercise = _mapper.Map<RepExercise>(RepExerciseDTO);

            try
            {
                _context.RepExercises.Add(RepExercise);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return CreatedAtAction("GetRepExercise", new { id = RepExercise.ExerciseId }, RepExerciseDTO);
        }

        [Authorize(Roles = "Contributor")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepExercise(int id, RepExerciseEditDTO RepExerciseDTO)
        {
            RepExercise RepExercise = _mapper.Map<RepExercise>(RepExerciseDTO);

            try
            {
                _context.Entry(RepExercise).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepExerciseExists(id))
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
        public async Task<IActionResult> DeleteRepExercise(int id)
        {
            var RepExercise = await _context.RepExercises.FindAsync(id);


            if (RepExercise == null)
            {
                return NotFound();
            }

            try
            {
                _context.RepExercises.Remove(RepExercise);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        private bool RepExerciseExists(int id)
        {
            return _context.RepExercises.Any(e => e.ExerciseId == id);
        }
    }
}