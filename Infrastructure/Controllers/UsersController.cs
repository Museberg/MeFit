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
using System.Security.Claims;
using Infrastructure.DTOs.User;
using Infrastructure.Services;
using AutoMapper;

namespace Infrastructure.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MeFitDbContext _context;
        private readonly IMapper _mapper;
        public UsersController(MeFitDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetUserSelf()
        {
            try
            {
                Guid currentUserId = GetIdentity().CurrentUserId();

                Console.WriteLine($"{currentUserId}");

                return Redirect($"{currentUserId}");

            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromBody] User user2)
        {
            User user = _mapper.Map<User>(GetIdentity().CreateCurrentUser());
            user.Address = user2.Address;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return NoContent();// CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(Guid id)
        {
            User user = await UserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(Guid id, [FromBody] User userNew)
        {
            User userOld = await UserById(id);

            if (id != userNew.UserId) // Insert || userOld.Password != userNew.PassWord
            {
                return BadRequest();
            }

            if (userOld.IsAdmin != userNew.IsAdmin)
            {
                return Forbid();
            }

            _context.Entry(userNew).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            if (GetIdentity().CurrentUserId() != id && GetIdentity().CurrentIsAdmin() == false)
            {
                return Forbid();
            }

            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}/update_password")]
        public async Task<ActionResult> UpdatePassword(Guid id, [FromBody] string password)
        {
            if (GetIdentity().CurrentUserId() != id && GetIdentity().CurrentIsAdmin() == false)
            {
                return Forbid();
            }

            User user = await UserById(id);

            if (!UserExists(id))
            {
                return NotFound();
            }

            // user.PassWord = password;

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // SERVICES!

        private bool UserExists(Guid id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }

        private async Task<User> UserById(Guid id)
        {
            User user = await _context.Users.FindAsync(id);

            return user;
        }

        private ClaimsIdentity GetIdentity()
        {
            return HttpContext.User.Identity as ClaimsIdentity;
        }
    }
}
