using Newtonsoft.Json;

namespace boyutTaskAppAPI.Applicaton.Base.GenericAuth;

public class RealmAccess
{
    [JsonProperty("roles")]
    public List<string> Roles { get; set; }
}

public class Resource
{
    [JsonProperty("roles")]
    public List<string> Roles { get; set; }
}

public class AccessTokenResult
{
    [JsonProperty("jti")]
    public string Jti { get; set; }

    [JsonProperty("exp")]
    public int Exp { get; set; }

    [JsonProperty("nbf")]
    public int Nbf { get; set; }

    [JsonProperty("iat")]
    public int Iat { get; set; }

    [JsonProperty("iss")]
    public string Iss { get; set; }

    [JsonProperty("sub")]
    public string Sub { get; set; }

    [JsonProperty("typ")]
    public string Typ { get; set; }

    [JsonProperty("azp")]
    public string Azp { get; set; }

    [JsonProperty("auth_time")]
    public int AuthTime { get; set; }

    [JsonProperty("session_state")]
    public string SessionState { get; set; }

    [JsonProperty("preferred_username")]
    public string PreferredUsername { get; set; }

    [JsonProperty("email")]
    public string Email { get; set; }

    [JsonProperty("email_verified")]
    public bool EmailVerified { get; set; }

    [JsonProperty("acr")]
    public string Acr { get; set; }

    [JsonProperty("realm_access")]
    public RealmAccess RealmAccess { get; set; }

    [JsonProperty("resource_access")]
    public Dictionary<string, Resource> ResourceAccess { get; set; }

    [JsonProperty("scope")]
    public string Scope { get; set; }

    [JsonProperty("client_id")]
    public string ClientId { get; set; }

    [JsonProperty("username")]
    public string Username { get; set; }

    [JsonProperty("active")]
    public bool Active { get; set; }
}