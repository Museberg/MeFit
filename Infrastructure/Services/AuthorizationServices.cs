using Infrastructure.Data;
using System.Security.Claims;
using Infrastructure.DTOs.User;
using Infrastructure.Models.Domain;

namespace Infrastructure.Services
{
    public static class AuthorizationServices
    {
        public static UserCreateDTO CreateUser(this IEnumerable<Claim> userClaims)
        {
            return new UserCreateDTO
            {
                KeycloakId = new Guid(userClaims.First(s => s.Type == ClaimTypes.NameIdentifier).Value),
                FirstName = userClaims.First(n => n.Type == ClaimTypes.GivenName).Value,
                LastName = userClaims.First(s => s.Type == ClaimTypes.Surname).Value,
                Email = userClaims.First(s => s.Type == ClaimTypes.Email).Value
            };
        }

        public static bool CurrentIsAdmin(this IEnumerable<Claim> userClaims)
        {
            return userClaims.Any(s => s.Value == "Admin");
        }
        
        public static bool CurrentIsContributor(this IEnumerable<Claim> userClaims)
        {
            return userClaims.Any(s => s.Value == "Contributor");
        }

        public static Guid CurrentKeyCloakId(this IEnumerable<Claim> userClaims)
        {
            return new Guid(userClaims.First(s => s.Type == ClaimTypes.NameIdentifier).Value);
        }

        public static int CurrentUserId(this IEnumerable<Claim> userClaims, MeFitDbContext _context)
        {
            Guid keyCloakId = userClaims.CurrentKeyCloakId();
            return _context.Users.First(s => s.KeycloakId == keyCloakId).UserId;
        }

        public static bool UserExists(this IEnumerable<Claim> userClaims, MeFitDbContext _context)
        {
            Guid keyCloakId = userClaims.CurrentKeyCloakId();
            return _context.Users.Any(s => s.KeycloakId == keyCloakId);
        }

        public static User? CurrentUser(this IEnumerable<Claim> userClaims, MeFitDbContext _context)
        {
            Guid keyCloakId = userClaims.CurrentKeyCloakId();
            return _context.Users.Where(s => s.KeycloakId == keyCloakId).FirstOrDefault();
        }
    }
}