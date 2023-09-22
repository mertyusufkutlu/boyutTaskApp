using System.Security.Claims;

namespace boyutTaskAppAPI.Applicaton.Extensions;

public static class ClaimsExtensions
{
    public static bool CheckClaims(this IList<Claim> neededClaims, IList<Claim> userClaims)
    {
        var check = false;
        foreach (var neededClaim in neededClaims)
            check = check || userClaims.Select(c => (c.Type, c.Value))
                .Contains<(string, string)>((neededClaim.Type, neededClaim.Value));
        return check;
    }
}