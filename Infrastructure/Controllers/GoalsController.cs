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
using Infrastructure.Models.DTOs.Goal;

namespace Infrastructure.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GoalsController : ControllerBase
    {
        private readonly MeFitDbContext _context;
        private readonly IMapper _mapper;

        public GoalsController(MeFitDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GoalReadDTO>> GetGoal(int id)
        {
            var goal = await _context.Goals.FindAsync(id);

            if (goal == null)
            {
                return NotFound();
            }

            return _mapper.Map<GoalReadDTO>(goal);
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostGoal([FromBody] GoalCreateDTO goalDTO)
        {
            Goal goal = _mapper.Map<Goal>(goalDTO);
            goal.Profile = await _context.Profiles.FirstOrDefaultAsync(p => p.ProfileId == goal.Profile.ProfileId);

            try
            {
                _context.Goals.Add(goal);
                await _context.SaveChangesAsync();

            } catch
            {
                return BadRequest();
            }

            return goal.GoalId;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGoal(int id, GoalEditDTO goalDTO)
        {
            Goal goal = _mapper.Map<Goal>(goalDTO);

            try
            {
                _context.Entry(goal).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoalExists(id))
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
        public async Task<IActionResult> DeleteGoal(int id)
        {
            var goal = await _context.Goals.FindAsync(id);

            if (goal == null)
            {
                return NotFound();
            }

            try
            {
                _context.Goals.Remove(goal);
                await _context.SaveChangesAsync();
            } catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        [HttpPut("{id}/program")]
        public async Task<IActionResult> AddWorkouts(int id, [FromBody] int programId)
        {
            Goal? goal = await _context.Goals.Include(t => t.Program).FirstOrDefaultAsync(s => s.GoalId == id);

            if (goal == null)
            {
                return NotFound();
            }

            Models.Domain.Program program = await _context.Programs.FindAsync(programId);

            if (program == null)
            {
                return BadRequest();
            }

            goal.Program = program;

            try
            {
                _context.Entry(goal).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        private bool GoalExists(int id)
        {
            return _context.Goals.Any(e => e.GoalId == id);
        }
    }
}