using Microsoft.Extensions.Options;

namespace boyutTaskAppAPI.Applicaton.Settings;

public class SsoParameters : ISsoParameters
{
    public SsoParameters(KeyCloakSettings settings)
    {
        AccessTokenBodyName = settings.AccessTokenBodyName;
        ClientSecretBodyName = settings.ClientSecretBodyName;
        ClientSecretBodyValue = settings.ClientSecretBodyValue;
        ClientIdBodyName = settings.ClientIdBodyName;
        ClientIdBodyValue = settings.ClientIdBodyValue;
        ValidationUrl = settings.ValidationUrl;
        ValidationContentType = settings.ValidationContentType;
    }
    public string AccessTokenBodyName { get; set; }
    public string ClientSecretBodyName { get; set; }
    public string ClientSecretBodyValue { get; set; }
    public string ClientIdBodyName { get; set; }
    public string ClientIdBodyValue { get; set; }
    public string ValidationUrl { get; set; }
    public string ValidationContentType { get; set; }
}