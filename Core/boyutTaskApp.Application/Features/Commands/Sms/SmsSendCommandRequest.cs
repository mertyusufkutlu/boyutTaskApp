using MediatR;

namespace boyutTaskAppAPI.Applicaton.Features.Commands.Sms;

public class SmsSendCommandRequest : IRequest<SmsSendCommandResponse>
{
    public string Number { get; set; } 

    public string Message { get; set; }

    public SmsSendCommandRequest(string number, string message)
    {
        Number = number ?? throw new ArgumentNullException(nameof(number));
        Message = message ?? throw new ArgumentNullException(nameof(message));
    }
    
}