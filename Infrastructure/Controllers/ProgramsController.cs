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
using Infrastructure.DTOs.Program;

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
        public async Task<ActionResult<ProgramCreateDTO>> PostProgram(ProgramCreateDTO programDTO)
        {
            Models.Domain.Program program = _mapper.Map<Models.Domain.Program>(programDTO);

            try
            {
                _context.Programs.Add(program);
                await _context.SaveChangesAsync();

            } catch
            {
                return BadRequest();
            }

            return CreatedAtAction("GetProgram", new { id = program.ProgramId }, programDTO);
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

        private bool ProgramExists(int id)
        {
            return _context.Programs.Any(e => e.ProgramId == id);
        }
    }
}