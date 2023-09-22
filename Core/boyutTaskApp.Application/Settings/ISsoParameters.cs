namespace boyutTaskAppAPI.Applicaton.Settings;

public interface ISsoParameters
{
    string AccessTokenBodyName { get; }
    string ClientIdBodyName { get; }
    string ClientIdBodyValue { get; }
    string ClientSecretBodyName { get; }
    string ClientSecretBodyValue { get; }
    string ValidationContentType { get; }
    string ValidationUrl { get; }
}