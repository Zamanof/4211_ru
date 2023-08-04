using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using ToDo_WEB_API.DTOs.Auth;
using ToDo_WEB_API.Models;

namespace ToDo_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthTokenDto>> Login(
            [FromBody] LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
            {
                return Unauthorized();
            }

            var canSignIn = await _signInManager
                .CheckPasswordSignInAsync(user, request.Password, false);

            if (!canSignIn.Succeeded)
            {
                return Unauthorized();
            }
            var role = await _userManager.GetRolesAsync(user);
            var userClaims = await _userManager.GetClaimsAsync(user);

            var claims = new[]
            {
                new Claim (ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim (ClaimsIdentity.DefaultRoleClaimType, string.Join(",", role))
#region Without Identity adding claims
//new Claim("CanTest", "true")
                //new Claim("permissions", JsonSerializer.Serialize(new []{
                //    "CanTest",
                //    "CanDelete",
                //    "CanEdit",
                //    "CanCreate"
                //}))
	#endregion                
            }.Concat(userClaims);
            var key =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Super Hard Secure Key"));
            var signingCredentials
                = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "https://localhost:5000",
                audience: "https://localhost:5000",
                expires: DateTime.UtcNow.AddMinutes(3),
                signingCredentials: signingCredentials,
                claims: claims);

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            var refreshToken = Guid.NewGuid().ToString("N").ToLower();
            await _userManager.UpdateAsync(user);
            return new AuthTokenDto
            {
                AccessToken = tokenValue,
                RefreshToken = refreshToken
            };
        }

        [HttpPost("refresh")]
        public async Task<ActionResult<AuthTokenDto>> Refresh(
            [FromBody] RefreshTokenRequest request)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync
                (u => u.RefreshToken == request.RefreshToken);
            if (user is null)
            {
                return Unauthorized();
            }

            var role = await _userManager.GetRolesAsync(user);
            var userClaims = await _userManager.GetClaimsAsync(user);

            var claims = new[]
            {
                new Claim (ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim (ClaimsIdentity.DefaultRoleClaimType, string.Join(",", role))
            }.Concat(userClaims);
            var key =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Super Hard Secure Key"));
            var signingCredentials
                = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "https://localhost:5000",
                audience: "https://localhost:5000",
                expires: DateTime.UtcNow.AddMinutes(3),
                signingCredentials: signingCredentials,
                claims: claims);

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            var refreshToken = user.RefreshToken;
            await _userManager.UpdateAsync(user);
            return new AuthTokenDto
            {
                AccessToken = tokenValue,
                RefreshToken = refreshToken
            };

        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthTokenDto>> Register(
            [FromBody] RegisterRequest request
            )
        {
            var exisitingUser = await _userManager.FindByEmailAsync(request.Email);
            if (exisitingUser is not null)
            {
                return Conflict("User already exists");
            }

            var user = new AppUser
            {
                UserName = request.Email,
                Email = request.Email,
                RefreshToken = Guid.NewGuid().ToString("N").ToLower()
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            
            // Copy paste from Refresh
            var role = await _userManager.GetRolesAsync(user);
            var userClaims = await _userManager.GetClaimsAsync(user);

            var claims = new[]
            {
                new Claim (ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim (ClaimsIdentity.DefaultRoleClaimType, string.Join(",", role))
            }.Concat(userClaims);
            var key =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Super Hard Secure Key"));
            var signingCredentials
                = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "https://localhost:5000",
                audience: "https://localhost:5000",
                expires: DateTime.UtcNow.AddMinutes(3),
                signingCredentials: signingCredentials,
                claims: claims);

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            var refreshToken = user.RefreshToken;
            await _userManager.UpdateAsync(user);
            return new AuthTokenDto
            {
                AccessToken = tokenValue,
                RefreshToken = refreshToken
            };
        }
    }
}


// AAD, OAuth2, Cognito, KeyCloak, B2C ...