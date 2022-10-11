using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Infrastructure.Models.Domain;
using Profile = Infrastructure.Models.Domain.Profile;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Infrastructure.Services;
using AutoMapper;
using Infrastructure.DTOs.Profile;

namespace Infrastructure.Controllers
{
    // [Authorize]
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
        public async Task<ActionResult<ProfileReadDTO>> GetProfile(Guid id)
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
            Profile profile = _mapper.Map<Profile>(profileDTO);
            profile.User = _context.Users.Find(new Guid("f9b439ac-8c61-4dbf-8a40-b877c1799721"));

            _context.Profiles.Add(profile);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfile", new { UserId = profile.User }, profile);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfile(Guid id, ProfileEditDTO profileDTO)
        {
            Profile profile = _mapper.Map<Profile>(profileDTO);
            profile.ProfileId = id;

            _context.Entry(profile).State = EntityState.Modified;

            try
            {
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
        public async Task<IActionResult> DeleteProfile(Guid id)
        {
            if (GetIdentity().CurrentUserId() != id)
            {
                return Forbid();
            }

            var profile = await _context.Profiles.FindAsync(id);

            if (profile == null)
            {
                return NotFound();
            }

            _context.Profiles.Remove(profile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfileExists(Guid id)
        {
            return _context.Profiles.Any(e => e.ProfileId == id);
        }
        private ClaimsIdentity GetIdentity()
        {
            return HttpContext.User.Identity as ClaimsIdentity;
        }
    }
}
