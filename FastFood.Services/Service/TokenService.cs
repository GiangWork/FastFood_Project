using FastFood.Contract.Repositories.Entity;
using FastFood.Contract.Services.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FastFood.Services.Service;

public class TokenService : ITokenService
{
    private const int EXPIRATION = 30;
    private readonly IConfiguration _config;
    private readonly SymmetricSecurityKey _key;
    public TokenService(IConfiguration config)
    {
        _config = config;
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("JwtSettings:SecretKey").Value));
    }

    public string CreateToken(UserInfo userInfo)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userInfo.Id),
            new Claim(ClaimTypes.Name, userInfo.Username),
            new Claim(ClaimTypes.Role,userInfo.Position.Role)
        };

        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddMinutes(EXPIRATION),
            SigningCredentials = creds,
            Issuer = _config["JwtSettings:Issuer"],
            Audience = _config["JwtSettings:Audience"]
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}

