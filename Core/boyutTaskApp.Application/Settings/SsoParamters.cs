using System.Net.Http;
using boyutTaskAppAPI.Applicaton.Settings;
using Microsoft.Extensions.Options;

namespace OneDose.ClaimIdentity.Model;

public class SsoParameters : ISsoParameters
{
    private readonly KeyCloakSettings _keyCloakSettings;

    // public SsoParameters(IOptions<Settings> settings)
    // {
    //     _keyCloakSettings = settings.Value.Keycloak;
    //     AccessTokenBodyName = _keyCloakSettings.AccessTokenBodyName;
    //     ClientSecretBodyName = _keyCloakSettings.ClientSecretBodyName;
    //     ClientSecretBodyValue = _keyCloakSettings.ClientSecretBodyValue;
    //     ClientIdBodyName = _keyCloakSettings.ClientIdBodyName;
    //     ClientIdBodyValue = _keyCloakSettings.ClientIdBodyValue;
    //     ValidationUrl = _keyCloakSettings.ValidationUrl;
    //     ValidationContentType = _keyCloakSettings.ValidationContentType;
    // }
    public string AccessTokenBodyName { get; set; }
    public string ClientSecretBodyName { get; set; }
    public string ClientSecretBodyValue { get; set; }
    public string ClientIdBodyName { get; set; }
    public string ClientIdBodyValue { get; set; }
    public string ValidationUrl { get; set; }
    public string ValidationContentType { get; set; }
}