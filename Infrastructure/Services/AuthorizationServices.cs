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
using Infrastructure.DTOs.Profile;
using Infrastructure.DTOs.User;

namespace Infrastructure.Services
{
    public static class AuthorizationServices
    {
        public static ProfileReadDTO ReadCurrentUser(this ClaimsIdentity identity)
        {
            if (identity != null)
            {
                return new ProfileReadDTO
                {
                    KeycloakId = GetKeycloakId(identity),
                    FirstName = GetFirstName(identity),
                    LastName = GetLastName(identity)
                };
            }
            return null;
        }

        public static ProfileCreateDTO CreateCurrentUser(this ClaimsIdentity identity)
        {
            if (identity != null)
            {
                return new ProfileCreateDTO
                {
                    KeycloakId = GetKeycloakId(identity),
                    FirstName = GetFirstName(identity),
                    LastName = GetLastName(identity)
                };
            }
            return null;
        }

        public static int CurrentUserId(this ClaimsIdentity identity)
        {
            var userClaims = identity.Claims;

            //return userClaims.FirstOrDefault(s => s.Type == ClaimTypes.NameIdentifier)?.Value;
            return 0;
        }

        public static bool CurrentIsAdmin(this ClaimsIdentity identity)
        {
            var userClaims = identity.Claims;

            return userClaims.Any(s => s.Value == "Admin");
        }
        
        public static bool CurrentIsContributor(this ClaimsIdentity identity)
        {
            var userClaims = identity.Claims;

            return userClaims.Any(s => s.Value == "Contributor");
        }

        public static string GetFirstName(this ClaimsIdentity identity)
        {
            var userClaims = identity.Claims;

            return userClaims.FirstOrDefault(s => s.Type == ClaimTypes.GivenName)?.Value;
        }

        public static string GetLastName(this ClaimsIdentity identity)
        {
            var userClaims = identity.Claims;

            return userClaims.FirstOrDefault(s => s.Type == ClaimTypes.Surname)?.Value;
        }

        public static Guid GetKeycloakId(this ClaimsIdentity identity)
        {
            var userClaims = identity.Claims;

            return new Guid(userClaims.FirstOrDefault(s => s.Type == ClaimTypes.NameIdentifier)?.Value);
        }
        
        
        
    }
}