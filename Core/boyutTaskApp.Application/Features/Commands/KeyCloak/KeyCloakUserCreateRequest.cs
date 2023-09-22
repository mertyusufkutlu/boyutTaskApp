using MediatR;

namespace boyutTaskAppAPI.Applicaton.Features.Commands.KeyCloak;

public class KeyCloakUserCreateRequest : IRequest<bool>
{
    // public KeyCloakUserCreateRequest(Guid userId, string? requestEmail, string requestPassword, string requestPhoneNumber)
    // {
    //     UserId = userId;
    //     Password = requestPassword;
    //     PhoneNumber = requestPhoneNumber;
    //     Email = requestEmail;
    // }

    public Guid? UserId { get; set; }
    public string? Password { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
}