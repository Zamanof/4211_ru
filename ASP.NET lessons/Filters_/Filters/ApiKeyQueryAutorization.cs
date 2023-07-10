using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters_.Filters;
public class ApiKeyQueryAutorization : IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var isAuthorized = context
            .HttpContext
            .Request
            .Query
            .Any(q => q.Key == "apiKey" && q.Value == "pass12345");
        if (!isAuthorized)
        {
            context.Result = new UnauthorizedResult();
        }
    }
}
