using MediatR;

namespace boyutTaskAppAPI.Applicaton.Features.Commands.KeyCloak;

public class KeyCloakUserRequest : IRequest<KeyCloakResponse>
{
    public Guid? UserId { get; set; }
    public string? Password { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
}