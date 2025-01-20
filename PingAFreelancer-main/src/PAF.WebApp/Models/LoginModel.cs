using System.ComponentModel.DataAnnotations;

namespace PAF.MobileApp.Models;

public class LoginModel
{
    [Required(ErrorMessage = "Username is required")]
    [EmailAddress]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
}