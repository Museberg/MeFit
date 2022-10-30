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
using System.Security.Claims;
using Infrastructure.Models.DTOs.Program;
using Infrastructure.Services;

namespace Infrastructure.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramsController : ControllerBase
    {
        private readonly MeFitDbContext _context;
        private readonly IMapper _mapper;

        public ProgramsController(MeFitDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProgramReadDTO>>> GetPrograms()
        {
            var programs = await _context.Programs.OrderBy(x => x.Name).ToListAsync();
            return _mapper.Map<List<ProgramReadDTO>>(programs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProgramReadDTO>> GetProgram(int id)
        {
            var program = await _context.Programs.FindAsync(id);

            if (program == null)
            {
                return NotFound();
            }

            return _mapper.Map<ProgramReadDTO>(program);
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostProgram(ProgramCreateDTO programDTO)
        {
            Models.Domain.Program program = _mapper.Map<Models.Domain.Program>(programDTO);
            program.Contributor = GetIdentity().CurrentUser(_context);

            try
            {
                _context.Programs.Add(program);
                await _context.SaveChangesAsync();

            } catch
            {
                return BadRequest();
            }

            return program.ProgramId;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProgram(int id, ProgramEditDTO ProgramDTO)
        {
            Models.Domain.Program program = _mapper.Map<Models.Domain.Program>(ProgramDTO);

            try
            {
                _context.Entry(program).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramExists(id))
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
        public async Task<IActionResult> DeleteProgram(int id)
        {
            var program = await _context.Programs.FindAsync(id);

            if (program == null)
            {
                return NotFound();
            }

            try
            {
                _context.Programs.Remove(program);
                await _context.SaveChangesAsync();
            } catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        [HttpGet("{id}/workouts")]
        public async Task<ActionResult<IEnumerable<int>>> GetWorkoutsIds(int id)
        {
            var program = await _context.Programs.Include(w => w.Workouts).FirstOrDefaultAsync(p => p.ProgramId == id);

            List<int> workoutIds = new List<int>();

            foreach (var workout in program.Workouts)
            {
                workoutIds.Add(workout.WorkoutId);
            }

            return workoutIds;
        }

        [HttpPut("{id}/workouts")]
        public async Task<IActionResult> AddWorkouts(int id, [FromBody] List<int> workoutIds)
        {
            Models.Domain.Program? program = await _context.Programs.Include(t => t.Workouts).FirstOrDefaultAsync(s => s.ProgramId == id);

            if (program == null)
            {
                return NotFound();
            }

            foreach (var workoutId in workoutIds)
            {
                Workout workout = await _context.Workouts.FindAsync(workoutId);

                if (workout == null)
                {
                    return BadRequest();
                }

                program.Workouts.Add(workout);
            }

            try
            {
                _context.Entry(program).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }
        private IEnumerable<Claim> GetIdentity()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            return identity.Claims;
        }
        private bool ProgramExists(int id)
        {
            return _context.Programs.Any(e => e.ProgramId == id);
        }
    }
}