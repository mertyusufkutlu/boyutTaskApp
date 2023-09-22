using System.ComponentModel.DataAnnotations;
using MediatR;

namespace boyutTaskAppAPI.Applicaton.Features.Commands.User;

public class UserCreateRequest : IRequest<bool>
{
    [Required] [Phone] public string PhoneNumber { get; set; }

    [Required] public string Password { get; set; }

    [EmailAddress] public string? Email { get; set; }
    
    
    [MaxLength(250)]
    public string? UserName { get; set; }

    /// <summary>
    /// Alpha3 country code
    /// </summary>
    [MaxLength(3)]
    public string? Nationality { get; set; }
    
    public string? PhotoUrl { get; set; }
    
    public DateTime? BirthDate { get; set; }

    //TODO: Should not be NULL
    public Guid[]? AgreementIds { get; set; } = Array.Empty<Guid>();
}