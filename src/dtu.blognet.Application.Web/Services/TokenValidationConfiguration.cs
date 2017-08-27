using System.Text;
using dtu.blognet.Application.Web.ConfigurationObjects;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace dtu.blognet.Application.Web.Services
{
    public class TokenValidationConfiguration
    {
        private readonly JwtConfiguration _config;
        public TokenValidationConfiguration(IOptions<JwtConfiguration> config)
        {
            _config = config.Value;
        }

        public TokenValidationParameters GetTokenValidationParameters()
        {
            // secretKey contains a secret passphrase only your server knows
            var secretKey = _config.SecretKey;
            var issuer = _config.Issuer;
            var audience = _config.Audience;
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,

                // Validate the JWT Issuer (iss) claim
                ValidateIssuer = true,
                ValidIssuer = issuer,

                // Validate the JWT Audience (aud) claim
                ValidateAudience = true,
                ValidAudience = audience
            };
            return tokenValidationParameters;
        }
    }
}