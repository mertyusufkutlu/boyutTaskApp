using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Net;

namespace boyutTaskAppAPI.API;

/// <summary>
/// This middleware checks Http header and stores required keys into Items dictionary of
/// HttpContext. Check HttpContextExtensions class for convenience methods to retrieve
/// these values.
/// </summary>
public class AuthMiddleware
{
    private readonly RequestDelegate _next;

    public AuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context == null)
        {
            throw new InvalidOperationException("HttpContext can not be null.");
        }
        var path = context.Request.Path.ToString();
        if (!path.Contains("access-token"))
        {
            var strUserId = context?.User?.Claims?
                .Where(c => c.Type ==
                            "preferred_username") // TODO: type should be "sub" instead of "preferred_username" according to rfc docs
                .Select(x => x.Value)
                .FirstOrDefault();
            if (!string.IsNullOrEmpty(strUserId))
            {
                context!.Items["UserId"] = strUserId;
            }
            else if (context!.Request != null)
            {
                try
                {
                    if (context.Request.Headers.TryGetValue("Authorization", out var token))
                    {
                        // Alternative way to get UserId from JWT token
                        var handler = new JwtSecurityTokenHandler();
                        var tokens = handler.ReadJwtToken(token.ToString().Replace("Bearer ", ""));
                        var userId = tokens.Claims.First(c => c.Type == "preferred_username")?.Value;

                        context.Items["UserId"] = userId;

                        // TODO: implement getting impersonated user id from header like below
                        // var impersonatedUserId = GetFromHeaders();
                    }
                }
                catch (System.Exception)
                {
                    // suppress the exception because Authorization header is not always present or valid.
                }
            }
        }

        await _next.Invoke(context);
    }
}