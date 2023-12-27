using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BackPractice.Models;
using BackPractice.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BackPractice.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : Controller
{    
    private UsersRepository UsersRepository { get; }

    public AuthController(UsersRepository usersRepository)
    {
        UsersRepository = usersRepository;
    }
    
    [HttpPost("auth")]
    public async Task<IActionResult> Auth([FromBody] User loginUser)
    {
        var user = await UsersRepository.GetByLogin(loginUser.Login);
        if (user == null)
        {
            return Unauthorized(new { reason = "User not found" });
        }

        var validatePassword = BCrypt.Net.BCrypt.Verify(loginUser.Password, user.Password);

        if (!validatePassword)
        {
            return Unauthorized(new { reason = "Incorrect password" });
        }

        var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Login) };
        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

        return Ok(new { access_token = new JwtSecurityTokenHandler().WriteToken(jwt) });
    }
}