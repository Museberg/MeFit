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

namespace Infrastructure.Services
{
    public static class AuthorizationServices
    {
        public static UserReadDTO ReadCurrentUser(this ClaimsIdentity identity)
        {
            if (identity != null)
            {
                var userClaims = identity.Claims;
                return new UserReadDTO
                {
                    UserId = new Guid(userClaims.FirstOrDefault(s => s.Type == ClaimTypes.NameIdentifier)?.Value),
                    FirstName = userClaims.FirstOrDefault(s => s.Type == ClaimTypes.GivenName)?.Value,
                    LastName = userClaims.FirstOrDefault(s => s.Type == ClaimTypes.Surname)?.Value,
                    IsContributer = userClaims.Any(s => s.Value == "Contributor"),
                    IsAdmin = userClaims.Any(s => s.Value == "Admin"),
                };
            }
            return null;
        }

        public static UserCreateDTO CreateCurrentUser(this ClaimsIdentity identity)
        {
            if (identity != null)
            {
                var userClaims = identity.Claims;
                return new UserCreateDTO
                {
                    UserId = new Guid(userClaims.FirstOrDefault(s => s.Type == ClaimTypes.NameIdentifier)?.Value),
                    FirstName = userClaims.FirstOrDefault(s => s.Type == ClaimTypes.GivenName)?.Value,
                    LastName = userClaims.FirstOrDefault(s => s.Type == ClaimTypes.Surname)?.Value,
                    IsContributer = userClaims.Any(s => s.Value == "Contributor"),
                    IsAdmin = userClaims.Any(s => s.Value == "Admin"),
                };
            }
            return null;
        }

        public static Guid CurrentUserId(this ClaimsIdentity identity)
        {
            var userClaims = identity.Claims;

            return new Guid(userClaims.FirstOrDefault(s => s.Type == ClaimTypes.NameIdentifier)?.Value);
        }

        public static bool CurrentIsAdmin(this ClaimsIdentity identity)
        {
            var userClaims = identity.Claims;

            return userClaims.Any(s => s.Value == "Admin");
        }
    }
}
