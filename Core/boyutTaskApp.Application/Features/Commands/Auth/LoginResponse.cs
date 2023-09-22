using boyutTaskAppAPI.Applicaton.Base;
using boyutTaskAppAPI.Applicaton.Extensions;
using boyutTaskAppAPI.Applicaton.Features.Commands.KeyCloak;

namespace boyutTaskAppAPI.Applicaton.Features.Commands.Auth;

public class LoginResponse
{
        public string? AccessToken { get; set; }

        public string? RefreshToken { get; set; }

        public List<string>? Claims { get; set; }

        public string? FirebaseUserEmail { get; set; }

        public string? FirebaseUserSalt { get; set; }

        public Domain.Entities.User? User { get; set; }
        

        // public List<AgreementResponse> Agreements { get; set; } = new();
        
        public LoginResponse(KeyCloakResponse? userToken, Domain.Entities.User? userResponse)
        {
            if (userToken?.AccessToken != null)
            {
                AccessToken = userToken.AccessToken;
                RefreshToken = userToken.RefreshToken;
                Claims = userToken?.AccessToken?.GetTokenRoles();
            }

            User = userResponse;
        }
}