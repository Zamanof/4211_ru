using System.Security.Claims;

namespace ToDo_WEB_API.Services.Auth;

public interface IJwtService
{
    string GenerateSecurityToken(
        string email,
        IEnumerable<string> roles,
        IEnumerable<Claim> userClaims
        );
}
