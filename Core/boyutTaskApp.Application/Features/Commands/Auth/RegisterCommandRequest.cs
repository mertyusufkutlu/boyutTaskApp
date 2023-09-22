using System.ComponentModel.DataAnnotations;
using MediatR;

namespace boyutTaskAppAPI.Applicaton.Features.Commands.Auth;

public class RegisterCommandRequest : IRequest<bool>
{
    [Required, Phone]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// ISO Alpha3 code for the preferred country of the user.
    /// </summary>
    [MinLength(3), MaxLength(3)]
    public string? CountryCode { get; set; }
}