using System.Transactions;
using MediatR;
using boyutTaskAppAPI.Applicaton.Base;
using boyutTaskAppAPI.Applicaton.Features.Commands.KeyCloak;
using boyutTaskAppAPI.Applicaton.Repositories;

namespace boyutTaskAppAPI.Applicaton.Features.Commands.User;

public class UserCreateCommandHandler : IRequestHandler<UserCreateRequest, bool>
{
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IMediator _mediator;

    public UserCreateCommandHandler(IUserWriteRepository userWriteRepository, IMediator mediator)
    {
        _userWriteRepository = userWriteRepository;
        _mediator = mediator;
    }


    public async Task<bool> Handle(UserCreateRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var userId = Guid.NewGuid();

            var keycloakUserRequest = new KeyCloakUserCreateRequest
            {
                UserId = userId,
                Email = request.Email,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber
            };
            
            var authResponse = await _mediator.Send(keycloakUserRequest, cancellationToken);

            switch (authResponse)
            {
                case false:
                    throw new BaseException("Error while creating SSO user");
                case true:
                {
                    var newUser = new Domain.Entities.User()
                    {
                        Id = userId,
                        PhoneNumber = request.PhoneNumber,
                        Email = request.Email,
                    };
                    await _userWriteRepository.AddAsync(newUser);
                    await _userWriteRepository.SaveAsync();

                    return true;
                }
            }
        }
        catch (BaseException ex)
        {
            throw new BaseException("Error while creating SSO user");
        }
    }
}