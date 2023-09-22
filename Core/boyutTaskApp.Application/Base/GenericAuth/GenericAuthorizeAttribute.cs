using boyutTaskAppAPI.Applicaton.Base.Filters;
using boyutTaskAppAPI.Applicaton.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace boyutTaskAppAPI.Applicaton.Base.GenericAuth;

public sealed class GenericAuthorizeAttribute : TypeFilterAttribute
{
    public GenericAuthorizeAttribute(params string[] claims) : base(typeof(GenericAuthorizeFilter))
    {
        Arguments = new[] { new ClaimStorage(claims) };
        Order = int.MinValue;
    }
}

public class EnableCorsAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        context.HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
        context.HttpContext.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
        context.HttpContext.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Authorization");
        base.OnActionExecuting(context);
    }
}