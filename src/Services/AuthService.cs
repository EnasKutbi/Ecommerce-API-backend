
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api.EntityFramework;
using Microsoft.IdentityModel.Tokens;

namespace api.service
{

public class AuthService
{
    private readonly IConfiguration _configuration;

    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
        Console.WriteLine($"{_configuration["Jwt:Issuer"]}");
    }
    public string GenerateJwt(User user)
        {

            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Role, user.IsAdmin? "Admin" : "User"),
            }),

                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),

                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }

}