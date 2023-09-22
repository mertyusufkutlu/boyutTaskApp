using MediatR;
using boyutTaskAppAPI.Applicaton.Base;
using boyutTaskAppAPI.Applicaton.Features.Commands.KeyCloak;
using boyutTaskAppAPI.Applicaton.Repositories;

namespace boyutTaskAppAPI.Applicaton.Features.Commands.Auth;

public class LoginCommandHandler : IRequestHandler<LoginRequest, LoginResponse>
{
    private readonly IUserReadRepository _userReadRepository;
    private readonly IMediator _mediator;

    public LoginCommandHandler(IUserReadRepository userReadRepository, IMediator mediator)
    {
        _userReadRepository = userReadRepository;
        _mediator = mediator;
    }

    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _userReadRepository.GetDbUser(request.PhoneNumber, request.Email);
            if (user == null)
            {
                throw new BaseException("User not found", 401);
            }

            var createTokenRequest = new KeyCloakUserRequest
            {
                UserId = user.Id,
                Password = request.Password
            };

            var userToken = await _mediator.Send(createTokenRequest, cancellationToken);

            LoginResponse loginResponse = new(userToken, user);

            return loginResponse;
        }
        catch (BaseException baseException)
        {
            throw new BaseException("Error while listing User", baseException.StatusCode);
        }
    }
}