using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace dtu.blognet.Services.Authentication
{
    public class AuthenticationService
    {
        
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly JwtConfiguration _config;
        
        public AuthenticationService(
            IOptions<JwtConfiguration> options, 
            UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager, 
            JwtConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
        }
        
        public async void Register(Credentials Credentials)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = Credentials.Email, Email = Credentials.Email };
                var result = await _userManager.CreateAsync(user, Credentials.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return new JsonResult(  new Dictionary<string, object>
                    {
                        { "access_token", GetAccessToken(Credentials.Email) },
                        { "id_token", GetIdToken(user) }
                    });
                }
                return Errors(result);

            }
            return Error("Unexpected error");
        }
        
        
        
    }
}