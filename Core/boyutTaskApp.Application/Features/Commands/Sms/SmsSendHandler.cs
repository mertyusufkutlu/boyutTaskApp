using MediatR;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace boyutTaskAppAPI.Applicaton.Features.Commands.Sms;

public class SmsSendHandler : IRequestHandler<SmsSendCommandRequest, SmsSendCommandResponse>
{

    public async Task<SmsSendCommandResponse> Handle(SmsSendCommandRequest request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.ToString()))
        {
            throw new Exception("SmsSendCommandRequest cannot be null");
        }
        
        TwilioClient.Init("AC276e56612200226e9f85021751d2f18e", "7c39b47173d8c0a700567f8d3518b7a4");

        var response = await MessageResource.CreateAsync(to: request.Number,
            body: request.Message,
            from: "+14788885836");
        var smsSendCommandResponse = new SmsSendCommandResponse()
        {
            Body = response.Body,
            Target = response.To
        };

        return smsSendCommandResponse;
    }
}