using System.ComponentModel.DataAnnotations;

namespace ToDo_WEB_API.DTOs.Auth;

public class RegisterRequest
{
    //[EmailAddress]
    //[Required]
    public string Email { get; set; }

    //[MinLength(8)]
    //[Required]
    public string Password { get; set; }

    //[UserName]
    //[Required]
    //public string UserName { get; set; } = string.Empty;
}

//public class UserNameAttribute : ValidationAttribute
//{
//    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
//    {
//        if (value is not string userName)
//        {
//            return new ValidationResult("UserName is not a string");
//        }

//        if (userName.Length < 2)
//        {
//            return new ValidationResult("UserName is short");
//        }

        

//        return ValidationResult.Success;
//    }
//}