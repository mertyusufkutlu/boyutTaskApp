using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using boyutTaskAppAPI.Applicaton.Extensions;
using boyutTaskAppAPI.Applicaton.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace boyutTaskAppAPI.Applicaton.Base.Filters
{
    public class GenericAuthorizeFilter : IAsyncAuthorizationFilter
    {
        private readonly ClaimStorage _claimStorage;
        private readonly ISsoParameters _parameter;

        public GenericAuthorizeFilter(
            ClaimStorage claimStorage,
            ISsoParameters parameter)
        {
            _claimStorage = claimStorage;
            _parameter = parameter;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            // Allow Anonymous skips all authorization [AllowAnonymous]
            if (context.ActionDescriptor.EndpointMetadata.Any(item => item is AllowAnonymousAttribute))
            {
                return;
            }

            var request = context.HttpContext.Request;
            var headers = request.Headers;
            if (headers.TryGetValue("Authorization", out var headerValues))
            {
                var accessToken = headerValues.ElementAt(0);
                var accessTokenResult = await JwtManager.ValidateToken(accessToken, _parameter);
                if (accessTokenResult is null || !accessTokenResult.Active)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }

                var existedClaims = new List<Claim>();

                if (accessTokenResult.RealmAccess?.Roles != null && accessTokenResult.RealmAccess.Roles.Any())
                {
                    existedClaims.AddRange(accessTokenResult.RealmAccess.Roles.Select(r => new Claim("Role", r)));
                }

                var neededClaims = _claimStorage.Claims.Select(role => new Claim("Role", role)).ToList();

                // Eğer existedClaims null değilse ve en az bir rol içeriyorsa authorization kontrolü yapılır
                if (existedClaims != null && existedClaims.Any())
                {
                    var authorization = neededClaims.CheckClaims(existedClaims);

                    if (!authorization)
                    {
                        context.Result = new UnauthorizedResult();
                        return;
                    }
                }

                var newAccessTokenResult = new KeyValuePair<object, object>("AccessTokenResult", accessTokenResult);
                context.HttpContext.Items.Remove("AccessTokenResult");
                context.HttpContext.Items.Add(newAccessTokenResult);
                context.HttpContext.Items.Remove("UserId");
                context.HttpContext.Items.Add("UserId", accessTokenResult.Username);
            }
            else
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}