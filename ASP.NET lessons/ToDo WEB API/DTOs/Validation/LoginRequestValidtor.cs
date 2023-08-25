using FluentValidation;
using ToDo_WEB_API.DTOs.Auth;

namespace ToDo_WEB_API.DTOs.Validation;

public class LoginRequestValidtor : AbstractValidator<LoginRequest>
{
    public LoginRequestValidtor()
    {
        //RuleFor(x => x.Email).EmailAddress().NotEmpty();
        //RuleFor(x=>x.Password).Password().NotEmpty();
    }
}
