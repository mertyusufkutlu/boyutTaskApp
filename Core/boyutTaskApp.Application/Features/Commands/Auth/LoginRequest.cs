using MediatR;

namespace boyutTaskAppAPI.Applicaton.Features.Commands.Auth;

public class LoginRequest : IRequest<LoginResponse>
{
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string Password { get; set; }
}