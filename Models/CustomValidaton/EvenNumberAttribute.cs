using System.ComponentModel.DataAnnotations;

namespace BunkerApp.Models.CustomValidaton;

public sealed class EvenNumberAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value is int number)
        {
            return number % 2 == 0;
        }
        return false;
    }
}