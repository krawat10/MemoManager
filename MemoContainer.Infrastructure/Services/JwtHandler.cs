using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using MemoContainer.Infrastructure.DTOs;
using MemoContainer.Infrastructure.Settings;
using Microsoft.Extensions.Options;

namespace MemoContainer.Infrastructure.Services
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtSettings _jwtSettings;

        public JwtHandler(IOptions<JwtSettings> options)
        {
            _jwtSettings = options.Value;
        }

        public Task<TokenDTO> CreateToken(Guid userId, string role)
        {
            var now = DateTime.UtcNow;

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToString())
            };

            var expires = now.AddMinutes(_jwtSettings.ExpiryMinutes);

            
        }
    }
}