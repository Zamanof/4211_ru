using FluentValidation;
using System.Text.RegularExpressions;
using ToDo_WEB_API.DTOs.Auth;

namespace ToDo_WEB_API.DTOs.Validation;

public static class SharedValidators
{
    public static bool BeValidPassword(string password)
    {
        return new Regex(@"\d").IsMatch(password)
            && new Regex(@"[a-z]").IsMatch(password)
            && new Regex("[A-Z]").IsMatch(password);
    }
} 

public static class ValidationRulesExtensions
{
    public static IRuleBuilderOptions<T, string> Password<T>(
        this IRuleBuilder<T, string> ruleBuilder,
        bool mustContainLowerCase = true,
        bool mustContainUpperCase = true,
        bool mustContainDigit = true
        )
    {
        IRuleBuilderOptions<T, string> options = null;

        if( mustContainLowerCase )
        {
            options = ruleBuilder.Must(pass => new Regex("[a-z]").IsMatch(pass));
        }

        if (mustContainUpperCase)
        {
            options = ruleBuilder.Must(pass => new Regex("[A-Z]").IsMatch(pass));
        }

        if (mustContainDigit)
        {
            options = ruleBuilder.Must(pass => new Regex(@"\d").IsMatch(pass));
        }

        return options;
    }
}

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(x => x.Email).EmailAddress().NotEmpty();
        //RuleFor(x => x.Password).MinimumLength(8).Must(BeValidPassword).NotEmpty();
        //RuleFor(x => x.Password).MinimumLength(8).Must(SharedValidators.BeValidPassword).NotEmpty();
        //RuleFor(x => x.Password).MinimumLength(8).Password().NotEmpty();
        //RuleFor(x => x.UserName).Password(mustContainDigit: false).MinimumLength(2).NotEmpty();

    }

    private bool BeValidPassword(string password)
    {
        return new Regex(@"\d").IsMatch(password)
            && new Regex(@"[a-z]").IsMatch(password)
            && new Regex("[A-Z]").IsMatch(password);
    }
}
