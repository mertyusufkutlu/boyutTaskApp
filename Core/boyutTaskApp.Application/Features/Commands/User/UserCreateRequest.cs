using System.ComponentModel.DataAnnotations;
using MediatR;

namespace boyutTaskAppAPI.Applicaton.Features.Commands.User;

public class UserCreateRequest : IRequest<bool>
{
    [Required] [Phone] public string? PhoneNumber { get; set; }

    [Required] public string Password { get; set; }

    [EmailAddress] public string? Email { get; set; }
}