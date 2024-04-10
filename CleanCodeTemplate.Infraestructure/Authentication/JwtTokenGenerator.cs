using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CleanCodeTemplate.Application;
using CleanCodeTemplate.Domain;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CleanCodeTemplate.Infraestructure;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings;
    private readonly IDateTimeProvider _dateTimeProvider;

    public JwtTokenGenerator(IOptions<JwtSettings> jwtsettings, IDateTimeProvider dateTimeProvider)
    {
        _jwtSettings = jwtsettings.Value;
        _dateTimeProvider = dateTimeProvider;
    }
    public string GenerateToken(User user)
    {
        var signingCredential = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
             SecurityAlgorithms.HmacSha256
        );

        var claims = new[]{
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            signingCredentials: signingCredential
             );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}

