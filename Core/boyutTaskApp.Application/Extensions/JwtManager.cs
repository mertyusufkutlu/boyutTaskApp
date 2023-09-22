using boyutTaskAppAPI.Applicaton.Base.GenericAuth;
using boyutTaskAppAPI.Applicaton.Settings;
using Newtonsoft.Json;

namespace boyutTaskAppAPI.Applicaton.Extensions;

public static class JwtManager
{
    public static async Task<AccessTokenResult> ValidateToken(string accessToken, ISsoParameters ssoParameters)
    {
        AccessTokenResult accessTokenResult = null;
        try
        {
            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                accessToken = accessToken.Replace("Bearer ", "");
                var requestBody = new List<KeyValuePair<string, string>>();
                requestBody.Add(new(ssoParameters.AccessTokenBodyName, accessToken));
                requestBody.Add(new(ssoParameters.ClientSecretBodyName, ssoParameters.ClientSecretBodyValue));
                requestBody.Add(new(ssoParameters.ClientIdBodyName, ssoParameters.ClientIdBodyValue));

                var httpRequestMessage = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(ssoParameters.ValidationUrl),
                    Content = new FormUrlEncodedContent(requestBody)
                };

                using var client = new HttpClient();
                var result = await client.SendAsync(httpRequestMessage);

                var stringResult = result.Content.ReadAsStringAsync().Result;

                accessTokenResult = JsonConvert.DeserializeObject<AccessTokenResult>(stringResult);
            }
        }
        catch (Exception)
        {
            accessTokenResult = null;
        }

        return accessTokenResult;
    }
}