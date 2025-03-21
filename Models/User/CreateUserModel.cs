using System.ComponentModel.DataAnnotations;
using BunkerApp.Models.CustomValidaton;

namespace BunkerApp.Models.User;

public sealed class CreateUserModel
{
    [Required]
    [Display(Name = "Email Address")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    
    [Required]
    [Display(Name = "First Name")]
    [StringLength(50, MinimumLength = 2)]
    public string FirstName { get; set; }
    
    [Required]
    [Display(Name = "Last Name")]
    [StringLength(50, MinimumLength = 2)]
    public string LastName { get; set; }

    [EvenNumber]
    public int Number { get; set; }
}