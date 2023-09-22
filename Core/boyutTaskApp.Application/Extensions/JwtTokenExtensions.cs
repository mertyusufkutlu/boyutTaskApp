using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using System.Text.Json.Serialization;
using boyutTaskAppAPI.Applicaton.Base;

namespace boyutTaskAppAPI.Applicaton.Extensions
{
    public static class JwtTokenExtensions
    {
        public static List<string> GetTokenRoles(this string? token)
        {
            try
            {
                var list = new List<string>();
                var handler = new JwtSecurityTokenHandler();

                if (handler.ReadToken(token) is not JwtSecurityToken readToken)
                {
                    throw new ArgumentException("Invalid JWT token");
                }

                var realmAccess = readToken.Claims
                    .FirstOrDefault(claim => claim.Type == "realm_access")
                    ?.Value;
                
                if (realmAccess == null)
                {
                    throw new ArgumentException("realm_access claim not found in JWT token");
                }

                var root = JsonSerializer.Deserialize<Root>(realmAccess);

                if (root?.Roles != null)
                {
                    list = root.Roles;
                }

                return list;
            }
            catch (Exception ex)
            {
                // Hata mesajını ve detaylarını inceleyin
                throw new BaseException(ex.Message);
            }
        }

        /// <summary>
        /// Token içerisinde yer alan realm_access Claims'ını çözmek için maplenen modeldir.
        /// Sadece TokenExtensions sınıfında kullanılacağı için private tanımlanmıştır.
        /// </summary>
        private class Root
        {
            [JsonPropertyName("roles")] public List<string>? Roles { get; set; }
        }
    }
}