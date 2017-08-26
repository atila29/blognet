namespace dtu.blognet.Application.Web.ConfigurationObjects
{
    public class JwtConfiguration
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}