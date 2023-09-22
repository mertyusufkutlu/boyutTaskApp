using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using boyutTaskAppAPI.Applicaton.Features.Commands.Sms;

namespace boyutTaskAppAPI.Applicaton.Features.Commands.Auth;

public class CreateRegisterHandler : IRequestHandler<RegisterCommandRequest, bool>
{
    private const int VerificationCodeLength = 6;
    private readonly IMediator _mediator;
    private readonly IDistributedCache _distributedCache;

    public CreateRegisterHandler(IMediator mediator, IDistributedCache distributedCache)
    {
        _mediator = mediator;
        _distributedCache = distributedCache;
    }


    public async Task<bool> Handle(RegisterCommandRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var random = new Random(DateTime.UtcNow.Millisecond);
            var minValue = (int)Math.Pow(10, VerificationCodeLength - 1);
            var maxValue = (int)Math.Pow(10, VerificationCodeLength) - 1;
            var key = random.Next(minValue, maxValue).ToString().PadLeft(VerificationCodeLength, '0');
            var turkishMessage = $"Boyut Bilgisayar Doğrulama Kodunuz: {key} Lutfen kimseyle paylaşmayınız.";
            var englishMessage = $"Boyut Bilgisayar Verification Code: {key} Please do not share with anyone.";
            var countryCode = request.CountryCode;
            var messageContent = countryCode == "TUR" ? turkishMessage : englishMessage;
            await _mediator.Send((new SmsSendCommandRequest(request.PhoneNumber, messageContent)), cancellationToken);
            await _distributedCache.SetStringAsync(GetValidateCacheKey(request.PhoneNumber),
                key,
                new DistributedCacheEntryOptions
                    { AbsoluteExpiration = DateTime.Now.AddMinutes(5) },
                cancellationToken);
        }
        catch (Exception exception)
        {

            throw new Exception("We cannot accommodate your request at this time. Please try again.");
        }

        return true;
    }

    private static string GetValidateCacheKey(string phone)
    {
        return $"VALIDATION_KEY:{phone}";
    }
}