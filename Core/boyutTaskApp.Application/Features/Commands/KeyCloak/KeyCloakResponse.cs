using System.Text.Json.Serialization;

namespace boyutTaskAppAPI.Applicaton.Features.Commands.KeyCloak;

public class KeyCloakResponse
{
    [JsonPropertyName("access_token")] public string? AccessToken { get; set; }

    [JsonPropertyName("refresh_token")] public string? RefreshToken { get; set; }

    [JsonPropertyName("error")] public string? Error { get; set; }

    [JsonPropertyName("error_description")]
    public string? ErrorDescription { get; set; }
}