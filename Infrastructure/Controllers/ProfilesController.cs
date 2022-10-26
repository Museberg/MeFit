using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Profile = Infrastructure.Models.Domain.Profile;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Infrastructure.Services;
using AutoMapper;
using Infrastructure.DTOs.Profile;

namespace Infrastructure.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly MeFitDbContext _context;
        private readonly IMapper _mapper;

        public ProfilesController(MeFitDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProfileReadDTO>> GetProfile(int id)
        {
            var profile = await _context.Profiles.FindAsync(id);

            if (profile == null)
            {
                return NotFound();
            }

            return _mapper.Map<ProfileReadDTO>(profile);
        }
        
        [HttpPost]
        public async Task<ActionResult<ProfileCreateDTO>> PostProfile([FromBody] ProfileCreateDTO profileDTO)
        {
            // Creates profile variable from body.
            Profile profile = _mapper.Map<Profile>(profileDTO);
            // Adds user to profile using token.
            profile.User = GetIdentity().CurrentUser(_context);

            try
            {
                // Adds and saves profile in database.
                _context.Profiles.Add(profile);
                await _context.SaveChangesAsync();
            } catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return CreatedAtAction("GetProfile", new { id = profile.ProfileId }, profileDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfile(int id, ProfileEditDTO profileDTO)
        {
            // Creates profile variable from body.
            Profile profile = _mapper.Map<Profile>(profileDTO);
            // Adds "id" from http request. 
            profile.ProfileId = id;

            try
            {
                // Updates profile and saves changes in database
                _context.Entry(profile).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileExists(id))
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
        public async Task<IActionResult> DeleteProfile(int id)
        {
            // Finds profile by ID from http request.
            var profile = await _context.Profiles.Include(s => s.User).FirstOrDefaultAsync(m => m.ProfileId == id);

            // Checks if profile was found
            if (profile == null)
            {
                return NotFound();
            }

            // Checks if token Id and user assosiated with profile matches.
            if (GetIdentity().CurrentKeyCloakId() != profile.User.KeycloakId)
            {
                return Forbid();
            }

            try
            {
                // Removes profile and saves database.
                _context.Profiles.Remove(profile);
                await _context.SaveChangesAsync();
            } catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        private bool ProfileExists(int id)
        {
            return _context.Profiles.Any(e => e.ProfileId == id);
        }
        private IEnumerable<Claim> GetIdentity()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            return identity.Claims;
        }
    }
}