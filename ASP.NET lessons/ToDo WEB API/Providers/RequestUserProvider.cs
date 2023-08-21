namespace ToDo_WEB_API.Providers;

public class RequestUserProvider : IRequestUserProvider
{
    private readonly HttpContext _httpContext;

    public RequestUserProvider(IHttpContextAccessor httpContext)
    {
        _httpContext = httpContext.HttpContext;
    }

    public UserInfo? GetUserInfo()
    {
        if (!_httpContext.User.Claims.Any())
        {
            return null;
        }

        var userId = _httpContext.User.Claims.First(
            x=>x.Type == "userId").Value;
        var userName = _httpContext.User.Identity.Name;
        return new UserInfo(userId, userName);

    }
}
