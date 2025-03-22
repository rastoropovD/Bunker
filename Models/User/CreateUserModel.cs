using System.ComponentModel.DataAnnotations;
using BunkerApp.Models.CustomValidaton;

namespace BunkerApp.Models.User;

public sealed class CreateUserModel
{
    [Required(ErrorMessage = "Username is required")]
    [Display(Name = "Email Address")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Password is required")]
    [Display(Name = "First Name")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Password must be between 2 and 50 characters")]
    public string FirstName { get; set; }
    
    [Required]
    [Display(Name = "Last Name")]
    [StringLength(50, MinimumLength = 2)]
    public string LastName { get; set; }

    [EvenNumber]
    public int Number { get; set; }
}