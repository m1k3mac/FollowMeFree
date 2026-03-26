using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FollowMeFree.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace FollowMeFree.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly FmfDataContext _db;
        private readonly IConfiguration _configuration;

        public AuthController(FmfDataContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }

        /// <summary>
        /// Authenticates a user by username and numeric PIN code.
        /// Returns a non-expiring JWT token on success.
        /// </summary>
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.UserName))
                return BadRequest("UserName is required.");

            var user = await _db.Users
                .Include(u => u.Department)
                .FirstOrDefaultAsync(u => u.UserName == request.UserName && u.Pin == request.Pin);

            if (user is null)
                return Unauthorized("Invalid username or PIN.");

            var token = GenerateToken(user);

            return Ok(new LoginResponse
            {
                Token = token,
                UserName = user.UserName,
                FirstName = user.FirstName,
                Surname = user.Surname,
                DepartmentId = user.DepartmentId,
                AllowedPrinterIds = user.AllowedPrinterIds
            });
        }

        private string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim("firstName", user.FirstName),
                new Claim("surname", user.Surname),
                new Claim("departmentId", user.DepartmentId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // Token does not expire – suitable for an internal, non-internet-facing app.
            var token = new JwtSecurityToken(
                issuer: "FollowMeFree",
                audience: "FollowMeFreeApp",
                claims: claims,
                expires: null,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    public class LoginRequest
    {
        public string UserName { get; set; } = string.Empty;
        public int Pin { get; set; }
    }

    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public string? AllowedPrinterIds { get; set; }
    }
}
