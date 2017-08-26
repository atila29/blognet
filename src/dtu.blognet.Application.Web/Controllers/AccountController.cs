using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dtu.blognet.Application.Web.ConfigurationObjects;
using dtu.blognet.Application.Web.Models.AccountViewModels;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace dtu.blognet.Application.Web.Controllers
{
    /// <summary>
    /// source : https://auth0.com/blog/asp-dot-net-core-authentication-tutorial/
    /// </summary>
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly JwtConfiguration _config;
        
        public AccountController(
            IOptions<JwtConfiguration> options, 
            UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager, 
            JwtConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
        }
        
        public async Task<IActionResult> Register([FromBody] Credentials credentials)
        {
            if (!ModelState.IsValid) return Error("Unexpected error");
            
            var user = new IdentityUser { UserName = credentials.Email, Email = credentials.Email };
            var result = await _userManager.CreateAsync(user, credentials.Password);
            
            if (!result.Succeeded) return Errors(result);
            
            await _signInManager.SignInAsync(user, isPersistent: false);
            return new JsonResult(  new Dictionary<string, object>
            {
                { "access_token", GetAccessToken(credentials.Email) },
                { "id_token", GetIdToken(user) }
            });
        }
        
        
        private string GetIdToken(IdentityUser user) {
            var payload = new Dictionary<string, object>
            {
                { "id", user.Id },
                { "sub", user.Email },
                { "email", user.Email },
                { "emailConfirmed", user.EmailConfirmed },
            };
            return GetToken(payload);
        }

        private string GetAccessToken(string email) {
            var payload = new Dictionary<string, object>
            {
                { "sub", email },
                { "email", email }
            };
            return GetToken(payload);
        }

        private string GetToken(Dictionary<string, object> payload) {
            var secret = _config.SecretKey;

            payload.Add("iss", _config.Issuer);
            payload.Add("aud", _config.Audience);
            payload.Add("nbf", ConvertToUnixTimestamp(DateTime.Now));
            payload.Add("iat", ConvertToUnixTimestamp(DateTime.Now));
            payload.Add("exp", ConvertToUnixTimestamp(DateTime.Now.AddDays(7)));
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            return encoder.Encode(payload, secret);
        }

        private JsonResult Errors(IdentityResult result)
        {
            var items = result.Errors
                .Select(x => x.Description)
                .ToArray();
            return new JsonResult(items) {StatusCode = 400};
        }

        private JsonResult Error(string message)
        {
            return new JsonResult(message) {StatusCode = 400};
        }

        private static double ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date.ToUniversalTime() - origin;
            return Math.Floor(diff.TotalSeconds);
        }
        
        
    }
}