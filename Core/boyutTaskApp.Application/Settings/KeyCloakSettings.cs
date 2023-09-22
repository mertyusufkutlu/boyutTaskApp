namespace boyutTaskAppAPI.Applicaton.Settings;

public class KeyCloakSettings
{
    public string AccessCodeHeaderName { get; set; }
    public string AccessTokenHeaderName { get; set; }
    public string AccessCodeBodyName { get; set; }
    public string AccessTokenBodyName { get; set; }
    public string GrantTypeBodyName { get; set; }
    public string GrantTypePasswordBodyValue { get; set; }
    public string ClientSecretBodyName { get; set; }
    public string ClientSecretBodyValue { get; set; }
    public string ClientIdBodyName { get; set; }
    public string ClientIdBodyValue { get; set; }
    public string TokenUrl { get; set; }
    public string ValidationUrl { get; set; }
    public string UserUrl { get; set; }
    public string CreateUserGetUrl { get; set; }
    public string AddPatientGroupUrl { get; set; }
    public string ValidationContentType { get; set; }
    public string JsonContentType { get; set; }
    public string CredentialType { get; set; }
    public string UsernameBodyName { get; set; }
    public string UsernameBodyValue { get; set; }
    public string PasswordBodyName { get; set; }
    public string PasswordBodyValue { get; set; }
    public string ChangeUserPassword { get; set; }
    public string ChangeUserReqPassword { get; set; }
    public string DeleteUserFromSso { get; set; }
    public string ScopeBodyName { get; set; }
    public string ScopeBodyValue { get; set; }
    public string IrStaticToken { get; set; }
    public string EntegrationPassword { get; set; }
    public string GetTokenForEntegration { get; set; }
    public string RefreshTokenBodyName { get; set; }
    public string RefreshTokenValue { get; set; }
    public string GrantTypeValue { get; set; }

    public string HealthCheckUserName { get; set; }
    public string HealthCheckPassword { get; set; }
        


}