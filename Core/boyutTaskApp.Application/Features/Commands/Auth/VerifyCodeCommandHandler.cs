using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;

namespace boyutTaskAppAPI.Applicaton.Features.Commands.Auth;

public class VerifyCodeCommandHandler : IRequestHandler<VerifyCodeCommandRequest, bool>
{
    private readonly IDistributedCache _distributedCache;

    public VerifyCodeCommandHandler(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }

    public async Task<bool> Handle(VerifyCodeCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(request.PhoneNumber))
                throw new Exception("PhoneNumber cannot be null");
        
            var cachedCode = await _distributedCache.GetStringAsync(GetValidateCacheKey(request.PhoneNumber),
                token: cancellationToken);
        
            if (cachedCode == null)
            {
                // Kod bulunamadı
                return false;
            }
        
            if (request.Code != cachedCode)
            {
                // Doğrulama kodu geçersiz
                throw new Exception("Your verify code is not valid: " + request.Code);
            }
        
            // Başarılı doğrulama, önbellekten kaldırılıyor
            await _distributedCache.RemoveAsync(GetValidateCacheKey(request.PhoneNumber), cancellationToken);

            // İşlem başarılı
            return true;
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred during the verification process");
        }
    }
    
    private static string GetValidateCacheKey(string phone)
    {
        return $"VALIDATION_KEY:{phone}";
    }
}