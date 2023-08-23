using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ToDo_WEB_API.DTOs.Auth;
using ToDo_WEB_API.Models;
using ToDo_WEB_API.Services.Auth;

namespace ToDo_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtService _jwtService;

        public AuthController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IJwtService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _jwtService = jwtService;
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

            var accessToken = _jwtService.GenerateSecurityToken(
                user.Id,
                user.UserName, 
                role, userClaims);
            
            var refreshToken = Guid.NewGuid().ToString("N").ToLower();
            
            user.RefreshToken = refreshToken;

            await _userManager.UpdateAsync(user);
            return new AuthTokenDto
            {
                AccessToken = accessToken,
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

            return await GenerateToken(user);

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

            return await GenerateToken(user);
            
        }

        private async Task<AuthTokenDto> GenerateToken(AppUser user)
        {
            var role = await _userManager.GetRolesAsync(user);
            var userClaims = await _userManager.GetClaimsAsync(user);

            var accessToken = _jwtService.GenerateSecurityToken(
                user.Id,
                user.UserName, 
                role, userClaims);
            var refreshToken = user.RefreshToken;

            await _userManager.UpdateAsync(user);

            return new AuthTokenDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }
    }
}


// AAD, OAuth2, Cognito, KeyCloak, B2C ...