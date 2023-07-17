using CustomerRelationshipManagement.Data.Models;
using CustomerRelationshipManagement.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WeCare.WebAPI.Utilities
{
    public static class JwtHelper
    {
        public static string GenerateJwtToken(
            AppUser user, List<Claim> claims, string privateKey, string issuer, int validDays)
        { 
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(privateKey);

            var token = new JwtSecurityToken(
                issuer: issuer,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(validDays),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            );

            return tokenHandler.WriteToken(token);
        }

        public static string GenerateJwtTokenForApiClient(
            ApiClient apiClient, string privateKey, string issuer, int validDays = 365)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, apiClient.Email),
                    new Claim(ClaimTypes.NameIdentifier, apiClient.ClientId.ToString()),
                    new Claim(ClaimTypes.Role, RoleConstants.AdminRole),
                    new Claim(ClaimTypes.Role, RoleConstants.SuperAdminRole),
                    new Claim(ClaimTypes.Role, RoleConstants.AdminRole)
                };


            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(privateKey);

            var token = new JwtSecurityToken(
                issuer: issuer,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(validDays),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            );

            return tokenHandler.WriteToken(token);
        }
    }
}
