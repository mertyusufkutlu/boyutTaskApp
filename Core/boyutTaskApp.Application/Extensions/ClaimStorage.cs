namespace boyutTaskAppAPI.Applicaton.Extensions;

public class ClaimStorage
{
    public ClaimStorage(string[] claims)
    {
        Claims = claims;
    }

    public string[] Claims { get; }
}