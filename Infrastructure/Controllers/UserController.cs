using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Infrastructure.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Infrastructure.Services;
using AutoMapper;
using Infrastructure.DTOs.User;
namespace Infrastructure.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MeFitDbContext _context;
        private readonly IMapper _mapper;
        public UserController(MeFitDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> PostUser()
        {
            if (GetIdentity().UserExists(_context))
            {
                return NoContent();
            }

            UserCreateDTO userDTO = GetIdentity().CreateUser();
            User user = _mapper.Map<User>(userDTO);

            try { 
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

            } catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProfile()
        {

            User? user = GetIdentity().CurrentUser(_context);

            if (user == null)
            {
                return NoContent();
            }

            try
            {
                _context.Users.Remove(user);
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
    }
}
