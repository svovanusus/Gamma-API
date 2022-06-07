using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Gamma.Utils
{
    public static class AuthConfig
    {
        public const String ISSUER = "Gamma-Server";

        public const String AUDIENCE = "Gamma-Client";

        private const String KEY = "sYLhlWaTgYuD3KCnVv2IR3EjN3sBeAOL7GMT10WIJHAxMILpUwWfK5WVn7BQXD63fqblZU5YJbGazXVL";

        public const UInt64 LIFETIME = 2592000;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Base64UrlEncoder.Encode(KEY)));
        }
    }
}
