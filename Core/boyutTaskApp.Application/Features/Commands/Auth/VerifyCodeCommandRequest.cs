using System.ComponentModel.DataAnnotations;
using MediatR;

namespace boyutTaskAppAPI.Applicaton.Features.Commands.Auth;

public class VerifyCodeCommandRequest : IRequest<bool>
{
    public VerifyCodeCommandRequest(string phoneNumber, string code)
    {
        PhoneNumber = phoneNumber;
        Code = code;
    }

    [Required, Phone]
    public string PhoneNumber { get; set; }

    public string Code { get; set; }
    
}