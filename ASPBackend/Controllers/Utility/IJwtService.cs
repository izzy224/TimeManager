using ASPBackend.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace ASPBackend.Controllers.Utility
{
    public interface IJwtService
    {
        string Generate(User user);
        TokenValidationParameters GetValidationParameters();
        JwtSecurityToken ValidateToken(string authToken);
    }
}